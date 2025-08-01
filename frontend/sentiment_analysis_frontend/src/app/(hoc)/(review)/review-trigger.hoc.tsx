'use client'

import React from "react";
import { useReviewTriggerController } from "../../(controllers)/(review)/review-trigger.controller";
import { ReviewTrigger } from "../../(components)/(review)/review-trigger.component";

export function ReviewTriggerHoC() {
    const model = useReviewTriggerController();

    return (<ReviewTrigger model={model} />)
}