export interface DomainCheckResult {
    domain: string;
    available: boolean;
    isPremiumName: boolean;
    premiumRegistrationPrice?: number;
    premiumRenewalPrice?: number;
    premiumRestorePrice?: number;
    premiumTransferPrice?: number;
    icannFee?: number;
}