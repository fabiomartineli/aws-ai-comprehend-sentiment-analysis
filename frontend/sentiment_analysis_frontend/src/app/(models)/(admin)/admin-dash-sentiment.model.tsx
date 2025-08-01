import { ChartConfig } from "@/components/ui/chart";

export type AdminDashSentimentModel = {
    chartData: {
        type: string;
        count: number
    }[];

    chartConfig: ChartConfig;
    
    total: number;
}