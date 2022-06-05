import { Form, Formik } from "formik";
import { observer } from "mobx-react-lite";
import React from "react";
import { useState } from "react";
import { Button, Container, Divider, Grid, Icon, Label, Radio, Segment, Table } from "semantic-ui-react";
import { history } from "../..";
import { DomainRegisterFormValues, DomainRegisterModel } from "../../app/models/domainRegisterModel";
import { useStore } from "../../app/stores/store";
import CustomTextInput from "../../common/form/CustomTextInput";
import * as Yup from 'yup';

export default observer(function RegisterDomainPage() {
    const { domainStore: { selectedPriceResult, register } } = useStore();
    const [domainFormValues] = useState<DomainRegisterFormValues>(new DomainRegisterFormValues());
    const [isDomainPrivacy, setIsDomainPrivacy] = useState(true);

    const validationSchema = Yup.object({
        firstName: Yup.string().required().max(60),
        lastName: Yup.string().required().max(60),
        address1: Yup.string().required().max(50),
        city: Yup.string().required().max(50),
        country: Yup.string().required().max(50),
        stateProvince: Yup.string().required().max(60),
        postalCode: Yup.string().required().max(20),
        phone: Yup.string().matches(/\+[0-9]{1,3}\.[0-9]{5,10}/, "Phone number must be filled in format +NNN.NNNNNNNNNN"),
        emailAddress: Yup.string().required().email()
    })

    async function handleSubmit(domainFormValues: DomainRegisterFormValues) {
        
        const registerDomainModel: DomainRegisterModel = {
            domainName: selectedPriceResult!.check.domain,
            years: domainFormValues.years,
            addFreeWhoisguard: domainFormValues.domainPrivacy ? 'Yes' :'No',
            wgEnabled: domainFormValues.domainPrivacy ? 'Yes' :'No',
            registrant: {
                firstName: domainFormValues.firstName,
                lastName: domainFormValues.lastName,
                address1: domainFormValues.address1,
                city: domainFormValues.city,
                country: domainFormValues.country,
                stateProvince: domainFormValues.stateProvince,
                postalCode: domainFormValues.postalCode,
                phone: domainFormValues.phone,
                emailAddress: domainFormValues.emailAddress,
                address2: domainFormValues.address2,
                phoneExt: domainFormValues.phoneExt,
                fax: domainFormValues.fax
            }, tech: {
                firstName: domainFormValues.firstName,
                lastName: domainFormValues.lastName,
                address1: domainFormValues.address1,
                city: domainFormValues.city,
                country: domainFormValues.country,
                stateProvince: domainFormValues.stateProvince,
                postalCode: domainFormValues.postalCode,
                phone: domainFormValues.phone,
                emailAddress: domainFormValues.emailAddress,
                address2: domainFormValues.address2,
                phoneExt: domainFormValues.phoneExt,
                fax: domainFormValues.fax
            }, admin: {
                firstName: domainFormValues.firstName,
                lastName: domainFormValues.lastName,
                address1: domainFormValues.address1,
                city: domainFormValues.city,
                country: domainFormValues.country,
                stateProvince: domainFormValues.stateProvince,
                postalCode: domainFormValues.postalCode,
                phone: domainFormValues.phone,
                emailAddress: domainFormValues.emailAddress,
                address2: domainFormValues.address2,
                phoneExt: domainFormValues.phoneExt,
                fax: domainFormValues.fax
            }, billing: {
                firstName: domainFormValues.firstName,
                lastName: domainFormValues.lastName,
                address1: domainFormValues.address1,
                city: domainFormValues.city,
                country: domainFormValues.country,
                stateProvince: domainFormValues.stateProvince,
                postalCode: domainFormValues.postalCode,
                phone: domainFormValues.phone,
                emailAddress: domainFormValues.emailAddress,
                address2: domainFormValues.address2,
                phoneExt: domainFormValues.phoneExt,
                fax: domainFormValues.fax
            }
        } 
        await register(registerDomainModel);
    }

    return (
        <>
            <Segment style={{ textAlign: "center" }}>
                <Grid columns={3}>
                    <Grid.Row>
                        <Grid.Column width={1}>
                            {selectedPriceResult?.check.isPremiumName &&
                                <Icon name="star" color="yellow" size="big" />
                            }
                        </Grid.Column>
                        <Grid.Column width={7}>
                            <h2>Register <span style={{ color: "#9e1395" }} >{selectedPriceResult?.check.domain}</span> domain</h2>
                        </Grid.Column>
                        <Grid.Column width={8}>
                            <Label basic color="green" content={`Register at ${selectedPriceResult?.registerPrice}/yr.`} />
                            <Label basic color="yellow" content={`Renew at ${selectedPriceResult?.renewPrice}/yr.`} />
                            {selectedPriceResult?.redemptionPrice &&
                                <Label basic color="red" content={`Restore at ${selectedPriceResult?.redemptionPrice}/yr.`} />
                            }
                        </Grid.Column>
                    </Grid.Row>
                </Grid>
            </Segment>

            <Segment placeholder>
                <Formik
                    initialValues={domainFormValues}
                    onSubmit={(values) => handleSubmit(values)}
                    validationSchema={validationSchema}>
                    {({ handleSubmit, isValid, isSubmitting, dirty }) => (
                        <Form className="ui form" onSubmit={handleSubmit}>
                            <Grid columns={2} textAlign="center" verticalAlign="top">
                                <Grid.Column>
                                    <h3>Base settings</h3>
                                    <Table definition>
                                        <Table.Body>
                                            <Table.Row>
                                                <Table.Cell width={7} content={"Years: "} />
                                                <Table.Cell width={7} content={1} />
                                            </Table.Row>
                                            <Table.Row>
                                                <Table.Cell width={7} content={"Domain Privacy: "} />
                                                <Table.Cell width={7} content={
                                                    <Radio name="domainPrivacy" toggle
                                                        label={isDomainPrivacy ? "Disabled" : "Enabled"}
                                                        onChange={() => setIsDomainPrivacy(!isDomainPrivacy)} />} />
                                            </Table.Row>
                                            <Table.Row>
                                                <Table.Cell width={7} content={"Nameservers: "} />
                                                <Table.Cell width={7} content={"Basic DNS"} />
                                            </Table.Row>
                                        </Table.Body>
                                    </Table>
                                </Grid.Column>
                                <Grid.Column >
                                    <h3>Registrant contacts</h3>
                                    <Container fluid>
                                        <Divider horizontal content="Required" />
                                        <CustomTextInput name="firstName" placeholder="First name" />
                                        <CustomTextInput name="lastName" placeholder="Last name" />
                                        <CustomTextInput name="address1" placeholder="Address 1" />
                                        <CustomTextInput name="city" placeholder="City" />
                                        <CustomTextInput name="country" placeholder="Country" />
                                        <CustomTextInput name="stateProvince" placeholder="State/Province" />
                                        <CustomTextInput name="postalCode" placeholder="Postal Code" />
                                        <CustomTextInput name="phone" placeholder="Phone number" />
                                        <CustomTextInput type="email" name="emailAddress" placeholder="Email" />
                                        <Divider horizontal content="Optional" />
                                        <CustomTextInput name="address2" placeholder="Address 2" />
                                        <CustomTextInput name="phoneExt" placeholder="Phone extension" />
                                        <CustomTextInput name="fax" placeholder="Fax" />
                                    </Container>
                                </Grid.Column>
                            </Grid>
                            <Grid>
                                <Grid.Row>
                                    <Grid.Column width={8}>
                                        <Button disabled={isSubmitting || !dirty || !isValid}
                                            loading={isSubmitting} positive
                                            size="large" type="submit" animated="fade"
                                            fluid>
                                            <Button.Content visible>Register</Button.Content>
                                            <Button.Content hidden>${selectedPriceResult?.registerPrice} per year</Button.Content>
                                        </Button>
                                    </Grid.Column>
                                    <Grid.Column width={8}>
                                        <Button type="button" content="Cancel"
                                            fluid size="large" onClick={() => history.back()} />
                                    </Grid.Column>
                                </Grid.Row>
                            </Grid>
                        </Form>
                    )}
                </Formik>
                <Divider vertical />
            </Segment>
        </>
    )
})