import { makeAutoObservable, runInAction } from "mobx";
import agent from "../../api/agent";
import { TLD } from "../models/domain/TLD";

export default class TldStore{
    gtlds: TLD[] = [];
    loading = false;

    constructor(){
        makeAutoObservable(this);
    }

    loadGtlds = async () => {
        runInAction(() => this.loading = true)
        try {
            this.gtlds = await agent.Domains.gtlds();
        } catch (error) {
            console.log(error);
        }
        finally {
            runInAction(() => this.loading = false)
        }
    }
}