export interface DomainContacts {
    organizationName?: string;
    jobTitle?: string;
    firstName: string;
    lastName: string;
    address1: string;
    address2?: string;
    city: string;
    countryName: string;
    stateProvince: string;
    postalCode: string;
    phone: string;
    phoneExt?: string;
    fax?: string;
    emailAddress: string;
    contactsType?: number;
}