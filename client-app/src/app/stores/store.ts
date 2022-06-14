import { createContext, useContext } from "react"
import CommonStore from "./commonStore";
import DnsStore from "./dnsStore";
import DomainStore from "./domainStore";
import TldStore from "./tldStore";
import UserStore from "./userStore";

interface Store{
    commonStore: CommonStore;
    tldStore: TldStore;
    domainStore: DomainStore;
    userStore: UserStore;
    dnsStore: DnsStore;
}

export const store: Store = {
    commonStore: new CommonStore(),
    tldStore: new TldStore(),
    domainStore: new DomainStore(),
    userStore: new UserStore(),
    dnsStore: new DnsStore()
}

export const StoreContext = createContext(store);

export function useStore() {
    return useContext(StoreContext);
}