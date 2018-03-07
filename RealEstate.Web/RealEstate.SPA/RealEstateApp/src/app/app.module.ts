import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';

import { RouterModule, Routes } from '@angular/router';
import { FormsModule } from '@angular/forms';
import { HttpModule } from '@angular/http';

import { AppComponent } from './app.component';

import { PropertyDetailComponent } from './components/property-detail/property-detail.component';
import { SidebarComponent } from './components/sidebar/sidebar.component';
import { DashboardComponent } from './components/dashboard/dashboard.component';
import { PropertiesComponent } from './components/properties/properties.component';
import { EditPropertyComponent } from './components/edit-property/edit-property.component';
import { NavbarComponent } from './components/navbar/navbar.component';
import { DataService } from './services/data.service';

const appRoutes: Routes = [
  { path: '', component: DashboardComponent },
  { path: 'Properties', component: PropertiesComponent},
  { path: 'EditProperty', component: EditPropertyComponent }
];

@NgModule({
  declarations: [
    AppComponent,
    PropertyDetailComponent, SidebarComponent, DashboardComponent, PropertiesComponent, EditPropertyComponent, NavbarComponent
  ],
  imports: [
    BrowserModule,
    RouterModule.forRoot(appRoutes),
    FormsModule,
    HttpModule
  ],
  providers: [DataService],
  bootstrap: [AppComponent]
})
export class AppModule { }
