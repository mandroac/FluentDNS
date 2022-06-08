import { observer } from "mobx-react-lite";
import React from "react";
import { List, Segment, Tab } from "semantic-ui-react";
import { useStore } from "../../app/stores/store";
import ProfileDomains from "./ProfileDomains";
import ProfileHeader from "./ProfileHeader";
import ProfileSettings from "./ProfileSettings";

export default observer(function ProfilePage() {
    const { userStore: { setActivePane } } = useStore();
    const panes = [
        { menuItem: 'Domains', render: () => <ProfileDomains /> },
        { menuItem: 'Settings', render: () => <ProfileSettings /> }
    ]

    return (
        <>
            <ProfileHeader />
            <Tab
                grid={{ paneWidth: 12, tabWidth: 4, textAlign: "center" }}
                menu={{ fluid: true, vertical: true }}
                menuPosition="left"
                panes={panes}
                onTabChange={(e, data) => setActivePane(data.activeIndex)}
            />
        </>

    )
})