'use client'

import { AdminDashSentiment } from "@/app/(components)/(admin)/admin-dash-sentiment.component";
import { useAdminDashSentimentController } from "@/app/(controllers)/(admin)/admin-dash-sentiment.controller";

export function AdminDashSentimentHoc() {
    const model = useAdminDashSentimentController();

    return (
        <AdminDashSentiment model={model} />
    )
}