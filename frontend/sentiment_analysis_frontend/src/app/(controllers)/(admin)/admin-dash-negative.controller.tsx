'use client'

import { useContext, useEffect, useState } from "react";
import { ChartConfig } from "@/components/ui/chart";
import { AdminDashContext } from "./admin-dash.controller";
import { AdminDashNegativeModel } from "@/app/(models)/(admin)/admin-dash-negative.model";

const chartConfig = {
    count: {
        label: "Total",
        color: "#2563eb",
    },
    label: {
        color: "var(--background)"
    }
} as ChartConfig;

export function useAdminDashNegativeController(): AdminDashNegativeModel {
    const dashContext = useContext(AdminDashContext);
    const [state, setState] = useState({
        chartConfig: {} as ChartConfig,
        chartData: [],
    } as AdminDashNegativeModel);

    useEffect(() => {
        async function getSummaryAsync() {
            if (dashContext.summaryResponse?.topNegativeProducts?.length > 0) {
                const response = dashContext.summaryResponse;

                const chartData = response?.topNegativeProducts?.map(x => ({
                    type: x.productName,
                    count: x.count
                }));

                setState((current) => ({ ...current, chartData, chartConfig }));
            }
        };

        getSummaryAsync();
    }, [dashContext.summaryResponse?.topNegativeProducts?.length]);

    return state;
}