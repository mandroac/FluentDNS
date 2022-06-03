import React, { useEffect, useState } from "react";
import { List } from "semantic-ui-react";
import agent from "../../api/agent";
import LoadingComponent from "../../app/layout/LoadingComponent";
import { DomainPrice } from "../../app/models/DomainPrice";

export default function Home() {
    const [loading, setLoading] = useState(true);
    const [pricing, setPricing] = useState<DomainPrice[]>([]);

    useEffect(() => {
        agent.Domains.defaultPricing().then(response => {
            setPricing(response);
            console.log(response);
        }).catch(error => () => {
            console.log(error);
        }).finally(() => setLoading(false))
}, []);

if (loading) return <LoadingComponent content="Loading pricing..." />
return (
    <List>
        {pricing.map((price: DomainPrice) => (
            <List.Item key={price.id} content={price.tld + ' ' + price.register} />
        ))}
    </List>
)
}