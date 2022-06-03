import { observable } from "mobx";
import { observer } from "mobx-react-lite";
import React from "react";
import { Container, Label, Menu, Radio } from "semantic-ui-react";
import { useStore } from "../stores/store";

export default observer(function NavBar() {

    const {commonStore} = useStore();
    const {isSandbox, setIsSandbox} = commonStore;

    return (
        <Menu fixed="top" inverted borderless fluid>

            <Container>
                <Menu.Item header icon="bug" content="FluentDNS" name="home" />
                <Menu.Item position="right">
                    <Label content="Production" basic/>
                    <Radio slider checked={isSandbox} onClick={() => setIsSandbox(!isSandbox) }/>
                    <Label content="Sandbox" basic/>
                </Menu.Item>
                <Menu.Menu position="right" >
                    <Menu.Item content="Sign In" name="signIn" />
                    <Menu.Item content="Sign Up" name="signUp" />
                </Menu.Menu>
            </Container>
        </Menu>
    )
})