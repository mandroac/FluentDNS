import { makeAutoObservable, runInAction } from "mobx";
import agent from "../../api/agent";
import { DomainPrice } from "../models/DomainPrice";

export default class PricingStore {

    sandboxPricing: DomainPrice[] = [];
    loading = false;

    constructor() {
        makeAutoObservable(this);
    }

    loadPricing = async () => {
        runInAction(() => this.loading = true)
        try {
            this.sandboxPricing = await agent.Domains.pricing();
        } catch (error) {
            console.log(error);
        }
        finally {
            runInAction(() => this.loading = false)
        }
    }

    get defaultSandboxPricing(){
        const tlds = [ "com", "net", "org", "biz", "info", "dev"]

        return this.sandboxPricing.filter(price => tlds.includes(price.tld))
    }
}