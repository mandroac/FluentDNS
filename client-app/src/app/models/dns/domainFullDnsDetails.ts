import { HostRecord } from "./hostRecord";

export default interface DomainFullDnsDetails{
    domain: string;
    isUsingOurDns: boolean;
    hostRecords?: HostRecord[];
    nameservers: string[];
}