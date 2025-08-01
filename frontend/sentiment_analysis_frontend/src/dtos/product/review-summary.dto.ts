export type ReviewSummaryResponseDto = {
   sentiment: {
      totalNegativeSentiment: number;
      totalPositiveSentiment: number;
      totalNeutralSentiment: number;
      totalInProcessing: number;
      total: number;
   },
   topNegativeProducts: {
      productName: string;
      count: number;
   }[];
   topPositiveProducts: {
      productName: string;
      count: number;
   }[];
}