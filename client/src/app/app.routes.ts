import { Routes } from '@angular/router';
import { UserProfileComponent } from './components/user-profile/user-profile.component';
import { NavbarComponent } from './components/navbar/navbar.component';

export const routes: Routes = [
  { path: 'profile', component: UserProfileComponent }, 
];
