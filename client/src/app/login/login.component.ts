import { Component } from '@angular/core';
import { AuthService } from '../services/auth.service';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.css']
})
export class LoginComponent {
  email: string = '';
  password: string = '';
  errorMessage: string = '';

  constructor(private authService: AuthService) {}

  login() {
    this.authService.login(this.email, this.password)
      .then(token => {
        if (token) {
          console.log('Login successful!', token);
          // Redirect to the dashboard or homepage after successful login
          // this.router.navigate(['/dashboard']); // Use Angular router to navigate
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
