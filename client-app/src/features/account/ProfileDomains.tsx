import { observer } from "mobx-react-lite";
import React, { useEffect } from "react";
import { Button, Grid, Icon, List, Popup, Segment } from "semantic-ui-react";
import { useStore } from "../../app/stores/store";

export default observer(function ProfileDomains() {
    const { userStore: { domains, user, getDomains } } = useStore();

    useEffect(() => {
        getDomains()
    }, [getDomains])
    return (
        <Segment>
            <List divided verticalAlign="middle">
                {domains.map(domain => (
                    <List.Item>
                        <List.Content >
                            <Grid padded>
                                <Grid.Row columns={5}>
                                    <Grid.Column width={1}>
                                        {domain.isDomainPrivacy &&
                                            <Popup size="mini"
                                                mouseEnterDelay={200}
                                                mouseLeaveDelay={200}
                                                content="Domain Privacy protection" trigger={
                                                    <Icon circular name="shield" size="large" color="olive" />}
                                            />
                                        }
                                    </Grid.Column>
                                    <Grid.Column width={6} verticalAlign="middle">
                                        <h3 style={{ fontStyle: "italic" }}>{domain.name}</h3>
                                    </Grid.Column>
                                    <Grid.Column width={3}>
                                        <h4>Registered on:</h4>
                                        {new Date(domain.registrationDate).toDateString()}
                                    </Grid.Column>
                                    <Grid.Column width={3}>
                                        <h4>Expires on:</h4>
                                        {new Date(domain.expirationDate).toDateString()}
                                    </Grid.Column>
                                    <Grid.Column width={1} textAlign="center">
                                        <Button content="Manage" />
                                    </Grid.Column>
                                </Grid.Row>
                            </Grid>
                        </List.Content>
                    </List.Item>
                ))}
            </List>
        </Segment>
    )
})