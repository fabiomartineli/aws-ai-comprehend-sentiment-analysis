import { ChartConfig } from "@/components/ui/chart";

export type AdminDashNegativeModel = {
    chartData: {
        type: string;
        count: number
    }[];

    chartConfig: ChartConfig;
}