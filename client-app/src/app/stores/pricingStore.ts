import { makeAutoObservable, runInAction } from "mobx";
import agent from "../../api/agent";
import { DomainPrice } from "../models/DomainPrice";

export default class PricingStore {

    sandboxDefaultPricing: DomainPrice[] = [];
    sandboxFullPricing: DomainPrice[] = [];
    loading = false;

    constructor() {
        makeAutoObservable(this);
    }

    loadDefaultPricing = async () => {
        runInAction(() => this.loading = true)
        try {
            this.sandboxDefaultPricing = await agent.Domains.defaultPricing();
        } catch (error) {
            console.log(error);
        }
        finally {
            runInAction(() => this.loading = false)
        }
    }
}