'use client'

import { useAdminDashController } from "@/app/(controllers)/(admin)/admin-dash.controller";
import { ProductServiceFactory } from "@/services/product/product-factory.service";

const productService = ProductServiceFactory.create();

interface Props {
    children: React.ReactNode;
}

export function AdminDashHoc({ children }: Props) {
    const model = useAdminDashController({ productService });

    return (
        <model.context.Provider value={{ ...model }}>
            {children}
        </model.context.Provider>
    )
}