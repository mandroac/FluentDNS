import { makeAutoObservable } from "mobx";

export default class CommonStore {
    isSandbox: boolean = true;

    constructor() {
        makeAutoObservable(this)
    }

    setIsSandbox = (isSandbox: boolean) => {
        this.isSandbox = isSandbox;
    }
}