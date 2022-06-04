import { makeAutoObservable, runInAction } from "mobx";
import agent from "../../api/agent";
import { DomainCheckResult } from "../models/DomainCheckResult";

export default class DomainStore {
    domainCheckResults: DomainCheckResult[] = []
    loading = false;

    constructor() {
        makeAutoObservable(this)
    }

    checkDomainsAvailability = async (domains: string[]) => {
        runInAction(() => this.loading = true);
        try {
            this.domainCheckResults = await agent.Domains.check(domains)
        } catch (error) {
            console.log(error);
        } finally {
            runInAction(() => this.loading = false);
        }
    }
}