import { observer } from "mobx-react-lite";
import { useEffect, useState } from "react";
import { Button, Container, Dropdown, DropdownProps, Grid, Input } from "semantic-ui-react";
import DomainFullDnsDetails from "../../app/models/dns/domainFullDnsDetails";
import { useStore } from "../../app/stores/store";

interface Props {
    dnsDetails: DomainFullDnsDetails | null;
}

interface IndexedNameserver {
    id: number;
    nameserver: string;
}

const NameserversOptions = [
    { key: "Basic DNS", value: "Basic DNS", text: "Basic DNS" },
    { key: "Custom DNS", value: "Custom DNS", text: "Custom DNS" }
]

export default observer(function NameserversEditor({ dnsDetails }: Props) {
    const {dnsStore: {setCustom, setDefault, loadingNameserversSave}} = useStore()
    const [selectedNameservers, setSelectedNameservers] = useState("Basic DNS");
    const [editableCustomNameservers, setEditableCustomNameservers] = useState<IndexedNameserver[]>([]);
    const [hasChanges, setHasChanges] = useState(false);

    useEffect(() => {
        if (dnsDetails) {
            if (dnsDetails.nameservers.length === 2
                && dnsDetails.nameservers.includes("dns1.registrar-servers.com")
                && dnsDetails.nameservers.includes("dns2.registrar-servers.com")) {
                setSelectedNameservers("Basic DNS")
            }
            else {
                setSelectedNameservers("Custom DNS");
                intializeIndexedNameservers(dnsDetails.nameservers)
            }
        }
        else setSelectedNameservers("Basic DNS")
    }, [dnsDetails]);

    function handleDropDownEdit(props: DropdownProps) {
        setSelectedNameservers(props.value as string);
        if (dnsDetails && props.value === "Custom DNS") {
            if (dnsDetails.isUsingOurDNS) intializeIndexedNameservers(["", ""])
            else intializeIndexedNameservers(dnsDetails.nameservers)
        }

        if(dnsDetails?.isUsingOurDNS && props.value === "Basic DNS") setHasChanges(false)
        else setHasChanges(true);
    }

    function editCustomNameserver(nameserver: string, id: number) {
        const index = editableCustomNameservers.findIndex(x => x.id === id);
        setEditableCustomNameservers(editableCustomNameservers.map(item =>
            item.id === index
                ? { ...item, nameserver: nameserver }
                : item));
        setHasChanges(true);
    }

    function intializeIndexedNameservers(nameservers: string[]) {
        let buffer = new Array<IndexedNameserver>();
        let cnt = 0;
        nameservers.forEach(ns => buffer.push({ id: cnt++, nameserver: ns }));
        setEditableCustomNameservers(buffer)
    }

    function handleAddNameserver() {
        let lastId = 0;
        editableCustomNameservers?.forEach(ns => {
            if (ns.id && ns.id > lastId) lastId = ns.id
        })
        const nameserver: IndexedNameserver = { id: ++lastId, nameserver: "" };
        setEditableCustomNameservers([...editableCustomNameservers, nameserver]);
        console.log(editableCustomNameservers);
    }

    function handleSaveChanges() {
        if(selectedNameservers === "Custom DNS"){
            const nameservers = editableCustomNameservers.map(ns => ns.nameserver);
            setCustom(nameservers).then(() => setHasChanges(false));
        } else {
            setDefault().then(() => setHasChanges(false));
        }
    }

    return (
        <Grid>
            <Grid.Row>
                <Dropdown fluid selection
                    options={NameserversOptions}
                    value={selectedNameservers}
                    onChange={(e, val) => handleDropDownEdit(val)} />
            </Grid.Row>
            {selectedNameservers === "Custom DNS" &&
                <>
                    {editableCustomNameservers.map(ns => (
                        <Container style={{ padding: "2px" }} key={ns.id}>
                            <Input placeholder="Nameserver" value={ns.nameserver} fluid
                                onChange={e => editCustomNameserver(e.target.value, ns.id)} />
                        </Container>
                    ))}
                    <Button basic circular content="Add nameserver" onClick={() => handleAddNameserver()} />
                </>
            }
            {hasChanges &&
                    <Button basic circular positive 
                        content="Save changes" loading={loadingNameserversSave}
                        onClick={() => handleSaveChanges()} />
            }
        </Grid>
    )
})