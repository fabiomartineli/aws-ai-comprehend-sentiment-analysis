'use client'

import { AdminDashPositive } from "@/app/(components)/(admin)/admin-dash-positive.component";
import { useAdminDashPositiveController } from "@/app/(controllers)/(admin)/admin-dash-positive.controller";

export function AdminDashPositiveHoc() {
    const model = useAdminDashPositiveController();

    return (
        <AdminDashPositive model={model} />
    )
}