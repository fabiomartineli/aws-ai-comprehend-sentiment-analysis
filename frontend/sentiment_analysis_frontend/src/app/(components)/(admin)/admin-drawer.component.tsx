'use client'

import {
    Drawer,
    DrawerContent,
    DrawerDescription,
    DrawerHeader,
    DrawerTitle,
} from "@/components/ui/drawer"
import { AdminDrawerModel } from "@/app/(models)/(admin)/admin-drawer.model"
import { AdminDashSentimentHoc } from "@/app/(hoc)/(admin)/admin-dash-sentiment.hoc"
import { AdminDashNegativeHoc } from "@/app/(hoc)/(admin)/admin-dash-negative.hoc"
import { AdminDashPositiveHoc } from "@/app/(hoc)/(admin)/admin-dash-positive.hoc"
import { AdminDashHoc } from "@/app/(hoc)/(admin)/admin-dash.hoc"

interface Props {
    model: AdminDrawerModel
}

export function AdminDrawer({ model }: Props) {
    return (<>
        <Drawer onClose={model.closeDrawer} open={model.drawerIsOpen}>
            <DrawerContent>
                <DrawerHeader>
                    <DrawerTitle>Dados referentes às avaliações dos produtos</DrawerTitle>
                    <DrawerDescription>Ranking de sentimento e de produtos</DrawerDescription>
                </DrawerHeader>
                <div className="flex justify-center align-middle m-20 gap-16">
                    <AdminDashHoc>
                        <AdminDashSentimentHoc />
                        <AdminDashPositiveHoc />
                        <AdminDashNegativeHoc />
                    </AdminDashHoc>
                </div>
            </DrawerContent>
        </Drawer>
    </>)
}