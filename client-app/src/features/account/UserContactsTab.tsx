import { Form, Formik } from "formik";
import { observer } from "mobx-react-lite";
import { useEffect, useState } from "react";
import { Button, Container, Divider } from "semantic-ui-react";
import { history } from "../..";
import { UserContacts } from "../../app/models/user/userContacts";
import { useStore } from "../../app/stores/store";
import CustomTextInput from "../../common/form/CustomTextInput";

export default observer(function UserContactsTab() {
    const { userStore: { user } } = useStore();
    const [contacts, setContacts] = useState<UserContacts>({
        firstName: "",
        lastName: "",
        id: "",
        addressName: "",
        defaultYN: true,
        emailAddress: "",
        jobTitle: "",
        organization: "",
        address1: "",
        address2: "",
        city: "",
        country: {
            fullName: "",
            code: ""
        },
        stateProvince: "",
        zip: "",
        phone: "",
        phoneExt: "",
        fax: "",
    });

    useEffect(() => {
        const defaultContacts = user?.contacts?.find(c => c.defaultYN === true);
        defaultContacts && setContacts(defaultContacts);
    }, [user?.contacts])

    return (
        <Formik enableReinitialize initialValues={contacts} onSubmit={() => console.log(contacts)}>
            <Form className="ui form">
                <Container fluid>
                    <h1><span style={{ color: "purple" }}>{contacts.addressName}</span> contacts</h1>
                    <Divider horizontal content="Required" />
                    <CustomTextInput name="firstName" placeholder="First name" />
                    <CustomTextInput name="lastName" placeholder="Last name" />
                    <CustomTextInput name="address1" placeholder="Address 1" />
                    <CustomTextInput name="city" placeholder="City" />
                    <CustomTextInput name="country.fullName" placeholder="Country" />
                    <CustomTextInput name="stateProvince" placeholder="State/Province" />
                    <CustomTextInput name="zip" placeholder="Postal Code" />
                    <CustomTextInput name="phone" placeholder="Phone number" />
                    <CustomTextInput type="email" name="emailAddress" placeholder="Email" />
                    <Divider horizontal content="Optional" />
                    <CustomTextInput name="address2" placeholder="Address 2" />
                    <CustomTextInput name="phoneExt" placeholder="Phone extension" />
                    <CustomTextInput name="fax" placeholder="Fax" />
                </Container>
                <Button.Group style={{padding: "5px"}}>
                    <Button fluid positive basic floated="left" content="Save" />
                    <Button fluid basic primary floated="right" content="Back" onClick={() => history.back()} />
                </Button.Group>
            </Form>
        </Formik>
    )
})