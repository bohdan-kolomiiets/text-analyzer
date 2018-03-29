import { SharedModule } from './../shared/shared.module';
import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { NavbarComponent } from './components/navbar/navbar.component';
import { HomeComponent } from './components/home/home.component';

@NgModule({
  imports: [
    SharedModule
  ],
  declarations: [NavbarComponent, HomeComponent],
  exports: [NavbarComponent, HomeComponent]
})
export class PublicModule { }
