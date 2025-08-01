import { ChartConfig } from "@/components/ui/chart";

export type AdminDashPositiveModel = {
    chartData: {
        type: string;
        count: number
    }[];

    chartConfig: ChartConfig;
}