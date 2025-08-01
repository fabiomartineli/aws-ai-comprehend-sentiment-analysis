'use client'

import { AdminTriggerModel } from "@/app/(models)/(admin)/admin-trigger.model"


interface Props {
    model: AdminTriggerModel
}

export function AdminTrigger({ model }: Props) {
    return (<>
        <button
            onClick={model.openDrawer}
            className="cursor-pointer bg-blue-500 hover:bg-blue-600 text-white font-semibold py-4 px-6 rounded text-center"
        >
            Acessar relatórios
        </button>
    </>)
}