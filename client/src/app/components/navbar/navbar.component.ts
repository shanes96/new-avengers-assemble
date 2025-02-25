import { Component, OnInit } from '@angular/core';
import { MenuItem } from 'primeng/api';
import { AvatarModule } from 'primeng/avatar';
import { InputTextModule } from 'primeng/inputtext';
import { CommonModule } from '@angular/common';
import { Ripple } from 'primeng/ripple';
import { BadgeModule } from 'primeng/badge';
import { OverlayBadgeModule } from 'primeng/overlaybadge';
import { TieredMenuModule } from 'primeng/tieredmenu';
import { UserProfileService } from '../../services/user-profile.service';
import { Router } from '@angular/router';
import { AuthService } from '../../services/auth.service';
import { MenuModule } from 'primeng/menu';
import { MenubarModule } from 'primeng/menubar';
@Component({
  selector: 'app-navbar',
  standalone: true,
  templateUrl: './navbar.component.html',
  styleUrls: ['./navbar.component.css'],
  imports: [
    AvatarModule, 
    InputTextModule, 
    CommonModule, 
    Ripple, 
    BadgeModule, 
    OverlayBadgeModule, 
    TieredMenuModule, 
    MenuModule,
    MenubarModule
  ]
})
export class NavbarComponent implements OnInit {
  userProfiles: any[] = [];
  isLoggedOn: boolean = false;
  menuItems: MenuItem[] = [];
  userMenuItems: MenuItem[] = [];

  constructor(
    private userProfileService: UserProfileService,
    private authService: AuthService,
    private router: Router
  ) {}

  ngOnInit(): void {
    this.fetchUserProfiles();
    this.setupMenu();
    this.userMenu();
  }

  fetchUserProfiles(): void {
    this.userProfileService.getUserProfiles().subscribe(
      (data) => {
        this.userProfiles = data;
        this.isLoggedOn = this.userProfiles.some(profile => profile.isLoggedOn);
      },
      (error) => console.error('Error fetching user profiles', error)
    );
  }

  setupMenu(): void {
    this.menuItems = [
      { label: 'Battles', icon: 'pi pi-star', routerLink: '/battles' },
      { label: 'Comics', icon: 'pi pi-book', routerLink: '/comics' },
      { label: 'Movies', icon: 'pi pi-video', routerLink: '/movies' },
      { label: 'Cart', icon: 'pi pi-shopping-cart', routerLink: '/shoppingcart' },
    ];
  }

  userMenu(): void  {
    this.userMenuItems = [
      { label: 'Profile', icon: 'pi pi-user', command: () => this.router.navigate(['/profile']) },
      { label: 'Logout', icon: 'pi pi-sign-out', command: () => this.logout() }
    ];
  }

  toggleMenu(event: Event, menu: any): void {
    menu.toggle(event);
  }

  onSearch(event: any): void {
    console.log('Search:', event.target.value);
  }

  logout(): void {
    this.authService.logout();
  }
}