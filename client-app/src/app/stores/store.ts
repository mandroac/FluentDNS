import { createContext, useContext } from "react"
import CommonStore from "./commonStore";
import DomainStore from "./domainStore";
import TldStore from "./tldStore";
import UserStore from "./userStore";

interface Store{
    commonStore: CommonStore;
    tldStore: TldStore;
    domainStore: DomainStore;
    userStore: UserStore;
}

export const store: Store = {
    commonStore: new CommonStore(),
    tldStore: new TldStore(),
    domainStore: new DomainStore(),
    userStore: new UserStore()
}

export const StoreContext = createContext(store);

export function useStore() {
    return useContext(StoreContext);
}