import { makeAutoObservable, runInAction } from "mobx";
import agent from "../../api/agent";
import DomainFullDnsDetails from "../models/dns/domainFullDnsDetails";
import { HostRecord } from "../models/dns/hostRecord";

export default class DnsStore {
    loadingDnsCheck = false;
    loadingRecordsSave = false;
    loadingNameserversSave = false;
    dnsDetails: DomainFullDnsDetails | null = null;

    constructor() {
        makeAutoObservable(this);
    }

    getFullDnsDetails = async (domain: string) => {
        runInAction(() => this.loadingDnsCheck = true);
        try {
            let result = await agent.Dns.getDomainFullDnsDetails(domain);
            let id = 0;
            result.hostRecords?.map(record => (record.id = id++))
            this.dnsDetails = result;
        } catch (error) {
            console.log(error)
        } finally {
            runInAction(() => this.loadingDnsCheck = false)
        }
    }

    editHostRecord = (record: HostRecord) => {
        const foundIndex = this.dnsDetails?.hostRecords?.findIndex(r => r.id == record.id);
        if (foundIndex != undefined && this.dnsDetails?.hostRecords) {
            this.dnsDetails.hostRecords[foundIndex] = record;
        }
    }

    addHostRecord = (record: HostRecord) => {
        this.dnsDetails?.hostRecords?.push(record)
    }

    removeHostRecord = (recordId: number) => {
        const foundIndex = this.dnsDetails?.hostRecords?.findIndex(r => r.id == recordId);
        if (foundIndex != undefined && this.dnsDetails?.hostRecords) {
            this.dnsDetails.hostRecords.splice(foundIndex, 1);
        }
    }

    saveHostRecords = async () => {
        if (this.dnsDetails) {
            runInAction(() => this.loadingRecordsSave = true);
            try {
                await agent.Dns.setHosts(this.dnsDetails.domain, this.dnsDetails.hostRecords!)
            } catch (error) {
                console.log(error)
            } finally {
                runInAction(() => this.loadingRecordsSave = false)
            }
        }
    }

    setCustom = async (nameservers: string[]) => {
        if (this.dnsDetails) {
            runInAction(() => this.loadingNameserversSave = true);
            try {
                await agent.Dns.setCustom(this.dnsDetails.domain, nameservers);
                this.dnsDetails!.nameservers = nameservers;
                this.dnsDetails!.isUsingOurDNS = false;
            } catch (error) {
                console.log(error);
            } finally {
                runInAction(() => this.loadingNameserversSave = false);
            }
        }
    }

    setDefault = async () => {
        if (this.dnsDetails) {
            runInAction(() => this.loadingNameserversSave = true);
            try {
                await agent.Dns.setDefault(this.dnsDetails.domain).then(async () => {
                    this.dnsDetails!.hostRecords = (await agent.Dns.getHosts(this.dnsDetails!.domain)).hosts;
                });
                this.dnsDetails!.nameservers = ["dns1.registrar-servers.com", "dns2.registrar-servers.com"];
                this.dnsDetails!.isUsingOurDNS = true;
            } catch (error) {
                console.log(error);
            } finally {
                runInAction(() => this.loadingNameserversSave = false);
            }
        }
    }
}