'use client'

import { createContext, useEffect, useState } from "react";
import { IProductService } from "@/services/product/product.service";
import { ReviewSummaryResponseDto } from "@/dtos/product/review-summary.dto";
import { AdminDashModel } from "@/app/(models)/(admin)/admin-dash.model";

interface Props {
    productService: IProductService;
}

export const AdminDashContext = createContext<AdminDashModel>({} as AdminDashModel);

export function useAdminDashController(props: Props): AdminDashModel {
    const [summary, setSummary] = useState({} as ReviewSummaryResponseDto);

    useEffect(() => {
        async function getSummaryAsync() {
            const response = await props.productService.reviewSummaryAsync();
            setSummary(response);
        };

        getSummaryAsync();
    }, []);

    return {
        summaryResponse: summary,
        context: AdminDashContext
    }
}