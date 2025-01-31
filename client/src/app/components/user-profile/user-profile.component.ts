import { Component, OnInit } from '@angular/core';
import { UserProfileService } from '../../services/user-profile.service';
import { CommonModule } from '@angular/common';

@Component({
  selector: 'app-user-profile',
  templateUrl: './user-profile.component.html',
  styleUrls: ['./user-profile.component.css'],
  standalone: true,
  imports: [CommonModule],
})
export class UserProfileComponent implements OnInit {
  userProfiles: any[] = [];

  constructor(private userProfileService: UserProfileService) { }

  ngOnInit(): void {
    this.userProfileService.getUserProfiles().subscribe(
      (data) => {
        this.userProfiles = data;
      },
      (error) => {
        console.error('Error fetching user profiles', error);
      }
    );
  }
}
