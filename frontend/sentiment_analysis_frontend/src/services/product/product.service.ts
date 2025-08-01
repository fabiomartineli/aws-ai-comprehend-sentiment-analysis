import { ReviewSendRequestDto } from "@/dtos/product/review-send.dto";
import { ReviewSummaryResponseDto } from "@/dtos/product/review-summary.dto";
import { BaseService } from "../base.service";

export interface IProductService {
    sendReviewAsync(dto: ReviewSendRequestDto): Promise<boolean>;
    reviewSummaryAsync(): Promise<ReviewSummaryResponseDto>;
}

export class ProductService extends BaseService implements IProductService {
    private readonly URL: string = '';

    constructor(baseUrl: string) {
        super();
        this.URL = baseUrl;
    }

    async sendReviewAsync(dto: ReviewSendRequestDto): Promise<boolean> {
        const response = await super.sendRequestWithoutResponseAsync(`${this.URL}:review`, {
            method: "POST",
            body: JSON.stringify(dto)
        });

        return response;
    }

    async reviewSummaryAsync(): Promise<ReviewSummaryResponseDto> {
        const response = await super.sendRequestWithResponseAsync<ReviewSummaryResponseDto>(`${this.URL}:review-summary`, {
            method: "GET",
        });

        return response ?? {
            sentiment: {} as any,
            topNegativeProducts: [],
            topPositiveProducts: []
        } as ReviewSummaryResponseDto;
    }
}