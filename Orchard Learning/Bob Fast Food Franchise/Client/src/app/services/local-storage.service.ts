import { Injectable } from '@angular/core';

@Injectable({
  providedIn: 'root',
})
export class LocalStorageService {
  constructor() {}

  saveData(key: string, value: Object): boolean {
    try {
      localStorage.setItem(key, JSON.stringify(value));
      return true;
    } catch (error) {
      console.log(error);
      return false;
    }
  }

  getData(key: string): any {
    try {
      let data = localStorage.getItem(key);
      if (data) {
        data = JSON.parse(data);
      }
      return data;
    } catch (error) {
      return false;
    }
  }
}
