import { Component } from '@angular/core';
import { AuthService } from '../services/auth.service';
import { CardModule } from 'primeng/card';
import { ToggleButtonModule } from 'primeng/togglebutton';
import { ButtonModule } from 'primeng/button';
import { Router } from '@angular/router';
import { FormsModule } from '@angular/forms';



@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.css'],
  imports: [CardModule,ToggleButtonModule, ButtonModule, FormsModule]
})
export class LoginComponent {
  email: string = '';
  password: string = '';
  errorMessage: string = '';

  constructor(private authService: AuthService , private router:Router) {}

  login() {
    this.authService.login(this.email, this.password)
      .then(token => {
        if (token) {
          console.log('Login successful!', token);
          this.router.navigate(['/profile']); 
        } else {
          this.errorMessage = 'Login failed. Please check your credentials.';
        }
      })
      .catch(error => {
        console.error('Login error:', error);
        this.errorMessage = 'An error occurred. Please try again later.';
      });
  }
}
