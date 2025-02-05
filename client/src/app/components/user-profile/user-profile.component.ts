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

  constructor(private userProfileService: UserProfileService) { }

  ngOnInit(): void {
    this.userProfileService.getUserProfiles().subscribe(
      (data) => {
        this.userProfiles = data;
      },
      (error) => {
      }
    );
  }


  favoriteMovies = [
    { 
      title: 'Iron Man', 
      picture: 'https://image.tmdb.org/t/p/original/zDN5cF6nATORm4EMUSuuwJ97DuK.jpg', 
      price: 20 
    },
    { 
      title: 'Iron Man 2', 
      picture: 'https://resizing.flixster.com/-XZAfHZM39UwaGJIFWKAE8fS0ak=/v3/t/assets/p3546118_p_v10_af.jpg', 
      price: 25 
    }
  ];

  iconHeart = 'pi pi-heart';
  iconCart = 'pi pi-shopping-cart';

  
favoriteComics = [
  { title: 'Amazing Fantasy 15', picture: 'https://cdn.marvel.com/u/prod/marvel/i/mg/f/10/598363848588e/clean.jpg', price:19.99 },
  { title: 'Fantastic Four #1', picture: 'https://m.media-amazon.com/images/I/6142Uqk5R0L._UF1000,1000_QL80_.jpg', price:19.99 }
];

userTeams = [
  { teamName: 'Avengers', id: 1, characters: [{ picture: 'path/to/ironman.jpg' }, { picture: 'path/to/captainamerica.jpg' }] }
];

deleteTeam(id: number) {
  console.log(`Deleted team with id: ${id}`);
}

navigateToCreateTeam() {
  console.log('Navigating to create team page');
}
}
