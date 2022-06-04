import { createContext, useContext } from "react"
import CommonStore from "./commonStore";
import DomainStore from "./domainStore";
import TldStore from "./tldStore";

interface Store{
    commonStore: CommonStore;
    tldStore: TldStore;
    domainStore: DomainStore;
}

export const store: Store = {
    commonStore: new CommonStore(),
    tldStore: new TldStore(),
    domainStore: new DomainStore()
}

export const StoreContext = createContext(store);

export function useStore() {
    return useContext(StoreContext);
}