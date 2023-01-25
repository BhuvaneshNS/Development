import { Component, OnInit } from '@angular/core';
import { NgForm } from '@angular/forms';
import { Router } from '@angular/router';
import { ToastrService } from 'ngx-toastr';
import { LoginCredential } from '../models/login-credential';
import { AuthService } from '../services/auth.service';
import { LocalStorageService } from '../services/local-storage.service';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.css'],
})
export class LoginComponent implements OnInit {
  loginCredential: LoginCredential = {
    emailId: '',
    password: '',
  };

  constructor(
    private authService: AuthService,
    private localStorageService: LocalStorageService,
    private toaster: ToastrService,
    private router: Router
  ) {}

  ngOnInit(): void {
    console.log('login-oninit');
  }
  login(loginForm: NgForm): void {
    this.authService.authenticateUser(loginForm.value).subscribe({
      next: (data: any) => {
        console.log(data);
        if (
          this.localStorageService.saveData('@userData', data?.personDetails)
        ) {
          this.router.navigate(['/home']);
          this.toaster.success('Login success');
        } else {
          this.toaster.error('Something went wrong login failed');
        }
      },
      error: (err) => {
        console.log('Error', err?.error);
        this.toaster.error(err?.error);
      },
    });
  }
}
