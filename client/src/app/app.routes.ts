import { Routes } from '@angular/router';
import { HomeComponent } from './home/home.component';
import { MembersListComponent } from './members/members-list/members-list.component';
import { MembersDetailComponent } from './members/members-detail/members-detail.component';
import { ListsComponent } from './lists/lists.component';
import { MessagesComponent } from './messages/messages.component';
import { authGuard } from './_guards/auth.guard';
import { TestsErrorsComponent } from './errors/tests-errors/tests-errors.component';
import { NotFoundComponent } from './errors/not-found/not-found.component';
import { ServerErrorComponent } from './errors/server-error/server-error.component';

export const routes: Routes = [
    {path: "", component: HomeComponent},
    {
        path: "",
        runGuardsAndResolvers: "always",
        canActivate: [authGuard],
        children:[
            {path: "members", component: MembersListComponent, canActivate: [authGuard]},
            {path: "members/:id", component: MembersDetailComponent},
            {path: "list", component: ListsComponent},
            {path: "messages", component: MessagesComponent},
        ]
    },
    {path: "errors", component: TestsErrorsComponent},
    {path: "not-found", component: NotFoundComponent},
    {path: "server-error", component: ServerErrorComponent},
    {path: "**", component: HomeComponent, pathMatch: "full"}
];
