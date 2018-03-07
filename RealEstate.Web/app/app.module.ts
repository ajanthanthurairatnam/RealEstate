import { NgModule }      from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';

import { AppComponent } from './app.component';
import { SandboxComponent } from './components/sandbox.component.js'

@NgModule({
  imports:      [ BrowserModule ],
    declarations: [AppComponent, SandboxComponent ],
    bootstrap: [AppComponent, SandboxComponent ]
})
export class AppModule { }
