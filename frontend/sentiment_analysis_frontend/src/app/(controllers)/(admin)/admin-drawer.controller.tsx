'use client'

import { useContext } from "react";
import { GlobalContext } from "../global.controller";
import { AdminDrawerModel } from "@/app/(models)/(admin)/admin-drawer.model";

export function useAdminDrawerController(): AdminDrawerModel {
    const context = useContext(GlobalContext);

    return {
        closeDrawer: () => context.setAdminDrawerIsOpen(false),
        drawerIsOpen: context.adminDrawerIsOpen,
    }
}