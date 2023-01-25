import { Component, OnInit, ViewChild } from '@angular/core';
import { FormControl, FormGroup, Validators } from '@angular/forms';
import { ToastrService } from 'ngx-toastr';
import { FoodShop } from '../models/food-shop.model';
import { AdminService } from '../services/admin.service';

@Component({
  selector: 'app-admin',
  templateUrl: './admin.component.html',
  styleUrls: ['./admin.component.css'],
})
export class AdminComponent implements OnInit {
  @ViewChild('closebutton') closebutton: any;
  foodShopForm: FormGroup;
  cities = ['Coorg', 'Mysore', 'Bangalore', 'Mangalore'];
  formHeaderToggle: boolean = false;

  constructor(
    public adminService: AdminService,
    private toaster: ToastrService
  ) {
    this.foodShopForm = new FormGroup({
      fastFoodShopId: new FormControl(0),
      fastFoodShopName: new FormControl('', Validators.required),
      city: new FormControl('', Validators.required),
      phoneNumber: new FormControl('', [
        Validators.required,
        Validators.pattern('^[6-9]\\d{9}$'),
      ]),
    });
  }

  ngOnInit(): void {
    this.getFoodShops();
  }

  getFoodShops() {
    this.adminService.getFoodShops().subscribe({
      next: (responseData) => {
        this.adminService.foodShopList = responseData;
      },
      error: (error) => {
        console.log(error.error);
      },
    });
  }

  get fastFoodShopName() {
    return this.foodShopForm.get('fastFoodShopName');
  }
  get city() {
    return this.foodShopForm.get('city');
  }
  get phoneNumber() {
    return this.foodShopForm.get('phoneNumber');
  }

  onSubmit() {
    console.log(this.foodShopForm.value);

    this.adminService.foodShopData = this.foodShopForm.value;
    if (this.formHeaderToggle) {
      this.adminService.updateFoodShop().subscribe({
        next: (responseData) => {
          console.log(responseData);
          this.getFoodShops();
          this.toaster.success('FoodShop Updated Successfully');
        },
        error: (error) => {
          console.log(error.error);
          this.toaster.error(error.error || 'Something went wrong');
        },
      });
    } else {
      this.adminService.addFoodShop().subscribe({
        next: (responseData) => {
          console.log(responseData);
          this.getFoodShops();
          this.toaster.success('FoodShop Added Successfully');
        },
        error: (error) => {
          console.log(error.error);
          this.toaster.error(error.error || 'Something went wrong');
        },
      });
    }
    this.closebutton.nativeElement.click();
    this.adminService.foodShopData = new FoodShop();
    this.foodShopForm.reset();
  }
  onAddClick() {
    this.formHeaderToggle = false;
  }

  onDeleteClick(id: any) {
    if (confirm('Are sure you want to delete this item ?')) {
      this.adminService.deleteFoodShop(id).subscribe({
        next: () => {
          this.getFoodShops();
          this.toaster.warning('FoodShop Deleted Successfully');
        },
        error: (error) => {
          console.log(error.error);
          this.toaster.error(error.error || 'Something went wrong');
        },
      });
    }
  }

  onEditClick(shopId: any) {
    this.formHeaderToggle = true;
    this.adminService.getFoodShop(shopId).subscribe({
      next: (responseData) => {
        this.foodShopForm.setValue(responseData);
      },
      error: (error) => {
        console.error(error.error);
        this.toaster.error(error.error || 'Something went wrong');
      },
    });
  }
}
