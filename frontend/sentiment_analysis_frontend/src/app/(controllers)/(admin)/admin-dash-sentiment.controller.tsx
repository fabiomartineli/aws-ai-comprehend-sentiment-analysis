'use client'

import { useContext, useEffect, useState } from "react";
import { AdminDashSentimentModel } from "@/app/(models)/(admin)/admin-dash-sentiment.model";
import { ChartConfig } from "@/components/ui/chart";
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

export function useAdminDashSentimentController(): AdminDashSentimentModel {
    const dashContext = useContext(AdminDashContext);
    const [state, setState] = useState({
        chartConfig: {} as ChartConfig,
        chartData: [],
        total: 0
    } as AdminDashSentimentModel);

    useEffect(() => {
        async function getSummaryAsync() {
            const response = dashContext.summaryResponse;

            const chartData = [{
                type: "Em análise",
                count: response?.sentiment?.totalInProcessing
            },
            {
                type: "Negativo",
                count: response?.sentiment?.totalNegativeSentiment
            },
            {
                type: "Positivo",
                count: response?.sentiment?.totalPositiveSentiment
            },
            {
                type: "Neutro",
                count: response?.sentiment?.totalNeutralSentiment
            }];

            setState((current) => ({ ...current, chartData, chartConfig, total: response?.sentiment?.total  ?? 0 }));
        };

        getSummaryAsync();
   }, [dashContext.summaryResponse?.sentiment?.total]);

    return state;
}