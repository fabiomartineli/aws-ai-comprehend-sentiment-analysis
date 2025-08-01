import { Context } from "react";

export type GlobalModel = {
    reviewDrawerIsOpen: boolean;
    adminDrawerIsOpen: boolean;
    context: Context<GlobalModel>;

    setReviewDrawerIsOpen(value: boolean): void;
    setAdminDrawerIsOpen(value: boolean): void;
}