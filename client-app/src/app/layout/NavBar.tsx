import { observer } from "mobx-react-lite";
import React from "react";
import { Link, NavLink } from "react-router-dom";
import { Container, Dropdown, Label, Menu, Radio, Segment } from "semantic-ui-react";
import { useStore } from "../stores/store";

export default observer(function NavBar() {

    const { commonStore, userStore: { user, isLoggedIn, logout } } = useStore();
    const { isSandbox, setIsSandbox } = commonStore;

    return (
        <Menu fixed="top" inverted borderless fluid>

            <Container>
                <Menu.Item header icon="bug" content="FluentDNS" name="home" as={NavLink} to='/' />
                <Menu.Item position="right">
                    <Segment basic>
                        <Radio toggle label={isSandbox ? "Sandbox" : "Production"}
                            slider checked={isSandbox} onClick={() => setIsSandbox(!isSandbox)} />
                    </Segment>
                </Menu.Item>
                <Menu.Menu position="right" >
                    {isLoggedIn ?
                        <Menu.Item>
                            <Dropdown icon={"user"} text={user?.userName} pointing="top" simple item >
                                <Dropdown.Menu>
                                    <Dropdown.Item icon="user outline" as={Link} to={'profile'} text="Profile" />
                                    <Dropdown.Divider />
                                    <Dropdown.Item icon="power" onClick={logout} text="Logout" />
                                </Dropdown.Menu>
                            </Dropdown>
                        </Menu.Item>
                        : <Menu.Item content="Sign In" name="signIn" as={NavLink} to='/login' />
                    }
                </Menu.Menu>
            </Container>
        </Menu>
    )
})