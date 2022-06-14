import { observer } from "mobx-react-lite";
import React, { useEffect, useState } from "react";
import { Button, Divider, Grid, Icon, Input, Label, Segment } from "semantic-ui-react";
import { useStore } from "../../app/stores/store";

export default observer(function ProfileSettings() {
    const { userStore: { user } } = useStore()
    const [emailInputEnabled, setEmailInputEnabled] = useState(false);
    const [passwordInputEnabled, setPasswordInputEnabled] = useState(false);
    const [passwordConfirmEnabled, setPasswordConfirmEnabled] = useState(false);
    const [emailInput, setEmailInput] = useState('');
    const [passwordInput, setPasswordInput] = useState('');
    const [passwordConfirm, setPasswordConfirm] = useState('');
    const [passwordError, setPasswordError] = useState('');

    useEffect(() => {
        user?.email ? setEmailInput(user.email) : setEmailInput('')
    }, [user?.email])

    function handlePasswordEdit() {
        setPasswordError('');
        if (passwordInput != passwordConfirm)
            setPasswordError("Password and Confirm Password do not match")
        else {
            console.log('pw upd');
            setPasswordInputEnabled(!passwordInputEnabled);
            setPasswordConfirmEnabled(!passwordConfirmEnabled);
            setPasswordError('');
            setPasswordInput('');
            setPasswordConfirm('');
        }
    }

    return (
        <Segment padded="very">
            <Grid>
                <Grid.Row>
                    <Grid.Column width={6} textAlign="center">
                        <h3 style={{ textAlign: "center" }}>Primary Email</h3>
                    </Grid.Column>
                    <Grid.Column width={10}>
                        <Input iconPosition="left" fluid>
                            <Icon name="at" />
                            <input
                                disabled={!emailInputEnabled}
                                value={emailInput}
                                style={{ textAlign: "center", fontSize: 16 }}
                                onChange={(e) => setEmailInput(e.target.value)} />
                            <Button basic primary
                                content={emailInputEnabled ? "Update email" : "Enable editing"}
                                onClick={() => (emailInputEnabled && console.log(`Email upd: ${emailInput}`))
                                    || setEmailInputEnabled(!emailInputEnabled)}
                            />
                        </Input>
                    </Grid.Column>
                </Grid.Row>
                <Divider />
                <Grid.Row>
                    <Grid.Column width={6} textAlign="center">
                        <h3 style={{ textAlign: "center" }}>Update Password</h3>
                    </Grid.Column>
                    <Grid.Column width={10}>
                        <Input iconPosition="left" fluid>
                            <Icon name={passwordInputEnabled ? "lock open" : "lock"} />
                            <input
                                type={"password"}
                                disabled={!passwordInputEnabled}
                                value={passwordConfirmEnabled ? passwordConfirm : passwordInput}
                                style={{ textAlign: "center", fontSize: 16 }}
                                onChange={(e) => passwordConfirmEnabled ? setPasswordConfirm(e.target.value)
                                    : setPasswordInput(e.target.value)} />
                            <Button basic primary
                                content={passwordInputEnabled ?
                                    (passwordConfirmEnabled ? "Update password" : "Confirm password")
                                    : "Enable editing"}
                                onClick={() => (passwordInputEnabled ?
                                    (passwordConfirmEnabled ? handlePasswordEdit() : setPasswordConfirmEnabled(!passwordConfirmEnabled))
                                    : setPasswordInputEnabled(!passwordInputEnabled))}
                            />
                        </Input>
                        {passwordError && <Label  basic content={passwordError} pointing color="red" />}
                    </Grid.Column>
                </Grid.Row>
            </Grid>
        </Segment>
    )
})