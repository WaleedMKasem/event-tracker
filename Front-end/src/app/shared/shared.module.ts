import { HelperService } from './helper.service';
import { RouterModule } from '@angular/router';
import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { SafePipe } from './safe.pipe';

@NgModule({
  imports: [
    CommonModule
  ],
  declarations: [ SafePipe ],
  exports:[ SafePipe ],
  providers: [
    HelperService
  ]
})

export class SharedModule { }
