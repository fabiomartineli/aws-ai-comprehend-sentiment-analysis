'use client'

import { useContext } from "react";
import { useGlobalController } from "../global.controller";
import { ReviewTriggerModel } from "../../(models)/(review)/review-trigger.model";
import { WebSocketServiceFactory } from "@/services/websocket/websocket-factory.service";

const webSocketService = WebSocketServiceFactory.create();

export function useReviewTriggerController(): ReviewTriggerModel {
    const globalController = useGlobalController({ webSocketService });
    const context = useContext(globalController.context);

    return {
        openDrawer: () => context.setReviewDrawerIsOpen(true),
    }
}