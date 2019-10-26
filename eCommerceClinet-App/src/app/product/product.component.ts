import { Component, OnInit } from '@angular/core';
import { FormBuilder } from '@angular/forms';

import { CategoryService } from '../shared/category.service';
import { ProductService } from '../shared/product.service';

@Component({
  selector: 'app-product',
  templateUrl: './product.component.html',
  styleUrls: ['./product.component.css']
})
export class ProductComponent implements OnInit {

  constructor(
    private fb: FormBuilder,
    private catergoryService: CategoryService,
    private productService: ProductService) { }

  ngOnInit() {
  }

}
