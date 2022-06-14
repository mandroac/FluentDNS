import { observer } from "mobx-react-lite";
import { Link } from "react-router-dom";
import { Button, Grid, Icon, Label, Segment } from "semantic-ui-react";
import { DomainPriceResult } from "../../app/stores/domainStore";
import { useStore } from "../../app/stores/store";

interface Props {
    domainPriceResult: DomainPriceResult
}

export default observer(function MainDomainCheckResult({ domainPriceResult }: Props) {
    const {domainStore : {setSelectedPriceResult}} = useStore()
    return (
        <Segment>
            <Grid>
                <Grid.Row>
                    <Grid.Column width={1}>
                        {domainPriceResult.check.available ?
                            <Icon name="check circle" size="big" color="green" /> :
                            <Icon name="times circle" size="big" color="red" />
                        }
                    </Grid.Column>
                    <Grid.Column width={6}>
                        <h2>{domainPriceResult.check.domain}</h2>
                    </Grid.Column>
                    <Grid.Column width={7}>
                        {domainPriceResult.check.isPremiumName &&
                            <Label basic color="yellow" content={"PREMIUM"} />
                        }
                        {domainPriceResult.check.available ?
                            <Label basic color="green"
                                content={`Register at \$${domainPriceResult.registerPrice}`}
                            /> :
                            <Label basic color="grey" content={"Taken"} />
                        }
                    </Grid.Column>
                    <Grid.Column width={2}>
                        <Button fluid content="Register" as={Link} to={`register`}
                            positive={domainPriceResult.check.available}
                            disabled={!domainPriceResult.check.available}
                            onClick={() => setSelectedPriceResult(domainPriceResult)} />
                    </Grid.Column>
                </Grid.Row>
            </Grid>
        </Segment>
    )
})