import { observer } from 'mobx-react-lite'
import React, { useEffect } from 'react'
import { Button, Grid, Header, Icon, Item, ItemMeta, Segment, Statistic } from 'semantic-ui-react';
import { useStore } from '../../app/stores/store'

export default observer(function ProfileHeader() {
    const { userStore: { user, getUser } } = useStore();
    useEffect(() => {
        if (!user) {
            getUser();
        }
    }, [user, getUser])
    return (
        <Segment >
            <Grid>
                <Grid.Column width={12} verticalAlign="middle">
                    <Item.Group>
                        <Item>
                            <Item.Image src='https://react.semantic-ui.com/images/avatar/large/tom.jpg' size='small' circular />
                            {/* <Icon size='huge' name="user" circular style={{ color: "#491234" }}/>  */}
                            <Item.Content verticalAlign='middle'>
                                <p style={{ fontSize: 18 }}>Hello,</p>
                                <Header as={"h2"} content={user?.userName} />
                            </Item.Content>
                        </Item>
                    </Item.Group>
                </Grid.Column>
                <Grid.Column width={4} verticalAlign="middle">
                    <Statistic>
                        <Statistic.Value content={user?.accountBalance} />
                        <Statistic.Label content="Account balance" />
                        <Button basic circular size="mini" content="Add funds" />
                    </Statistic>
                </Grid.Column>
            </Grid>
        </Segment>
    )
})
