import { CommonModule } from '@angular/common';
import { Component } from '@angular/core';
import { UserProfileService } from '../../services/user-profile.service';
import { MenubarModule } from 'primeng/menubar';  // Correct import for p-menubar

@Component({
  selector: 'app-navbar',
  standalone: true,
  templateUrl: './navbar.component.html',
  styleUrls: ['./navbar.component.css'],
  imports: [CommonModule, MenubarModule],  // Import MenubarModule
})
export class NavbarComponent {
  userProfiles: any[] = [];
  isLoggedIn = true;

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

