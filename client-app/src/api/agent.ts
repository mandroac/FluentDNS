import axios, { AxiosResponse } from "axios";
import { DomainPrice } from "../app/models/DomainPrice";

axios.defaults.baseURL = "https://localhost:7014/api"

const responseBody = <T> (response: AxiosResponse<T>) => response.data

const requests = {
    get: <T> (url: string, body?: {}) => axios.get<T>(url, body).then(responseBody),
    post: <T> (url: string, body: {}) => axios.post<T>(url, body).then(responseBody),
    put: <T>(url: string, body: {}) => axios.put<T>(url, body).then(responseBody),
    delete: <T> (url: string) => axios.delete<T>(url).then(responseBody)
}

const Domains = {
    defaultPricing: () => requests.get<DomainPrice[]>('/domains/pricing')
}

const agent = {
    Domains
}

export default agent;