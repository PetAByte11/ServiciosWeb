import { Routes } from '@angular/router';
import { HomeComponent } from './home/home.component';
<<<<<<< HEAD
import { MembersListComponent } from './members/members-list/members-list.component';
import { MembersDetailComponent } from './members/members-detail/members-detail.component';
import { ListsComponent } from './lists/lists.component';
import { MessagesComponent } from './messages/messages.component';
import { authGuard } from './_guards/auth.guard';
import { TestsErrorsComponent } from './errors/tests-errors/tests-errors.component';
=======
import { MemberListComponent } from './members/member-list/member-list.component';
import { MemberDetailComponent } from './members/member-detail/member-detail.component';
import { ListsComponent } from './lists/lists.component';
import { MessagesComponent } from './messages/messages.component';
import { authGuard } from './_guards/auth.guard';
import { TestErrorsComponent } from './errors/test-errors/test-errors.component';
>>>>>>> datingapp/main
import { NotFoundComponent } from './errors/not-found/not-found.component';
import { ServerErrorComponent } from './errors/server-error/server-error.component';
import { MemberEditComponent } from './members/member-edit/member-edit.component';
import { preventUnsavedChangesGuard } from './_guards/prevent-unsaved-changes.guard';

export const routes: Routes = [
    {path: "", component: HomeComponent},
    {
        path: "",
        runGuardsAndResolvers: "always",
        canActivate: [authGuard],
        children:[
<<<<<<< HEAD
            {path: "members", component: MembersListComponent, canActivate: [authGuard]},
            {path: "members/:username", component: MembersDetailComponent},
            {path: "member/edit", component: MemberEditComponent, canActivate: [preventUnsavedChangesGuard]},
            {path: "list", component: ListsComponent},
            {path: "messages", component: MessagesComponent},
        ]
    },
    {path: "errors", component: TestsErrorsComponent},
    {path: "not-found", component: NotFoundComponent},
    {path: "server-error", component: ServerErrorComponent},
    {path: "**", component: HomeComponent, pathMatch: "full"}
=======
            {path: "members", component: MemberListComponent,
                canActivate: [authGuard]},
            {path: "members/:username", component: MemberDetailComponent},
            {path: "member/edit", component: MemberEditComponent,
                canDeactivate: [preventUnsavedChangesGuard]},
            {path: "lists", component: ListsComponent},
            {path: "messages", component: MessagesComponent},
        ]
    },
    {path: "errors", component: TestErrorsComponent},
    {path: "not-found", component: NotFoundComponent},
    {path: "server-error", component: ServerErrorComponent},
    {path: "**", component: HomeComponent, pathMatch: "full"},
>>>>>>> datingapp/main
];
