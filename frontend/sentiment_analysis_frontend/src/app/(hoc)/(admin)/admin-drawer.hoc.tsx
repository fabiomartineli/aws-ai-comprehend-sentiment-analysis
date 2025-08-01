'use client'

import { AdminDrawer } from "@/app/(components)/(admin)/admin-drawer.component";
import { useAdminDrawerController } from "@/app/(controllers)/(admin)/admin-drawer.controller";

export function AdminDrawerHoc() {
    const model = useAdminDrawerController();

    return (
        <AdminDrawer model={model}/>
    )
}