import React from "react";
import { Container, Menu } from "semantic-ui-react";

export default function NavBar() {
    return (
        <Menu fixed="top" inverted secondary>
            <Container>
                    <Menu.Item header icon="bug" content="FluentDNS" name="home"/>
                <Menu.Menu position="right" >
                    <Menu.Item content="Sign In" name="signIn" />
                    <Menu.Item content="Sign Up" name="signUp"/>
                </Menu.Menu>
            </Container>
        </Menu>
    )
}