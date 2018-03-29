import { HomeComponent } from './public/components/home/home.component';
import { ApplicationListComponent } from './applications/components/application-list/application-list.component';
import { RuleListComponent } from './rules/components/rule-list/rule-list.component';
import { DataListComponent } from './texts/components/data-list/data-list.component';
import { Routes, RouterModule } from "@angular/router";
import { ModuleWithProviders } from "@angular/core";

export const ROUTES: Routes = [
    { path: '', redirectTo: 'home', pathMatch: 'full' },
    { path: 'home', component: HomeComponent },
    { path: 'texts', component: DataListComponent },
    { path: 'rules', component: RuleListComponent },
    { path: 'applications', component: ApplicationListComponent },
];

export const ROUTING: ModuleWithProviders = RouterModule.forRoot(ROUTES);
