import React from "react";
import { Link } from "react-router-dom";
import { Button, Icon, Label, Table } from "semantic-ui-react";
import { DomainPriceResult } from "../../app/stores/domainStore";
import { useStore } from "../../app/stores/store";

interface Props {
    domainPriceResults: DomainPriceResult[]
}

export default function DomainCheckResultTable({ domainPriceResults }: Props) {
    const { domainStore: {setSelectedPriceResult}} = useStore()
    return (
        <Table>
            {domainPriceResults.map(item => (
                <Table.Row>
                    <Table.Cell width={1} content={
                        <Icon name={item.check.available ?
                            "check circle outline" :
                            "times circle outline"}
                            size="big"
                            color={item.check.available ? "green" : "red"} />}
                    />
                    <Table.Cell width={6} content={
                        <h3 color={item.check.available ? "green" : "red"}>
                            {item.check.domain}
                        </h3>}
                    />
                    <Table.Cell width={7} content={
                        <>
                            {item.check.isPremiumName &&
                                <Label basic color="yellow" content={"PREMIUM"} />
                            }
                            {item.check.available ?
                                <Label basic color="green"
                                    content={`Register at \$${item.registerPrice}`}
                                /> :
                                <Label basic color="grey" content={"Taken"} />
                            }
                        </>
                    } />
                    <Table.Cell width={2} content={
                        <Button basic fluid
                            as={Link} to={"register"} 
                            onClick={() => setSelectedPriceResult(item)}
                            positive={item.check.available}
                            disabled={!item.check.available}
                            content="Register" />} />
                </Table.Row>
            ))}
        </Table>
    )
}