import { ErrorMessage, Form, Formik } from "formik";
import React, { useState } from "react";
import { Button, Divider, Grid, Label, Segment } from "semantic-ui-react";
import CustomTextInput from "../../common/form/CustomTextInput";
import * as Yup from 'yup';
import { useStore } from "../../app/stores/store";
import { observer } from "mobx-react-lite";
import ValidationErrors from "../../common/form/ValidationErrors";

export default observer(function SignUpSignInForm() {

    const { userStore } = useStore();
    const { login, register } = userStore;
    const [loginData] = useState({
        emailOrUsername: '',
        password: ''
    })

    const [registerData] = useState({
        username: '',
        email: '',
        password: '',
        confirmPassword: ''
    })

    const loginValidationSchema = Yup.object({
        emailOrUsername: Yup.string()
            .required("Please specify email or username"),
        password: Yup.string()
            .required("Please specify password")
    })

    const registerValidationSchema = Yup.object({
        username: Yup.string()
            .required("Username is required")
            .min(3, "Username must contain at least 3 characters")
            .max(20, "Username cannot be longer than 20 characters"),
        password: Yup.string()
            .required("Password is required")
            .min(6, "Password must contain at least 6 characters")
            .matches(/^(?=.*[a-z])(?=.*[A-Z])(?=.*\d)[a-zA-Z\d]{6,}$/,
                "Password must contain at least one uppercase, one lowercase letter and one digit"),
        email: Yup.string().required().email()
    })

    return (
        <Segment placeholder>
            <Grid columns={2} relaxed="very" stackable >
                <Grid.Column verticalAlign="middle">
                    <h1 style={{ textAlign: "center" }}>Login</h1>
                    <Formik
                        initialValues={{ ...loginData, error: null }} validationSchema={loginValidationSchema}
                        onSubmit={(values, { setErrors }) => login(values)
                            .catch(error => setErrors({ error: "Invalid login credentials" }))}>
                        {({ handleSubmit, isSubmitting, dirty, isValid, errors }) => (
                            <Form className="ui form" onSubmit={handleSubmit} autoComplete="off" >
                                <CustomTextInput name="emailOrUsername" placeholder="Email or Username" />
                                <CustomTextInput name="password" placeholder="Password" type="password" />
                                <ErrorMessage name="error" render={() =>
                                    <Label style={{ marginBottom: 10 }} basic color="red" content={errors.error} />
                                } />
                                <Button
                                    icon="share" primary
                                    content="Login"
                                    type="submit" fluid
                                    disabled={isSubmitting || !dirty || !isValid}
                                    loading={isSubmitting}
                                />
                            </Form>
                        )}
                    </Formik>
                </Grid.Column>
                <Grid.Column verticalAlign="middle">
                    <h1 style={{ textAlign: "center" }}>Create account</h1>
                    <Formik
                        initialValues={{ ...registerData, error: null }} validationSchema={registerValidationSchema}
                        onSubmit={(values, { setErrors }) => register(values)
                            .catch(error => setErrors({ error }))}>
                        {({ handleSubmit, isSubmitting, dirty, isValid, errors }) => (
                            <Form className="ui form error" onSubmit={handleSubmit} autoComplete="off" >
                                <CustomTextInput name="email" placeholder="Email" />
                                <CustomTextInput name="username" placeholder="Username" />
                                <CustomTextInput name="password" placeholder="Password" type="password" />
                                <CustomTextInput name="confirmPassword" placeholder="ConfirmPassword" type="password" />
                                <ErrorMessage name="error" render={() =>
                                    <ValidationErrors errors={errors.error} />
                                } />
                                <Button
                                    icon="signup" content="Register"
                                    type="submit" fluid
                                    disabled={isSubmitting || !dirty || !isValid}
                                    loading={isSubmitting}
                                />
                            </Form>
                        )}
                    </Formik>
                </Grid.Column>
            </Grid>
            <Divider vertical>Or</Divider>
        </Segment>
    )
})