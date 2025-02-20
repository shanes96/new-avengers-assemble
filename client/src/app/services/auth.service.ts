import { Injectable } from '@angular/core';

@Injectable({
  providedIn: 'root',
})
export class AuthService {

  private API_URL = 'http://localhost:5236/api/auth';

  constructor() {}

  login = async (email: string, password: string): Promise<string | null> => {
    try {
      const response = await fetch(`${this.API_URL}/login`, {
        method: 'POST',
        headers: {
          'Content-Type': 'application/json',
        },
        body: JSON.stringify({ email, password }),
      });
  
      const data = await response.json();
  
      if (response.ok) {
        localStorage.setItem('auth_token', data.token);
        return data.token;
      } else {
        console.error('Login failed:', data.message);
        return null;
      }
    } catch (error) {
      console.error('Login error:', error);
      return null;
    }
  };

  logout = () => {
    localStorage.removeItem('auth_token');
    window.location.href = '/login'; 
  };

  isAuthenticated = (): boolean => {
    return !!localStorage.getItem('auth_token');
  };

  // Get the JWT token
  getAuthToken = (): string | null => {
    return localStorage.getItem('auth_token');
  };

  // Fetch user data from the backend
  fetchUserData = async (): Promise<any> => {
    const token = this.getAuthToken();
    if (!token) throw new Error('No token found');
    const response = await fetch('http://localhost:5236/api/user/profile', {
      headers: {
        'Authorization': `Bearer ${token}`,
      },
    });
    if (!response.ok) throw new Error('Failed to fetch user data');
    return await response.json();
  };
}
