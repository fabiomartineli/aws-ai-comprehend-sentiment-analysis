'use client'

import { useTransition } from "react";
import z from "zod";
import { useForm } from "react-hook-form";
import { zodResolver } from "@hookform/resolvers/zod";
import { ReviewFormModel, ReviewFormSchema } from "../../(models)/(review)/review-form.model";
import { IProductService } from "@/services/product/product.service";

interface Props {
    productService: IProductService;
}

export function useReviewFormController(props: Props): ReviewFormModel {
    const [isPending, transition] = useTransition();

    const form = useForm<z.infer<typeof ReviewFormSchema>>({
        resolver: zodResolver(ReviewFormSchema),
        defaultValues: {
            comment: "",
            productName: "",
            userName: "",
        },
    });

    async function handleSubmitAsync(data: z.infer<typeof ReviewFormSchema>): Promise<void> {
        transition(async () => {
            await props.productService.sendReviewAsync({
                ...data,
            })
        });
    }

    return {
        sendingIsPending: isPending,
        form,

        sendReviewAsync: handleSubmitAsync
    }
}