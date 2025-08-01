export class EnvironmentVariablesService {
    static getProductApiBaseUrl(): string {
        return process.env.NEXT_PUBLIC_URL_PRODUCT_API_URL!;
    }

    static getWebSocketApiBaseUrl(): string {
        return process.env.NEXT_PUBLIC_URL_WEBSOCKET_API_URL!;
    }
}