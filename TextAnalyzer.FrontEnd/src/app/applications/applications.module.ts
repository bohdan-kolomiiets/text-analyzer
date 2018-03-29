import { SharedModule } from './../shared/shared.module';
import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { ApplicationListComponent } from './components/application-list/application-list.component';
import { ApplicationViewComponent } from './components/application-view/application-view.component';
import { ApplicationFormComponent } from './components/application-form/application-form.component';

@NgModule({
  imports: [
    SharedModule
  ],
  declarations: [ApplicationListComponent, ApplicationViewComponent, ApplicationFormComponent]
})
export class ApplicationsModule { }
