import { Country } from "./country";

export interface UserContacts{
    id: string;
    addressName: string;
    defaultYN: boolean;
    emailAddress: string;
    firstName: string;
    lastName: string;
    jobTitle?: string;
    organization: string;
    address1: string;
    address2?: string;
    city: string;
    country: Country;
    stateProvince: string;
    zip: string;
    phone: string;
    phoneExt?: string;
    fax?: string;
}