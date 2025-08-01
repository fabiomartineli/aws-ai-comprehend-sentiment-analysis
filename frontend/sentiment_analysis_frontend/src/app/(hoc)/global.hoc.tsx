'use client'

import { WebSocketServiceFactory } from '@/services/websocket/websocket-factory.service';
import { useGlobalController } from '../(controllers)/global.controller';
import { Toaster } from 'sonner';

interface Props {
    children: React.ReactNode;
}

const webSocketService = WebSocketServiceFactory.create();

export function GlobalHoC(props: Props) {
    const { context: Context, ...model } = useGlobalController({
        webSocketService
    });

    return (<>
        <Context.Provider value={{ ...model, context: Context }}>
            {props.children}
        </Context.Provider>
        <Toaster richColors expand visibleToasts={3} />
    </>)
}