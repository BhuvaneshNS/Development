import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { LoginCredential } from '../models/login-credential';
import { User } from '../models/user';

@Injectable({
  providedIn: 'root',
})
export class AuthService {
  private loginApiEndPoint = 'https://localhost:44340/api/UserAuth/login';
  private registerApiEndPoint = 'https://localhost:44340/api/UserAuth/register';

  constructor(private http: HttpClient) {}

  authenticateUser(userCredentials: LoginCredential): Observable<User> {
    return this.http.post<User>(this.loginApiEndPoint, userCredentials);
  }

  registerUser(user: User): Observable<User> {
    console.log('User in service', typeof user.roleId);

    user.roleId = Number(user.roleId);

    return this.http.post<User>(this.registerApiEndPoint, user);
  }
}
