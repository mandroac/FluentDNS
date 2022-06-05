import { makeAutoObservable, runInAction } from "mobx";
import { history } from "../..";
import agent from "../../api/agent";
import { Domain } from "../models/domain";
import { LoginUser } from "../models/loginUser";
import { RegisterUser } from "../models/registerUser";
import { User } from "../models/user";
import { store } from "./store";

export default class UserStore{
    user: User | null = null;
    domains: Domain[] = [];

    constructor(){
        makeAutoObservable(this);
    }

    get isLoggedIn(){
        return !!this.user;
    }

    login = async (creds: LoginUser) => {
        try {
            const user = await agent.Account.login(creds);
            store.commonStore.setToken(user.token);
            runInAction(() => this.user = user);
            history.push('/');
        } catch (error) {
            throw error;
        }
    }

    register = async (data: RegisterUser) => {
        try {
            const user = await agent.Account.register(data);
            store.commonStore.setToken(user.token);
            runInAction(() => this.user = user);
            history.push('/');
        } catch (error) {
            throw error;
        }
    }

    logout = () => {
        store.commonStore.setToken(null);
        window.localStorage.removeItem("jwt");
        this.user = null;
        history.push('/');
    }

    getUser = async () => {
        try {
            this.user = await agent.Account.current()
        } catch (error) {
            console.log(error);
        }
    }

    addDomain = (domain: Domain) => {
        this.domains.push(domain);
    }
}