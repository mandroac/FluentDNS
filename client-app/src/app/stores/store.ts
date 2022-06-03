import { createContext, useContext } from "react"
import CommonStore from "./commonStore";
import PricingStore from "./pricingStore";

interface Store{
    pricingStore: PricingStore;
    commonStore: CommonStore
}

export const store: Store = {
    pricingStore: new PricingStore(),
    commonStore: new CommonStore()
}

export const StoreContext = createContext(store);

export function useStore() {
    return useContext(StoreContext);
}