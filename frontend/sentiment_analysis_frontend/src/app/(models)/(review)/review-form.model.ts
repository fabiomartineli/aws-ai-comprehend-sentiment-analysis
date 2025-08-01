import { UseFormReturn } from "react-hook-form";
import z from "zod";

export const ReviewFormSchema = z.object({
    productName: z.string()
        .min(5, {
            message: "Nome do produto deve conter no mínimo 5 caracteres.",
        }),
    comment: z.string()
        .min(10, {
            message: "O comentário para a review deve conter no mínimo 10 caracteres.",
        }),
    userName: z.string()
        .min(5, {
            message: "Seu nome deve conter no mínimo 5 caracteres.",
        }),
});

export type ReviewFormModel = {
    sendingIsPending: boolean;
    form: UseFormReturn<z.infer<typeof ReviewFormSchema>>;
    sendReviewAsync(data: z.infer<typeof ReviewFormSchema>): Promise<void>;
}