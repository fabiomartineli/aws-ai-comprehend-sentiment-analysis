import { EnvironmentVariablesService } from "../environment/variables.service";
import { IWebSocketService, WebSocketService } from "./websocket.service";

export class WebSocketServiceFactory {
    private static _service: IWebSocketService | null = null;

    static create() {

        if (this._service === null) {
            console.log("Creating WebSocketService...");
            
            const baseUrl = EnvironmentVariablesService.getWebSocketApiBaseUrl();
            this._service = new WebSocketService(baseUrl);
        }

        return this._service;
    }
}