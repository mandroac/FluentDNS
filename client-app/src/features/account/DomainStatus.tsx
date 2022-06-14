import React from "react";
import { Grid, Label } from "semantic-ui-react";

interface Props{
    now: Date;
    expiration: Date;
}

export default function DomainStatus({now, expiration}: Props) {
    const _MS_PER_DAY = 1000 * 60 * 60 * 24;
    const days = Math.floor((new Date(expiration).getTime() - new Date(now).getTime()) / _MS_PER_DAY);
    
    return (<>
        <Grid>
            <Grid.Row>
                <Grid.Column width={4}>
                    {days >= 30 ?
                        <Label color="olive" content="ACTIVE" />
                        : (days > 0 ?
                            <Label color="yellow" content="EXPIRING" />
                            : <Label color="red" content="EXPIRED" />
                        )
                    }
                </Grid.Column>
                <Grid.Column width={12}>
                    {days >= 0 ?
                        <p><strong>Expires</strong> in {days} days</p>
                        : <p><strong>Expired</strong> {-days} days ago</p>
                    }
                </Grid.Column>
            </Grid.Row>
        </Grid>
    </>)
}