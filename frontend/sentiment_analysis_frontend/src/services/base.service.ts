export abstract class BaseService {
    protected async sendRequestWithResponseAsync<TResponse>(url: string, request: RequestInit): Promise<TResponse | null> {
        try {
            const response = await fetch(url, {
                method: request.method,
                body: request.body,
                headers: {
                    ...request.headers,
                    "Content-Type": "application/json"
                }
            });

            if (response.ok) {
                const data = await response.json();
                return data as TResponse;
            }

            return null;
        }
        catch (error) {
            console.error(error);

            return null;
        }
    }

    protected async sendRequestWithoutResponseAsync(url: string, request: RequestInit): Promise<boolean> {
        try {
            const response = await fetch(url, {
                method: request.method,
                body: request.body,
                headers: {
                    ...request.headers,
                    "Content-Type": "application/json"
                }
            });

            return response.ok;
        }
        catch (error) {
            console.error(error);

            return false;
        }
    }
}