import { observer } from "mobx-react-lite";
import React, { useState } from "react";
import { Button, Dropdown, Grid, Input, Segment, Table } from "semantic-ui-react";
import { number } from "yup";
import { HostRecord } from "../../app/models/dns/hostRecord";
import { useStore } from "../../app/stores/store";

interface Props {
    records?: HostRecord[];
    isUsingOurDNS?: boolean;
}
const recordTypeOptions = [
    { key: "A", value: "A", text: "A" },
    { key: "CNAME", value: "CNAME", text: "CNAME" },
    { key: "TXT", value: "TXT", text: "TXT" },
    { key: "URL", value: "URL", text: "URL 302" },
    { key: "URL301", value: "URL301", text: "URL 301" },
    { key: "FRAME", value: "FRAME", text: "Frame" },
]
export default observer(function DomainHostsTable({ records, isUsingOurDNS }: Props) {
    const { dnsStore: { editHostRecord, addHostRecord, removeHostRecord, saveHostRecords, loadingRecordsSave } } = useStore();
    const [editHost, setEditHost] = useState<HostRecord | null>(null);
    const [editableRowId, setEditableRowId] = useState<number | null>(null);

    function setEditMode(mode: boolean, recordId: number | null) {
        if (mode) {
            const currentRecord = records?.find(r => r.id == recordId) as HostRecord
            setEditHost(currentRecord);
            setEditableRowId(recordId);
        } else {
            setEditHost(null);
            setEditableRowId(null)
        }
    }

    function handleEditRecord() {
        editHostRecord(editHost!);
        setEditMode(false, null);
    }

    function handleAddRecordClick() {
        let lastId = 0;
        records?.forEach(r => {
            if (r.id && r.id > lastId) lastId = r.id
        })

        const recordPrototype: HostRecord = { id: ++lastId, name: "", address: "", type: "A", ttl: 1800, mxPref: 10 };
        addHostRecord(recordPrototype)
        setEditMode(true, recordPrototype.id)
    }

    return (
        <>
            {!isUsingOurDNS ?
                <>
                    <Table striped style={{ fontSize: 12, textAlign: "center" }} tableData={records}>
                        <Table.Header>
                            <Table.Row>
                                <Table.HeaderCell>
                                    Host
                                </Table.HeaderCell>
                                <Table.HeaderCell>
                                    Type
                                </Table.HeaderCell>
                                <Table.HeaderCell>
                                    Value
                                </Table.HeaderCell>
                                <Table.HeaderCell>
                                    TTL
                                </Table.HeaderCell>
                                <Table.HeaderCell />
                            </Table.Row>
                        </Table.Header>
                        <Table.Body>
                            {records?.map(record => (
                                editableRowId === record.id ?
                                    <Table.Row key={record.id}>
                                        <Table.Cell width={3}>
                                            <Input defaultValue={editHost?.name} fluid
                                                onChange={e => setEditHost({ ...editHost, name: e.target.value } as HostRecord)} />
                                        </Table.Cell>
                                        <Table.Cell width={3}>
                                            <Dropdown defaultValue={editHost?.type} fluid selection options={recordTypeOptions}
                                                onChange={(e, val) => setEditHost({ ...editHost, type: val.value } as HostRecord)} />
                                        </Table.Cell>
                                        <Table.Cell width={6}>
                                            <Input defaultValue={editHost?.address} fluid
                                                onChange={e => setEditHost({ ...editHost, address: e.target.value } as HostRecord)} />
                                        </Table.Cell>
                                        <Table.Cell width={3}>
                                            <Input defaultValue={editHost?.ttl} fluid type="number"
                                                onChange={e => setEditHost({ ...editHost, ttl: parseInt(e.target.value) } as HostRecord)} />
                                        </Table.Cell>
                                        <Table.Cell width={2}>
                                            <Button.Group>
                                                <Button color="green" inverted icon="check" floated="right" onClick={() => handleEditRecord()} />
                                                <Button color="red" inverted icon="cancel" floated="right" onClick={() => setEditMode(false, null)} />
                                            </Button.Group>
                                        </Table.Cell>
                                    </Table.Row>
                                    :
                                    <Table.Row key={record.id}>
                                        <Table.Cell width={3}>
                                            {record.name}
                                        </Table.Cell>
                                        <Table.Cell width={3}>
                                            {record.type}
                                        </Table.Cell>
                                        <Table.Cell width={6}>
                                            {record.address}
                                        </Table.Cell>
                                        <Table.Cell width={3}>
                                            {record.ttl}
                                        </Table.Cell>
                                        <Table.Cell width={2}>
                                            <Button.Group>
                                                <Button icon="edit" floated="right" onClick={() => setEditMode(true, record.id)} />
                                                <Button icon="trash alternate" floated="right" onClick={() => removeHostRecord(record.id!)} />
                                            </Button.Group>
                                        </Table.Cell>
                                    </Table.Row>
                            ))}
                        </Table.Body>
                    </Table>
                    <Button content="Add record" basic circular onClick={() => handleAddRecordClick()} />
                    <Button loading={loadingRecordsSave} content="Save all" basic positive circular onClick={() => saveHostRecords()} />
                </> :
                <Segment>
                    This domain is using third-party nameservers
                </Segment>
            }
        </>
    )
})