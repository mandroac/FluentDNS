import axios, { AxiosResponse } from "axios";
import { Domain } from "../app/models/domain";
import { DomainCheckResult } from "../app/models/domainCheckResult";
import { DomainPrice } from "../app/models/domainPrice";
import { DomainRegisterModel } from "../app/models/domainRegisterModel";
import { LoginUser } from "../app/models/loginUser";
import { RegisterUser } from "../app/models/registerUser";
import { TLD } from "../app/models/TLD";
import { User } from "../app/models/user";
import { store } from "../app/stores/store";

axios.defaults.baseURL = "https://localhost:7014/api"

axios.interceptors.request.use(config => {
    const token = store.commonStore.token;
    if (token) config.headers!.Authorization = `Bearer ${token}`;
    return config;
})

const responseBody = <T>(response: AxiosResponse<T>) => response.data

const requests = {
    get: <T>(url: string) => axios.get<T>(url).then(responseBody),
    post: <T>(url: string, body: {}) => axios.post<T>(url, body).then(responseBody),
    put: <T>(url: string, body: {}) => axios.put<T>(url, body).then(responseBody),
    delete: <T>(url: string) => axios.delete<T>(url).then(responseBody)
}

const Domains = {
    pricing: () => requests.get<DomainPrice[]>('/domains/pricing'),
    check: (domains: string[]) => requests.get<DomainCheckResult[]>(`/domains/check?domains=${domains.join()}`),
    gtlds: () => requests.get<TLD[]>('/domains/gtlds'),
    register: (domain: DomainRegisterModel) => requests.post<Domain>('/domains/register', domain),
    getUserDomains: () => requests.get<Domain[]>('/domains')
}

const Account ={
    current: () => requests.get<User>("/account"),
    login: (user: LoginUser) => requests.post<User>("/account/login", user),
    register: (user: RegisterUser) => requests.post<User>("/account/register", user)
}

const agent = {
    Domains,
    Account
}

export default agent;