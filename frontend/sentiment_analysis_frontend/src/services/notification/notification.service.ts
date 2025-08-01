'use client'

import { NotificationWithAction } from '@/dtos/notification/notification-with-action.dto';
import { ExternalToast, toast } from 'sonner';

export class NotificationService {
    static showWithAction(request: NotificationWithAction) {
        const settings = {
            description: request.description,
            richColors: true,
            closeButton: true,
            action: {
                label: request.actionLabel,
                onClick: request.actionAsync
            },
            position: "top-right",
            duration: 5000
        } as ExternalToast;

        switch (request.type) {
            case 'success':
                toast.success(request.title, settings);
                break;
            case 'error':
                toast.error(request.title, settings);
                break;
            case 'info':
                toast.info(request.title, settings);
                break;
            case 'warning':
                toast.warning(request.title, settings);
                break;
        }
    }
}