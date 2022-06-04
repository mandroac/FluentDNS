import React from "react";
import { Button, Icon, Label, Table } from "semantic-ui-react";
import { DomainCheckResult } from "../../app/models/DomainCheckResult";

interface Props {
    domainCheckResults: { check: DomainCheckResult, price: number | undefined }[]
}

export default function DomainCheckResultTable({ domainCheckResults }: Props) {
    return (
        <Table>
            {domainCheckResults.map(item => (
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
                                    content={`Register at \$${item.check.isPremiumName ?
                                        item.check.premiumRegistrationPrice :
                                        item.price}`}
                                /> :
                                <Label basic color="grey" content={"Taken"} />
                            }
                        </>
                    } />
                    <Table.Cell width={2} content={
                        <Button basic fluid
                            positive={item.check.available}
                            disabled={!item.check.available}
                            content="Register" />} />
                </Table.Row>
            ))}
        </Table>
    )
}