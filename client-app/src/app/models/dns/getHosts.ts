import { HostRecord } from "./hostRecord";

export default interface GetHosts{
    domain: string;
    isUsingOurDNS: boolean;
    hosts: HostRecord[];
}