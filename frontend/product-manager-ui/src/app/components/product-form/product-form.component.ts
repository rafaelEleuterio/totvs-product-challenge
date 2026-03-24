import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, ReactiveFormsModule } from '@angular/forms';
import { ProductService } from '../../services/product.service';
import { ActivatedRoute, Router, RouterLink } from '@angular/router';
import { CommonModule } from '@angular/common';

@Component({
  selector: 'app-product-form',
  standalone: true,
  imports: [CommonModule, ReactiveFormsModule, RouterLink],
  templateUrl: './product-form.component.html'
})
export class ProductFormComponent implements OnInit {

  form: FormGroup;
  id: string | null = null;

  constructor(
    private fb: FormBuilder,
    private service: ProductService,
    private router: Router,
    private route: ActivatedRoute
  ) {
    this.form = this.fb.group({
      name: [''],
      price: [0],
      stock: [0]
    });
  }

  ngOnInit(): void {
    this.id = this.route.snapshot.paramMap.get('id');

    if (this.id) {
      this.service.getById(this.id).subscribe(product => {
        this.form.patchValue(product);
      });
    }
  }

  submit() {
    if (this.id) {
      // UPDATE
      this.service.update(this.id, this.form.value).subscribe(() => {
        this.router.navigate(['/']);
      });
    } else {
      // CREATE
      this.service.create(this.form.value).subscribe(() => {
        this.router.navigate(['/']);
      });
    }
  }
}