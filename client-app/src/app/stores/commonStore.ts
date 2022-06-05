import { makeAutoObservable, reaction } from "mobx";

export default class CommonStore {
    isSandbox: boolean = true;
    token: string | null = window.localStorage.getItem("jwt");
    appLoaded = false;

    constructor() {
        makeAutoObservable(this);

        reaction(
            () => this.token,
            token => {
                token ? window.localStorage.setItem("jwt", token)
                : window.localStorage.removeItem("jwt")
            }
        )
    }

    setIsSandbox = (isSandbox: boolean) => {
        this.isSandbox = isSandbox;
    }

    setToken = (token: string | null) => {
        this.token = token;
    }

    setAppLoaded = () => {
        this.appLoaded = true;
    }
}