import { Component, OnInit } from '@angular/core';
import { UserProfileService } from '../../services/user-profile.service';
import { CommonModule } from '@angular/common';
import { AvatarModule } from 'primeng/avatar';
import { CarouselModule } from 'primeng/carousel';
import { ButtonModule } from 'primeng/button';
import { BadgeModule } from 'primeng/badge';
import { OverlayBadgeModule } from 'primeng/overlaybadge';
import { TabViewModule } from 'primeng/tabview';
import { InputSwitchModule } from 'primeng/inputswitch';
import { CardModule } from 'primeng/card';
import { ToggleButtonModule } from 'primeng/togglebutton';


@Component({
  selector: 'app-user-profile',
  templateUrl: './user-profile.component.html',
  styleUrls: ['./user-profile.component.css'],
  standalone: true,
  imports: [CommonModule, AvatarModule, CarouselModule, ButtonModule, BadgeModule, OverlayBadgeModule, TabViewModule, InputSwitchModule, CardModule, ToggleButtonModule],
})
export class UserProfileComponent implements OnInit {
  userProfiles: any[] = [];
  userProfile: any;
  userComics: any[] = [];
  userMovies: any[] = [];
  userId: number = 1;

  constructor(private userProfileService: UserProfileService) { }

  ngOnInit(): void {
    this.getUserProfile();
    this.getUserComics();
    this.getUserMovies();
  }

  getUserProfile(): void {
    this.userProfileService.getUserProfile(this.userId).subscribe(
      (data) => this.userProfile = data,
      (error) => console.error('Error fetching user profile', error)
    );
  }

  getUserComics(): void {
    this.userProfileService.getUserComics(this.userId).subscribe(
      (data) => this.userComics = data,
      (error) => console.error('Error fetching user comics', error)
    );
  }

  getUserMovies(): void {
    this.userProfileService.getUserMovies(this.userId).subscribe(
      (data) => this.userMovies = data,
      (error) => console.error('Error fetching user movies', error)
    );
  }

  deleteTeam(id: number) {
    console.log(`Deleted team with id: ${id}`);
  }

  navigateToCreateTeam() {
    console.log('Navigating to create team page');
  }

}
