import { makeAutoObservable, runInAction } from "mobx";
import { history } from "../..";
import agent from "../../api/agent";
import { DomainCheckResult } from "../models/domainCheckResult";
import { DomainPrice } from "../models/domainPrice";
import { DomainRegisterModel } from "../models/domainRegisterModel";
import { store } from "./store";

export type DomainPriceResult = {
    check: DomainCheckResult; 
    registerPrice: number | undefined;
    renewPrice: number | undefined;
    redemptionPrice: number | undefined;
}

export default class DomainStore {
    
    domainPriceResults: DomainPriceResult[] = []
    selectedPriceResult: DomainPriceResult | null = null;
    sandboxPricing: DomainPrice[] = [];
    loadingPrices = false;
    loadingDomainsCheck = false;
    loadingDomainRegistration = false;
    hasCheckResult = false;

    constructor() {
        makeAutoObservable(this)
    }

    checkDomainsAvailability = async (domains: string[]) => {
        runInAction(() => this.loadingDomainsCheck = true);
        try {
            const apiResponse = await agent.Domains.check(domains);
            this.domainPriceResults = [];
            apiResponse.forEach(result => {

                const regularPrice = this.sandboxPricing.find(p => p.tld === result.domain.split('.')[1]);

                let temp : DomainPriceResult = {
                    check: result, 
                    registerPrice: result.isPremiumName ? result.premiumRegistrationPrice : regularPrice?.register,
                    renewPrice: result.isPremiumName ? result.premiumRenewalPrice : regularPrice?.renew,
                    redemptionPrice : result.isPremiumName ? result.premiumRestorePrice : regularPrice?.redemption
                };

                result.domain === domains[0] ?
                    this.domainPriceResults.unshift(temp) :
                    this.domainPriceResults.push(temp)
            })
            this.hasCheckResult = true;
        } catch (error) {
            console.log(error);
            this.hasCheckResult = false;
        } finally {
            runInAction(() => this.loadingDomainsCheck = false);
        }
    }

    register = async (domain: DomainRegisterModel) => {
        runInAction(() => this.loadingDomainRegistration == true);
        try {
            const domainResult = await agent.Domains.register(domain);
            store.userStore.addDomain(domainResult);

            history.push('profile')
        } catch (error) {
            console.log(error);
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

    getTldPrice= (tld: string) => {
        return this.sandboxPricing.find(price => price.tld === tld);
    }

    setSelectedPriceResult = (priceResult: DomainPriceResult) => {
        this.selectedPriceResult = priceResult;
    }

    get defaultSandboxPricing() {
        const tlds = ["com", "net", "org", "biz", "info", "dev"]

        return this.sandboxPricing.filter(price => tlds.includes(price.tld))
    }
}