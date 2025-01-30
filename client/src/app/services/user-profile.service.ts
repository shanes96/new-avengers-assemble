import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class UserProfileService {
  private apiUrl = 'http://localhost:5236/api/userprofile';

  constructor(private http: HttpClient) { }

  getUserProfiles(): Observable<any> {
    return this.http.get<any>(this.apiUrl);
  }

  // Optionally add POST, PUT, DELETE functions here for updating the profile
}
