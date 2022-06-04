import { createContext, useContext } from "react"
import CommonStore from "./commonStore";
import PricingStore from "./pricingStore";
import TldStore from "./tldStore";

interface Store{
    pricingStore: PricingStore;
    commonStore: CommonStore;
    tldStore: TldStore;
}

export const store: Store = {
    pricingStore: new PricingStore(),
    commonStore: new CommonStore(),
    tldStore: new TldStore()
}

export const StoreContext = createContext(store);

export function useStore() {
    return useContext(StoreContext);
}