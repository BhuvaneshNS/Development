import { Location } from '@angular/common';
import { Component, OnInit } from '@angular/core';
import {
  FormBuilder,
  FormControl,
  FormGroup,
  Validators,
} from '@angular/forms';
import { Router } from '@angular/router';
import { ToastrService } from 'ngx-toastr';
import { User } from '../models/user';
import { AuthService } from '../services/auth.service';

@Component({
  selector: 'app-register',
  templateUrl: './register.component.html',
  styleUrls: ['./register.component.css'],
})
export class RegisterComponent implements OnInit {
  registrationForm: FormGroup;

  userRoles = [
    { id: 1, name: 'Admin' },
    { id: 2, name: 'User' },
  ];

  cities = ['Coorg', 'Mysore', 'Bangalore', 'Mangalore'];
  constructor(
    private formBuilder: FormBuilder,
    private authService: AuthService,
    private toaster: ToastrService,
    private router: Router,
    private location: Location
  ) {
    this.registrationForm = new FormGroup({
      personName: new FormControl('', [
        Validators.required,
        Validators.pattern('^[\\w\\s]+$'),
      ]),
      password: new FormControl('', [
        Validators.required,
        Validators.minLength(3),
      ]),
      emailId: new FormControl('', [Validators.required, Validators.email]),
      personCity: new FormControl('', Validators.required),
      roleId: new FormControl('', Validators.required),
    });
  }

  ngOnInit(): void {
    console.log('reg-oninit');
  }

  get personName() {
    return this.registrationForm.get('personName');
  }
  get password() {
    return this.registrationForm.get('password');
  }
  get emailId() {
    return this.registrationForm.get('emailId');
  }
  get personCity() {
    return this.registrationForm.get('personCity');
  }
  get roleId() {
    return this.registrationForm.get('roleId');
  }
  // onChangeUserRole(e: any) {
  //   this.roleId?.setValue(e.target.value, {
  //     onlySelf: true,
  //   });
  // }
  register() {
    this.authService.registerUser(this.registrationForm.value).subscribe({
      next: (response: User) => {
        this.toaster.success('Registration successfull');
        // this.location.back();
        this.router.navigateByUrl('');
      },
      error: (err) => {
        console.log(err.error);
        this.toaster.error(err.error);
      },
    });
  }
}
