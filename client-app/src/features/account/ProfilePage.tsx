import { observer } from "mobx-react-lite";
import React from "react";
import { List } from "semantic-ui-react";
import { useStore } from "../../app/stores/store";

export default observer(function ProfilePage() {
    const {userStore: {domains, user}} = useStore();

    return (
        <List>
            {domains.map(domain => (
                <List.Item content={`${domain.name} + ${domain.expirationDate}`} />                    
            ))}
        </List>
    )
})