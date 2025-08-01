'use client'

import React from "react";
import { useReviewFormController } from "../../(controllers)/(review)/review-form.controller";
import { ReviewForm } from "../../(components)/(review)/review-form.component";
import { ProductServiceFactory } from "@/services/product/product-factory.service";

const productService = ProductServiceFactory.create();

export function ReviewFormHoC() {
    const model = useReviewFormController({ productService });

    return (<ReviewForm model={model} />)
}