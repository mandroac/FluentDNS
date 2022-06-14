export interface HostRecord{
    name: string;
    type: string;
    address: string;
    mxPref?: number;
    ttl: number;
}