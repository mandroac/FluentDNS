import { HostRecord } from "./hostRecord";

export default interface DomainFullDnsDetails{
    domain: string;
    isUsingOurDNS: boolean;
    hostRecords?: HostRecord[];
    nameservers: string[];
}