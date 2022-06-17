export interface HostRecord{
    id: number | null;
    name: string;
    type: string;
    address: string;
    mxPref?: number;
    ttl: number;
}