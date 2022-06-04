import axios, { AxiosResponse } from "axios";
import { DomainCheckResult } from "../app/models/DomainCheckResult";
import { DomainPrice } from "../app/models/DomainPrice";
import { TLD } from "../app/models/TLD";

axios.defaults.baseURL = "https://localhost:7014/api"

const responseBody = <T>(response: AxiosResponse<T>) => response.data

const requests = {
    get: <T>(url: string, body?: {}) => 
    axios.get<T>(url, { 
        data: JSON.stringify(body), 
        headers: {
            "Content-Type" : "application/json; charset=utf-8",
            "accept": "*/*"
        }
    }).then(responseBody),

    post: <T>(url: string, body: {}) => 
        axios.post<T>(url, body).then(responseBody),

    put: <T>(url: string, body: {}) => 
        axios.put<T>(url, body).then(responseBody),
        
    delete: <T>(url: string) => 
        axios.delete<T>(url).then(responseBody)
}

const Domains = {
    pricing: () => requests.get<DomainPrice[]>('/domains/pricing'),
    check: (domains: string[]) => requests.get<DomainCheckResult[]>('/domains/check', domains),
    gtlds: () => requests.get<TLD[]>('/domains/gtlds')
}

const agent = {
    Domains
}

export default agent;