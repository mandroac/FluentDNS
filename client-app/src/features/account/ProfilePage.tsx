import { observer } from "mobx-react-lite";
import { Tab } from "semantic-ui-react";
import { useStore } from "../../app/stores/store";
import ProfileDomains from "./ProfileDomains";
import ProfileHeader from "./ProfileHeader";
import ProfileSettings from "./ProfileSettings";
import UserContactsTab from "./UserContactsTab";

export default observer(function ProfilePage() {
    const { userStore: { setActivePane } } = useStore();
    const panes = [
        { menuItem: { key: 'domains', icon: 'globe', content: 'Domains'}, render: () => <ProfileDomains /> },
        { menuItem: { key: 'contacts', icon: 'address card', content: 'Contacts'}, render: () => <UserContactsTab /> },
        { menuItem: { key: 'settings', icon: 'settings', content: 'Settings'} , render: () => <ProfileSettings /> }
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