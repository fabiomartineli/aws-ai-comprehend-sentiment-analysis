'use client'

import { AdminDashNegative } from "@/app/(components)/(admin)/admin-dash-negative.component";
import { useAdminDashNegativeController } from "@/app/(controllers)/(admin)/admin-dash-negative.controller";

export function AdminDashNegativeHoc() {
    const model = useAdminDashNegativeController();

    return (
        <AdminDashNegative model={model} />
    )
}