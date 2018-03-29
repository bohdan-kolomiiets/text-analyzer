import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { SharedModule } from '../shared/shared.module';
import { DataFormComponent } from './components/data-form/data-form.component';
import { DataViewComponent } from './components/data-view/data-view.component';
import { DataListComponent } from './components/data-list/data-list.component';

@NgModule({
  imports: [
    SharedModule
  ],
  declarations: [DataFormComponent, DataViewComponent, DataListComponent],
  exports: [DataFormComponent, DataViewComponent, DataListComponent]
})
export class TextsModule { }
