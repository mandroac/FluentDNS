import { useEffect } from "react";
import { Button, Card, Divider, Grid, List } from "semantic-ui-react";
import { Domain } from "../../app/models/domain/domain";
import { useStore } from "../../app/stores/store";
import DomainHostsTable from "./DomainHostsTable";
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
        if (dnsDetails === null || dnsDetails.domain !== domain.name) {
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
                        <DomainHostsTable records={dnsDetails?.hostRecords} isUsingOurDNS={dnsDetails?.isUsingOurDns} />
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
                <Button content={"Back to domains list"} onClick={onCancel} basic circular/>
        </>
    )
}