import { DomainContacts } from "./domainContacts";

export interface Domain{
    id: string;
    name: string;
    registrationDate: Date;
    expirationDate: Date;
    isDomainPrivacy: boolean;
    isAutoRenew: boolean;
    contacts: DomainContacts[];
}