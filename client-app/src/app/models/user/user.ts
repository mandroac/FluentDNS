import { UserContacts } from "./userContacts";

export interface User {
    userName: string;
    email: string;
    accountBalance: number;
    token: string;
    contacts?: UserContacts[];
}