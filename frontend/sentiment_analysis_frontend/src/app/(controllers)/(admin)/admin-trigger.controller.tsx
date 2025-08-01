'use client'

import { useContext } from "react";
import { useGlobalController } from "../global.controller";
import { AdminTriggerModel } from "@/app/(models)/(admin)/admin-trigger.model";
import { WebSocketServiceFactory } from "@/services/websocket/websocket-factory.service";

const webSocketService = WebSocketServiceFactory.create();

export function useAdminTriggerController(): AdminTriggerModel {
    const globalController = useGlobalController({ webSocketService });
    const context = useContext(globalController.context);

    return {
        openDrawer: () => context.setAdminDrawerIsOpen(true),
    }
}