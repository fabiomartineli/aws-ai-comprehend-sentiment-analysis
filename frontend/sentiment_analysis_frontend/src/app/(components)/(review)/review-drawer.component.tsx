'use client'

import {
    Drawer,
    DrawerContent,
    DrawerDescription,
    DrawerHeader,
    DrawerTitle,
} from "@/components/ui/drawer"
import { ReviewFormHoC } from "../../(hoc)/(review)/review-form.hoc"
import { ReviewDrawerModel } from "../../(models)/(review)/review-drawer.model"

interface Props {
    model: ReviewDrawerModel
}

export function ReviewDrawer({ model }: Props) {
    return (<>
        <Drawer onClose={model.closeDrawer} open={model.drawerIsOpen}>
            <DrawerContent>
                <DrawerHeader>
                    <DrawerTitle>Sua experiência sobre o produto é importante para nós</DrawerTitle>
                    <DrawerDescription>Através dela podemos saber o que devemos melhorar e o que está legal</DrawerDescription>
                </DrawerHeader>
                <div className="pb-20">
                    <ReviewFormHoC />
                </div>
            </DrawerContent>
        </Drawer>
    </>)
}