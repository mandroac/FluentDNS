import { observer } from "mobx-react-lite";
import { Fragment, useEffect, useMemo, useState } from "react";
import { Button, Dropdown, Grid, Input, Segment } from "semantic-ui-react";
import { TLD } from "../../app/models/TLD";
import { useStore } from "../../app/stores/store";

type option = {
    key: number;
    text: string;
    value: string;
}

export default observer(function DomainSearchInput() {
    const { tldStore } = useStore();
    const { loadGtlds, gtlds, loading } = tldStore;
    const [options, setOptions] = useState<option[]>([])
    const [activeTLD, setActiveTLD] = useState<string>()

    useEffect(() => {
        if (!gtlds.length) loadGtlds()

        gtlds.forEach((tld: TLD, i) => {
            const val = { key: tld.id, value: tld.name, text: "." + tld.name };
            setOptions((prev) => [...prev, val])
            i === 0 && setActiveTLD(val.text)
        });
    }, [loadGtlds, setOptions]);

    return (
        < >
            <Grid>
                <Grid.Column width={14}>
                    <Input placeholder="Search Domain"
                        label={<Dropdown
                            onChange={(e, data) => console.log(data.value)}
                            loading={loading}
                            defaultValue={activeTLD}
                            placeholder={activeTLD}
                            options={options}
                            search />}
                        labelPosition="right"
                        fluid />
                </Grid.Column>
                <Grid.Column width={2}>
                    <Button type="submit" content="Check" fluid/>
                </Grid.Column>
            </Grid>
        </>
    )
})