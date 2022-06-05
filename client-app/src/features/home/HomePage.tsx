import { observer } from "mobx-react-lite";
import { Segment } from "semantic-ui-react";
import LoadingComponent from "../../app/layout/LoadingComponent";
import { useStore } from "../../app/stores/store";
import DomainCheckResultTable from "./DomainCheckResultTable";
import DomainSearchInput from "./DomainSearchInput";
import MainDomainCheckResult from "./MainDomainCheckResult";
import PricingTable from "./DomainPricingTable";

export default observer(function HomePage() {
    const { domainStore } = useStore();
    const { hasCheckResult, domainPriceResults, loadingPrices } = domainStore

    if (loadingPrices) return <LoadingComponent content="Loading pricing..." />
    return (
        <>
                <DomainSearchInput />
                {hasCheckResult &&
                    <>
                        <MainDomainCheckResult domainPriceResult={domainPriceResults[0]} />
                        <Segment>
                            <h3>We have also checked:</h3>
                            <DomainCheckResultTable domainPriceResults={domainPriceResults.slice(1)} />
                        </Segment>
                    </>
                }
                <div style={{padding: "4em 0 0 0"}}>
                    <Segment>
                        <PricingTable header="Our prices:" />
                    </Segment>
                </div>
        </>
    )
})