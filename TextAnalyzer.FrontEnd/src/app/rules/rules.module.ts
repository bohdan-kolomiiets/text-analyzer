import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { SharedModule } from '../shared/shared.module';
import { RuleFormComponent } from './components/rule-form/rule-form.component';
import { RuleViewComponent } from './components/rule-view/rule-view.component';
import { RuleListComponent } from './components/rule-list/rule-list.component';

@NgModule({
  imports: [
    SharedModule
  ],
  declarations: [RuleFormComponent, RuleViewComponent, RuleListComponent]
})
export class RulesModule { }
