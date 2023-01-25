import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { FoodShop } from '../models/food-shop.model';

@Injectable({
  providedIn: 'root',
})
export class AdminService {
  foodShopApi: string = 'https://localhost:44340/api/FoodShop';

  foodShopData: FoodShop = new FoodShop();
  foodShopList: FoodShop[];

  constructor(private http: HttpClient) {}

  getFoodShops(): Observable<FoodShop[]> {
    return this.http.get<FoodShop[]>(this.foodShopApi);
  }

  addFoodShop(): Observable<FoodShop> {
    return this.http.post<FoodShop>(this.foodShopApi, this.foodShopData);
  }
  updateFoodShop(): Observable<FoodShop> {
    return this.http.put<FoodShop>(this.foodShopApi, this.foodShopData);
  }

  getFoodShop(id: number): Observable<FoodShop> {
    return this.http.get<FoodShop>(`${this.foodShopApi}/${id}`);
  }

  deleteFoodShop(id: number) {
    return this.http.delete(`${this.foodShopApi}/${id}`);
  }
}
