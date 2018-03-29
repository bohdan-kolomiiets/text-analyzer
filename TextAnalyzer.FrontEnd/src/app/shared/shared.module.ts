import { HttpClient } from './services/http-client.service';
import { DataService } from './services/data.service';
import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { BrowserModule } from '@angular/platform-browser';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { ReactiveFormsModule, FormsModule } from '@angular/forms';
import { RouterModule } from '@angular/router';
import { HttpModule } from '@angular/http';

@NgModule({
  imports: [
    HttpModule,
    
    BrowserModule,
    CommonModule,
    RouterModule,
    BrowserAnimationsModule,
    ReactiveFormsModule,
    FormsModule
  ],
  declarations: [
  ],
  providers: [
    DataService,
    HttpClient
  ],
  exports: [
    BrowserModule,
    CommonModule,
    RouterModule,
    BrowserAnimationsModule,
    ReactiveFormsModule,
    FormsModule,
  ]
})
export class SharedModule { }
