import { useEffect } from "react";
import { Button, Card, Divider, Grid, List, Segment, Table } from "semantic-ui-react";
import { Domain } from "../../app/models/domain/domain";
import { useStore } from "../../app/stores/store";
import DomainStatus from "./DomainStatus";

interface Props {
    domain: Domain;
    onCancel: () => void;
}
const contactTypesMap: Map<number, string> = new Map<number, string>([
    [0, "Admin"],
    [1, "Billing"],
    [2, "Registrant"],
    [3, "Tech"]
])

export default function ManageDomainTab({ domain, onCancel }: Props) {
    const { dnsStore: { getFullDnsDetails, dnsDetails } } = useStore()

    useEffect(() => {
        if (dnsDetails === null || dnsDetails.domain != domain.name) {
            getFullDnsDetails(domain.name);
        }
    }, [getFullDnsDetails]);

    return (
        <>
            <h1>Edit <span style={{ color: "purple" }}>{domain.name}</span> domain</h1>
            <Grid padded>
                <Grid.Row>
                    <Grid.Column width={3}>
                        <h3>Status:</h3>
                    </Grid.Column>
                    <Grid.Column width={10}>
                        <DomainStatus now={new Date()} expiration={domain.expirationDate} />
                    </Grid.Column>
                    <Grid.Column width={3}>
                        <Button content="Renew" basic color="yellow" />
                    </Grid.Column>
                </Grid.Row>
                <Divider />
                <Grid.Row>
                    <Grid.Column width={3}>
                        <h3>Nameservers: </h3>
                    </Grid.Column>
                    <Grid.Column width={10}>
                        <List>
                            {dnsDetails?.nameservers.map(ns => (
                                <List.Item key={ns}>
                                    {ns}
                                </List.Item>
                            ))}
                        </List>
                    </Grid.Column>
                    <Grid.Column width={3}>
                        <Button content={"Edit"} primary basic />
                    </Grid.Column>
                </Grid.Row>
                <Divider />
                <Grid.Row >
                    <Grid.Column width={3}>
                        <h3>Host records:</h3>
                    </Grid.Column>
                    <Grid.Column width={13}>
                        {!dnsDetails?.isUsingOurDns ?
                            <>
                                <Table striped celled >
                                    <Table.Header>
                                        <Table.Row>
                                            <Table.HeaderCell>
                                                Host
                                            </Table.HeaderCell>
                                            <Table.HeaderCell>
                                                Type
                                            </Table.HeaderCell>
                                            <Table.HeaderCell>
                                                Value
                                            </Table.HeaderCell>
                                            <Table.HeaderCell>
                                                TTL
                                            </Table.HeaderCell>
                                            <Table.HeaderCell>
                                                Actions
                                            </Table.HeaderCell>
                                        </Table.Row>
                                    </Table.Header>
                                    {dnsDetails?.hostRecords?.map(record => (
                                        <Table.Row>
                                            <Table.Cell>
                                                {record.name}
                                            </Table.Cell>
                                            <Table.Cell>
                                                {record.type}
                                            </Table.Cell>
                                            <Table.Cell>
                                                {record.address}
                                            </Table.Cell>
                                            <Table.Cell>
                                                {record.ttl}
                                            </Table.Cell>
                                            <Table.Cell>
                                                <Button icon="delete" floated="right" />
                                                <Button icon="edit" floated="right" />
                                            </Table.Cell>
                                        </Table.Row>
                                    ))}
                                </Table>
                                <Button content="Add record" circular />
                            </> :
                            <Segment>
                                This domain is using third-party nameservers
                            </Segment>
                        }
                    </Grid.Column>
                </Grid.Row>
                <Divider />
                <Grid.Row>
                    <h3>Domain contacts:</h3>
                </Grid.Row>
                <Grid.Row>
                    {domain.contacts.map(contact => (
                        <Grid.Column width={4}>
                            <Card>
                                <Card.Content header>
                                    {contactTypesMap.get(contact.contactsType!)}
                                </Card.Content>
                                <Card.Content description style={{ fontSize: 12 }}>
                                    <List>
                                        <List.Item>
                                            First name: {contact.firstName}
                                        </List.Item>
                                        <List.Item>
                                            Last name: {contact.lastName}
                                        </List.Item>
                                        <List.Item>
                                            Email: {contact.emailAddress}
                                        </List.Item>
                                        <List.Item>
                                            ...
                                        </List.Item>
                                    </List>
                                </Card.Content>
                                <Card.Content extra>
                                    <Button basic content="Edit" />
                                </Card.Content>
                            </Card>
                        </Grid.Column>
                    ))}
                </Grid.Row>
            </Grid>
            <Button.Group fluid>
                <Button style={{ margin: "5px" }} content={"Save"} positive />
                <Button style={{ margin: "5px" }} content={"Cancel"} onClick={onCancel} />
            </Button.Group>
        </>
    )
}