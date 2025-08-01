'use client'

import { useContext, useEffect, useState } from "react";
import { ChartConfig } from "@/components/ui/chart";
import { AdminDashPositiveModel } from "@/app/(models)/(admin)/admin-dash-positive.model";
import { AdminDashContext } from "./admin-dash.controller";

const chartConfig = {
    count: {
        label: "Total",
        color: "#2563eb",
    },
    label: {
        color: "var(--background)"
    }
} as ChartConfig;

export function useAdminDashPositiveController(): AdminDashPositiveModel {
    const dashContext = useContext(AdminDashContext);
    const [state, setState] = useState({
        chartConfig: {} as ChartConfig,
        chartData: [],
    } as AdminDashPositiveModel);

    useEffect(() => {
        async function getSummaryAsync() {
            if (dashContext.summaryResponse?.topPositiveProducts?.length > 0) {
                const response = dashContext.summaryResponse;

                const chartData = response?.topPositiveProducts?.map(x => ({
                    type: x.productName,
                    count: x.count
                }));

                setState((current) => ({ ...current, chartData, chartConfig }));
            }
        };

        getSummaryAsync();
    }, [dashContext.summaryResponse?.topPositiveProducts?.length]);

    return state;
}