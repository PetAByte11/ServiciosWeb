import { Routes } from '@angular/router';
import { HomeComponent } from './home/home.component';
import { MembersListComponent } from './members/members-list/members-list.component';
import { MembersDetailComponent } from './members/members-detail/members-detail.component';
import { ListsComponent } from './lists/lists.component';
import { MessagesComponent } from './messages/messages.component';

export const routes: Routes = [
    {path: "", component: HomeComponent},
    {path: "members", component: MembersListComponent},
    {path: "members/:id", component: MembersDetailComponent},
    {path: "list", component: ListsComponent},
    {path: "messages", component: MessagesComponent},
    {path: "**", component: HomeComponent, pathMatch: "full"},
];
