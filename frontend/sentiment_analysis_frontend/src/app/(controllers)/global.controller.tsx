'use client'

import { createContext, useEffect, useState } from 'react';
import { GlobalModel } from '../(models)/global.model';
import { IWebSocketService } from '@/services/websocket/websocket.service';
import { NotificationService } from '@/services/notification/notification.service';
import { WebSocketProductAnalyzedDto } from '@/dtos/websocket/websocket-product-analyzed.dto';

interface Props {
    webSocketService: IWebSocketService;
}

export const GlobalContext = createContext<GlobalModel>({} as GlobalModel);

export function useGlobalController(props: Props): GlobalModel {
    const [reviewDrawerIsOpen, setReviewDrawerIsOpen] = useState(false);
    const [adminDrawerIsOpen, setAdminDrawerIsOpen] = useState(false);

    useEffect(() => {
        props?.webSocketService.startAsync();
        props?.webSocketService.subscribe({
            eventName: "newcommentanalyzed",
            callback: (payload) => {
                const data = payload as WebSocketProductAnalyzedDto;
                NotificationService.showWithAction({
                    title: data.title,
                    description: data.description,
                    type: "info",
                    actionLabel: "Portal",
                    actionAsync: async () => {
                        setReviewDrawerIsOpen(false);
                        setAdminDrawerIsOpen(true);
                    }
                })
            }
        });

        return () => {
            props?.webSocketService.closeAsync()
        };
    }, []);

    return {
        setReviewDrawerIsOpen,
        setAdminDrawerIsOpen,

        reviewDrawerIsOpen,
        adminDrawerIsOpen,
        context: GlobalContext,
    }
}