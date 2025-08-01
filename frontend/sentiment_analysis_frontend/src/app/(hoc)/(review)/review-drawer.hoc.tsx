'use client'

import React from "react";
import { useReviewDrawerController } from "../../(controllers)/(review)/review-drawer.controller";
import { ReviewDrawer } from "../../(components)/(review)/review-drawer.component";

export function ReviewDrawerHoC() {
    const model = useReviewDrawerController();

    return (<ReviewDrawer model={model} />)
}