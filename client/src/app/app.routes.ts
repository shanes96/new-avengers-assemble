import { Routes } from '@angular/router';
import { UserProfileComponent } from './components/user-profile/user-profile.component';
import { LoginComponent } from './login/login.component';

export const routes: Routes = [
  { path: 'profile', component: UserProfileComponent }, 
  { path: 'login', component: LoginComponent}
];
