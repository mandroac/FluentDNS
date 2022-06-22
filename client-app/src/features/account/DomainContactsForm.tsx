import { Form, Formik } from "formik";
import { observer } from "mobx-react-lite";
import { useEffect, useState } from "react";
import { useParams } from "react-router-dom";
import { Button, Container, Divider } from "semantic-ui-react";
import { DomainContacts } from "../../app/models/domain/domainContacts";
import { useStore } from "../../app/stores/store";
import CustomTextInput from "../../common/form/CustomTextInput";

const contactTypesMap: Map<string, number> = new Map<string, number>([
    ["Admin", 0],
    ["Billing", 1],
    ["Registrant", 2],
    ["Tech", 3]
])

export default observer(function DomainContactsForm() {
    const { domain, contactsType } = useParams<{ domain: string, contactsType: string }>();
    const { userStore: { domains } } = useStore();
    const [contacts, setContacts] = useState<DomainContacts>({
        firstName: "",
        lastName: "",
        address1: "",
        city: "",
        countryName: "",
        stateProvince: "",
        postalCode: "",
        phone: "",
        emailAddress: ""
    });

    useEffect(() => {
        const domainObject = domains.find(d => d.name === domain);
        if (domainObject !== undefined && contactsType) {
            const domainContacts = domainObject.contacts.find(c => c.contactsType === contactTypesMap.get(contactsType));
            if (domainContacts) setContacts(domainContacts);
        }
    }, [domains, contacts, domain, contactsType, setContacts])

    return (
        <Formik enableReinitialize initialValues={contacts} onSubmit={() => console.log(contacts)}>
            <Form className="ui form">
                <Container fluid>
                    <h1>Domain <span style={{ color: "purple" }}>{domain}</span> {contactsType?.toLowerCase()} contacts</h1>
                    <Divider horizontal content="Required" />
                    <CustomTextInput name="firstName" placeholder="First name" />
                    <CustomTextInput name="lastName" placeholder="Last name" />
                    <CustomTextInput name="address1" placeholder="Address 1" />
                    <CustomTextInput name="city" placeholder="City" />
                    <CustomTextInput name="countryName" placeholder="Country" />
                    <CustomTextInput name="stateProvince" placeholder="State/Province" />
                    <CustomTextInput name="postalCode" placeholder="Postal Code" />
                    <CustomTextInput name="phone" placeholder="Phone number" />
                    <CustomTextInput type="email" name="emailAddress" placeholder="Email" />
                    <Divider horizontal content="Optional" />
                    <CustomTextInput name="address2" placeholder="Address 2" />
                    <CustomTextInput name="phoneExt" placeholder="Phone extension" />
                    <CustomTextInput name="fax" placeholder="Fax" />
                </Container>
                <Button.Group style={{padding: "5px"}}>
                    <Button fluid positive basic floated="left" content="Save" />
                    <Button fluid basic primary floated="right" content="Back" />
                </Button.Group>
            </Form>
        </Formik>
    )
})