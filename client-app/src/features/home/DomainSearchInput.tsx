import { observer } from "mobx-react-lite";
import { useEffect, useState } from "react";
import { Button, Dropdown, Grid, Input } from "semantic-ui-react";
import { TLD } from "../../app/models/domain/TLD";
import { useStore } from "../../app/stores/store";

type option = {
    key: number;
    text: string;
    value: string;
}

export default observer(function DomainSearchInput() {
    const { tldStore, domainStore } = useStore();
    const { loadGtlds, gtlds, loading } = tldStore;
    const { checkDomainsAvailability, loadingDomainsCheck } = domainStore

    const [options, setOptions] = useState<option[]>([])
    const [TLD, setTLD] = useState<string>()
    const [SLD, setSLD] = useState<string>()

    useEffect(() => {

        if (!gtlds.length) loadGtlds()
        setOptions([])
        gtlds.forEach((tld: TLD, i) => {
            const val = { key: tld.id, value: tld.name, text: "." + tld.name };
            setOptions((prev) => [...prev, val])
            i === 0 && setTLD(val.text)
        });
    }, [loadGtlds, setOptions, gtlds]);

    async function handleDomainsCheck() {
        let domains: string[] = [];
        domains.push(SLD! + TLD);

        gtlds.slice(0, 5).filter(tld => '.' + tld.name !== TLD).forEach(tld => {
            domains.push(SLD! + '.' + tld.name)
        });

        await checkDomainsAvailability(domains);
    }

    return (
        < >
            <Grid>
                <Grid.Column width={14}>
                    <Input size="big" placeholder="Enter Second-Level-Domain"
                        label={<Dropdown
                            onChange={(e, data) => setTLD("." + data.value?.toString())}
                            loading={loading}
                            defaultValue={TLD}
                            placeholder={TLD}
                            options={options}
                            search />}
                        labelPosition="right"
                        onChange={(_, data) => setSLD(data.value)}
                        fluid />
                </Grid.Column>
                <Grid.Column width={2}>
                    <Button size="big" type="submit" content="Check" fluid 
                        onClick={() => handleDomainsCheck()} 
                        loading={loadingDomainsCheck}
                        />
                </Grid.Column>
            </Grid>
        </>
    )
})