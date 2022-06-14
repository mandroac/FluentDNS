import { makeAutoObservable, runInAction } from "mobx";
import agent from "../../api/agent";
import DomainFullDnsDetails from "../models/dns/domainFullDnsDetails";

export default class DnsStore{
    loadingDnsCheck = false;
    dnsDetails: DomainFullDnsDetails | null = null;

    constructor() {
        makeAutoObservable(this);        
    }

    getFullDnsDetails = async (domain: string) => {
        runInAction(() => this.loadingDnsCheck = true);
        try {
            this.dnsDetails = await agent.Dns.getDomainFullDnsDetails(domain);
        } catch (error) {
            console.log(error)
        } finally {
            runInAction(() => this.loadingDnsCheck = false)
        }
    }
}