import { Form, Formik } from "formik";
import React from "react";
import { Button, Segment } from "semantic-ui-react";
import CustomTextInput from "../../common/form/CustomTextInput";

export default function LoginForm(){
    return(
        <Segment>
            <Formik 
                initialValues={{usernameOrEmail: '', password: ''}} 
                onSubmit={values => console.log(values)}
                >
                {({handleSubmit}) => (
                    <Form className="ui form" onSubmit={handleSubmit} autoComplete="off" >
                        <CustomTextInput name="emailOrUsername" placeholder="Email or Username"/>
                        <CustomTextInput name="password" placeholder="Password" type="password"/>
                        <Button color="green" basic content="Login" type="submit" fluid />
                    </Form>
                )}
            </Formik>
        </Segment>
    )
}