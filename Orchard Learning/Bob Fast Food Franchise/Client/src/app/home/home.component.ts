import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { ToastrService } from 'ngx-toastr';
import { LocalStorageService } from '../services/local-storage.service';

@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
  styleUrls: ['./home.component.css'],
})
export class HomeComponent implements OnInit {
  userData: any;
  constructor(
    private localStorageService: LocalStorageService,
    private router: Router,
    private toaster: ToastrService
  ) {
    try {
      this.userData = this.localStorageService.getData('@userData');
      if (!this.userData) {
        this.router.navigateByUrl('');
      }
    } catch (error) {
      this.toaster.error('Something went wrong');
      this.router.navigateByUrl('');
    }
  }

  ngOnInit(): void {}
}
