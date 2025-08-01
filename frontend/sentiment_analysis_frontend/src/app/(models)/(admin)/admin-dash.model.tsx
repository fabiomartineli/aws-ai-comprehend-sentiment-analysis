import { ReviewSummaryResponseDto } from "@/dtos/product/review-summary.dto";
import { Context } from "react";

export type AdminDashModel = {
    summaryResponse: ReviewSummaryResponseDto;
    context: Context<AdminDashModel>;
}