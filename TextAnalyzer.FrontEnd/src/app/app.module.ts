import { PublicModule } from './public/public.module';
import { ApplicationsModule } from './applications/applications.module';
import { RulesModule } from './rules/rules.module';
import { BrowserModule } from '@angular/platform-browser';
import { NgModule, NO_ERRORS_SCHEMA, CUSTOM_ELEMENTS_SCHEMA } from '@angular/core';

import { ROUTING } from './app.routing';

import { AppComponent } from './app.component';
import { SharedModule } from './shared/shared.module';
import { TextsModule } from './texts/texts.module';


@NgModule({
  declarations: [
    AppComponent
  ],
  imports: [
    SharedModule,
    ROUTING,

    PublicModule,
    TextsModule,
    RulesModule,
    ApplicationsModule,
  ],
  providers: [],
  bootstrap: [AppComponent],
  schemas: [
    NO_ERRORS_SCHEMA,
    CUSTOM_ELEMENTS_SCHEMA
  ]
})
export class AppModule { }
