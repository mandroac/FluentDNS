import React, { useEffect, useState } from "react";
import { Button, Icon, Table } from "semantic-ui-react";
import { DomainPrice } from "../../app/models/domainPrice";
import { useStore } from "../../app/stores/store";

interface Props {
    header?: string;
}

export default function DomainPricingTable({ header }: Props) {
    const { domainStore } = useStore();
    const { sandboxPricing, defaultSandboxPricing, loadPricing } = domainStore;
    const [isFullPricing, setIsFullPricing] = useState(false);

    useEffect(() => {
        if (!sandboxPricing.length) loadPricing();
    }, [sandboxPricing, loadPricing]);

    return (
        <>
            {header && <h1 style={{ textAlign: "center" }}>{header}</h1>}
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
                        sandboxPricing.map((price: DomainPrice) => (
                            <Table.Row key={price.id}>
                                <Table.Cell>{price.tld}</Table.Cell>
                                <Table.Cell>{price.register === null ? '-' : price.register}</Table.Cell>
                                <Table.Cell>{price.renew === null ? '-' : price.renew}</Table.Cell>
                                <Table.Cell>{price.redemption === null ? '-' : price.redemption}</Table.Cell>
                            </Table.Row>))
                        :
                        defaultSandboxPricing.map((price: DomainPrice) => (
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
        </>
    )
}