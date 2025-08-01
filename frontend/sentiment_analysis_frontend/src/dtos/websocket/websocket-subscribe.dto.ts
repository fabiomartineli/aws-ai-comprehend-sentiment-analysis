export type WebSocketSubscribeRequestDto = {
    callback(payload: any): void;
    eventName: string;
}