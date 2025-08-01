'use client'

import { useContext } from "react";
import { GlobalContext } from "../global.controller";
import { ReviewDrawerModel } from "../../(models)/(review)/review-drawer.model";

export function useReviewDrawerController(): ReviewDrawerModel {
    const context = useContext(GlobalContext);

    return {
        closeDrawer: () => context.setReviewDrawerIsOpen(false),
        drawerIsOpen: context.reviewDrawerIsOpen,
    }
}