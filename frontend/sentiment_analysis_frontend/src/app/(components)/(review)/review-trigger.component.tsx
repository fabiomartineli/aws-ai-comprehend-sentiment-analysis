'use client'

import { ReviewTriggerModel } from "../../(models)/(review)/review-trigger.model"


interface Props {
    model: ReviewTriggerModel
}

export function ReviewTrigger({ model }: Props) {
    return (<>
        <button
            onClick={model.openDrawer}
            className="cursor-pointer bg-blue-500 hover:bg-blue-600 text-white font-semibold py-4 px-6 rounded text-center"
        >
            Fazer review
        </button>
    </>)
}