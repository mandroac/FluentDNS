import { observer } from "mobx-react-lite";
import { useEffect } from "react";
import { Container, Table } from "semantic-ui-react";
import LoadingComponent from "../../app/layout/LoadingComponent";
import { DomainPrice } from "../../app/models/DomainPrice";
import { useStore } from "../../app/stores/store";

export default observer(function Home() {
    const { pricingStore } = useStore();

    useEffect(() => {
        pricingStore.loadDefaultPricing();
    }, [pricingStore]);

    if (pricingStore.loading) return <LoadingComponent content="Loading pricing..." />
    return (
        <Container style={{ marginTop: '7em' }}>
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
                    {pricingStore.sandboxDefaultPricing.map((price: DomainPrice) => (
                        <Table.Row key={price.id}>
                            <Table.Cell>{price.tld}</Table.Cell>
                            <Table.Cell>{price.register === null ? '-' : price.register}</Table.Cell>
                            <Table.Cell>{price.renew === null ? '-' : price.renew}</Table.Cell>
                            <Table.Cell>{price.redemption === null ? '-' : price.redemption}</Table.Cell>
                        </Table.Row>
                    ))}
                </Table.Body>
            </Table>
        </Container>
    )
})