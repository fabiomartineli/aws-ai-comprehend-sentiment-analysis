import { WebSocketSubscribeRequestDto } from '@/dtos/websocket/websocket-subscribe.dto';
import { HubConnection, HubConnectionBuilder, HubConnectionState, LogLevel } from '@microsoft/signalr';

export interface IWebSocketService {
    startAsync(): Promise<void>;
    closeAsync(): Promise<void>;
    subscribe(request: WebSocketSubscribeRequestDto): void;
}

export class WebSocketService implements IWebSocketService {
    private readonly _url: string;
    private _connection: HubConnection | null = null;

    constructor(url: string) {
        this._url = url;
    }

    async startAsync(): Promise<void> {
        if (this._connection === null) {
            this._connection = new HubConnectionBuilder()
                .withUrl(`${this._url}`, {
                    withCredentials: false
                })
                .configureLogging(LogLevel.Debug)
                .withStatefulReconnect()
                .withAutomaticReconnect([1000, 2000, 4000, 8000, 16000])
                .build();
        }

        if (this._connection.state === HubConnectionState.Disconnected) {
            await this._connection.start();
        }
    }

    async closeAsync(): Promise<void> {
        await this._connection?.stop();
    }

    subscribe(request: WebSocketSubscribeRequestDto): void {
        this._connection?.on(request.eventName, (payload) => {
            request.callback(payload);
        });
    }
}