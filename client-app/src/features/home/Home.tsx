import { observer } from "mobx-react-lite";
import { useEffect, useState } from "react";
import { Button, Container, Icon, Table } from "semantic-ui-react";
import LoadingComponent from "../../app/layout/LoadingComponent";
import { DomainPrice } from "../../app/models/DomainPrice";
import { useStore } from "../../app/stores/store";
import DomainSearchInput from "./DomainSearchInput";

export default observer(function Home() {
    const { pricingStore } = useStore();
    const [isFullPricing, setIsFullPricing] = useState(false)

    useEffect(() => {
        pricingStore.loadPricing();
    }, [pricingStore]);

    if (pricingStore.loading) return <LoadingComponent content="Loading pricing..." />
    return (
        <>
            <Container style={{ margin: '7em' }} >
                <DomainSearchInput />
                <Table celled striped textAlign="center" color="violet">
                    <Table.Header>
                        <Table.Row>
                            <Table.HeaderCell content="TLD" />
                            <Table.HeaderCell content="Register" />
                            <Table.HeaderCell content="Renew" />
                            <Table.HeaderCell content="Redemption" />
                        </Table.Row>
                    </Table.Header>
                    <Table.Body >
                        {isFullPricing ?
                            pricingStore.sandboxPricing.map((price: DomainPrice) => (
                                <Table.Row key={price.id}>
                                    <Table.Cell>{price.tld}</Table.Cell>
                                    <Table.Cell>{price.register === null ? '-' : price.register}</Table.Cell>
                                    <Table.Cell>{price.renew === null ? '-' : price.renew}</Table.Cell>
                                    <Table.Cell>{price.redemption === null ? '-' : price.redemption}</Table.Cell>
                                </Table.Row>))
                            :
                            pricingStore.defaultSandboxPricing.map((price: DomainPrice) => (
                                <Table.Row key={price.id}>
                                    <Table.Cell>{price.tld}</Table.Cell>
                                    <Table.Cell>{price.register === null ? '-' : price.register}</Table.Cell>
                                    <Table.Cell>{price.renew === null ? '-' : price.renew}</Table.Cell>
                                    <Table.Cell>{price.redemption === null ? '-' : price.redemption}</Table.Cell>
                                </Table.Row>
                            ))}
                    </Table.Body>
                </Table>
                <Button fluid circular onClick={() => setIsFullPricing(!isFullPricing)}>
                    {isFullPricing ? "Show default " : "Show all "}
                    <Icon name={isFullPricing ? "angle up" : "angle down"} />
                </Button>
            </Container>
        </>
    )
})