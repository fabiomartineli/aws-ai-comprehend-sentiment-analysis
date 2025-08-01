import { EnvironmentVariablesService } from "../environment/variables.service";
import { IProductService, ProductService } from "./product.service";

export class ProductServiceFactory {
    private static _service: IProductService | null = null;

    static create() {

        if (this._service === null) {
            console.log("Creating ProductService...");
            
            const baseUrl = EnvironmentVariablesService.getProductApiBaseUrl();
            this._service = new ProductService(baseUrl);
        }

        return this._service;
    }
}