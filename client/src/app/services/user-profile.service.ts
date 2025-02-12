import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class UserProfileService {
  private apiUrl = 'http://localhost:5236/api/userprofile';
  private userComicsUrl = 'http://localhost:5236/api/usercomics';
  private userMoviesUrl = 'http://localhost:5236/api/usermovies';

  constructor(private http: HttpClient) { }

  getUserProfiles(): Observable<any> {
    return this.http.get<any>(this.apiUrl);
  }

  getUserProfile(userId: number): Observable<any> {
    return this.http.get<any>(`${this.apiUrl}/${userId}`);
  }

  getUserComics(userId: number): Observable<any> {
    return this.http.get<any>(`${this.userComicsUrl}/${userId}`);
  }

  getUserMovies(userId: number): Observable<any> {
    return this.http.get<any>(`${this.userMoviesUrl}/${userId}`);
  }
}