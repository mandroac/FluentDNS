import { makeAutoObservable, runInAction } from "mobx";
import agent from "../../api/agent";
import { DomainCheckResult } from "../models/DomainCheckResult";
import { DomainPrice } from "../models/DomainPrice";

export default class DomainStore {
    domainCheckResults: { check: DomainCheckResult, price: number | undefined }[] = []
    sandboxPricing: DomainPrice[] = [];
    loadingPrices = false;
    loadingDomainsCheck = false;
    hasCheckResult = false;

    constructor() {
        makeAutoObservable(this)
    }

    checkDomainsAvailability = async (domains: string[]) => {
        runInAction(() => this.loadingDomainsCheck = true);
        try {
            const apiResponse = await agent.Domains.check(domains);
            this.domainCheckResults = [];
            apiResponse.forEach(result => {
                
                const price = result.isPremiumName ?
                    result.premiumRegistrationPrice :
                    this.sandboxPricing.find(p => p.tld === result.domain.split('.')[1])?.register

                result.domain === domains[0] ?
                    this.domainCheckResults.unshift({ check: result, price }) :
                    this.domainCheckResults.push({ check: result, price })
            })
            this.hasCheckResult = true;
        } catch (error) {
            console.log(error);
            this.hasCheckResult = false;
        } finally {
            runInAction(() => this.loadingDomainsCheck = false);
        }
    }

    loadPricing = async () => {
        runInAction(() => this.loadingPrices = true)
        try {
            this.sandboxPricing = await agent.Domains.pricing();
        } catch (error) {
            console.log(error);
        }
        finally {
            runInAction(() => this.loadingPrices = false)
        }
    }

    getTldPrice(tld: string) {
        return this.sandboxPricing.find(price => price.tld === tld);
    }

    get defaultSandboxPricing() {
        const tlds = ["com", "net", "org", "biz", "info", "dev"]

        return this.sandboxPricing.filter(price => tlds.includes(price.tld))
    }
}