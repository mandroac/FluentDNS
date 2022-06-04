import React from "react";
import { Button, Grid, Icon, Label, Segment } from "semantic-ui-react";
import { DomainCheckResult } from "../../app/models/DomainCheckResult";

interface Props {
    domainCheckResult: { check: DomainCheckResult, price: number | undefined }
}

export default function MainDomainCheckResult({ domainCheckResult }: Props) {
    return (
        <Segment>
            <Grid>
                <Grid.Row>
                    <Grid.Column width={1}>
                        {domainCheckResult.check.available ?
                            <Icon name="check circle" size="big" color="green" /> :
                            <Icon name="times circle" size="big" color="red" />
                        }
                    </Grid.Column>
                    <Grid.Column width={6}>
                        <h2>{domainCheckResult.check.domain}</h2>
                    </Grid.Column>
                    <Grid.Column width={7}>
                        {domainCheckResult.check.isPremiumName &&
                            <Label basic color="yellow" content={"PREMIUM"} />
                        }
                        {domainCheckResult.check.available ?
                            <Label basic color="green"
                                content={`Register at \$${domainCheckResult.check.isPremiumName ?
                                    domainCheckResult.check.premiumRegistrationPrice :
                                    domainCheckResult.price}`}
                            /> :
                            <Label basic color="grey" content={"Taken"} />
                        }
                    </Grid.Column>
                    <Grid.Column width={2}>
                        <Button fluid content="Register"
                            positive={domainCheckResult.check.available}
                            disabled={!domainCheckResult.check.available} />
                    </Grid.Column>
                </Grid.Row>
            </Grid>
        </Segment>
    )
}