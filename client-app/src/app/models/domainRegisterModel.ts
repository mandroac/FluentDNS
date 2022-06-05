import { DomainContacts } from "./domainContacts";

export interface DomainRegisterModel{
    domainName: string;
    years: number;
    addFreeWhoisguard: string;
    wgEnabled: string;
    registrant?: DomainContacts;
    tech?: DomainContacts;
    admin?: DomainContacts;
    billing?: DomainContacts;
    nameservers?: string[]
}

export class DomainRegisterFormValues{
    years: number = 1;
    domainPrivacy: boolean = true;
    organizationName?: string = undefined;
    jobTitle?: string = undefined;
    firstName: string = '';
    lastName: string = '';
    address1: string = '';
    address2?: string = undefined
    city: string = ''
    country: string = ''
    stateProvince: string = ''
    postalCode: string = ''
    phone: string = ''
    phoneExt?: string = undefined;
    fax?: string = undefined;
    emailAddress: string = ''
}