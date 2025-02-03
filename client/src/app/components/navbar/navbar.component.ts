import { Component, OnInit } from '@angular/core';
import { MenuItem } from 'primeng/api';
import { Menubar } from 'primeng/menubar';
import { AvatarModule } from 'primeng/avatar';
import { InputTextModule } from 'primeng/inputtext';
import { CommonModule } from '@angular/common';
import { Ripple } from 'primeng/ripple';
import { BadgeModule } from 'primeng/badge';
import { OverlayBadgeModule } from 'primeng/overlaybadge';
import { TieredMenuModule } from 'primeng/tieredmenu';
import { UserProfileService } from '../../services/user-profile.service';

@Component({
  selector: 'app-navbar',
  standalone: true,
  templateUrl: './navbar.component.html',
  styleUrls: ['./navbar.component.css'],
  imports: [Menubar, BadgeModule, AvatarModule, InputTextModule, Ripple, CommonModule, OverlayBadgeModule, TieredMenuModule]
})
export class NavbarComponent {
    constructor(private userProfileService: UserProfileService) { }
    userProfiles: any[] = [];
    items: MenuItem[] | undefined;
    isLoggedIn = false;
    cartItemCount: number = 3;
    

    ngOnInit(): void {
        this.userProfileService.getUserProfiles().subscribe(
          (data) => {
            this.userProfiles = data;
            console.log(this.userProfiles);
          },
          (error) => {
            console.error('Error fetching user profiles', error);
          }
        );
      }
  
    menuItems = [
      { label: 'Battles', icon: 'pi pi-star', routerLink: '/battles' },
      { label: 'Comics', icon: 'pi pi-book', routerLink: '/comics' },
      { label: 'Movies', icon: 'pi pi-video', routerLink: '/movies' },
      { label: 'Cart', icon: 'pi pi-shopping-cart', routerLink: '/shoppingcart' }
    ];
  
    userMenu = [
      { label: 'Your Profile', icon: 'pi pi-user', routerLink: '/profile' },
      { label: 'Log Out', icon: 'pi pi-sign-out', command: () => this.logout() }
    ];
  
    onSearch(event: any) {
      console.log('Search:', event.target.value);
    }
  
    logout() {
      console.log('Logging out...');
      this.isLoggedIn = false;
    }
  }