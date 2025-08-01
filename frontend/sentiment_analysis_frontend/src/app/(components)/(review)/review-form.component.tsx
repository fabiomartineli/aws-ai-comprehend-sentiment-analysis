'use client'

import {
    Form,
    FormControl,
    FormDescription,
    FormField,
    FormItem,
    FormLabel,
    FormMessage,
} from "@/components/ui/form"
import { ReviewFormModel } from "../../(models)/(review)/review-form.model";
import { Input } from "@/components/ui/input";
import { Button } from "@/components/ui/button";
import { Textarea } from "@/components/ui/textarea";

interface Props {
    model: ReviewFormModel
}

export function ReviewForm({ model }: Props) {
    return (<>
        <Form {...model.form}>
            <form 
                onSubmit={model.form.handleSubmit(model.sendReviewAsync)} 
                className="w-2/3 space-y-6 pl-16 pr-16">
                <FormField
                    control={model.form.control}
                    name="userName"
                    render={({ field }) => (
                        <FormItem>
                            <FormLabel>Seu nome</FormLabel>
                            <FormControl>
                                <Input {...field} />
                            </FormControl>
                            <FormDescription>
                                Essa informação é importante para, caso seja necessário entender melhor o caso, entrarmos em contato
                            </FormDescription>
                            <FormMessage />
                        </FormItem>
                    )}
                />
                <FormField
                    control={model.form.control}
                    name="productName"
                    render={({ field }) => (
                        <FormItem>
                            <FormLabel>Produto</FormLabel>
                            <FormControl>
                                <Input {...field} />
                            </FormControl>
                            <FormMessage />
                        </FormItem>
                    )}
                />
                <FormField
                    control={model.form.control}
                    name="comment"
                    render={({ field }) => (
                        <FormItem>
                            <FormLabel>Descreva como foi sua experiência</FormLabel>
                            <FormControl>
                                <Textarea {...field} />
                            </FormControl>
                            <FormDescription>
                                Conte para a gente o que foi bom e o que não foi tão bom assim
                            </FormDescription>
                            <FormMessage />
                        </FormItem>
                    )}
                />
                <Button disabled={model.sendingIsPending}
                    className="bg-blue-500 hover:bg-blue-600"
                    type="submit">
                        {model.sendingIsPending ? "Enviando..." : "Enviar"}
                </Button>
            </form>
        </Form>
    </>)
}