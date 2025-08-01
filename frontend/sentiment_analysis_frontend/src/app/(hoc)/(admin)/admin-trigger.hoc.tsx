'use client'

import React from "react";
import { useAdminTriggerController } from "@/app/(controllers)/(admin)/admin-trigger.controller";
import { AdminTrigger } from "@/app/(components)/(admin)/admin-trigger.component";

export function AdminTriggerHoC() {
    const model = useAdminTriggerController();

    return (<AdminTrigger model={model} />)
}