<<<<<<< HEAD
import { Component, inject, ViewChild, HostListener } from '@angular/core';
import { AccountService } from '../../_services/account.service';
import { MembersService } from '../../_services/members.service';
import { Member } from '../../_models/member';
=======
import { Component, HostListener, inject, OnInit, ViewChild } from '@angular/core';
import { Member } from '../../_models/member';
import { AccountService } from '../../_services/account.service';
import { MembersService } from '../../_services/members.service';
>>>>>>> datingapp/main
import { TabsModule } from 'ngx-bootstrap/tabs';
import { FormsModule, NgForm } from '@angular/forms';
import { ToastrService } from 'ngx-toastr';

@Component({
  selector: 'app-member-edit',
  standalone: true,
  imports: [TabsModule, FormsModule],
  templateUrl: './member-edit.component.html',
  styleUrl: './member-edit.component.css'
})
<<<<<<< HEAD
export class MemberEditComponent {
=======
export class MemberEditComponent implements OnInit {
>>>>>>> datingapp/main
  @ViewChild("editForm") editForm?: NgForm;
  @HostListener("window:beforeunload", ["event"]) notify($event: any) {
    if (this.editForm?.dirty) {
      $event.returnValue = true;
    }
  }
  member?: Member;
  private accountService = inject(AccountService);
<<<<<<< HEAD
  private memberService = inject(MembersService);
  private toastr = inject(ToastrService)

  ngOnInit(): void{
    this.loadMember();
  }

  loadMember(){
    const user = this.accountService.currentUser();
    if (!user) return;
    this.memberService.getMember(user.username).subscribe({
=======
  private membersService = inject(MembersService);
  private toastr = inject(ToastrService);

  ngOnInit(): void {
    this.loadMember();
  }

  loadMember() {
    const user = this.accountService.currentUser();
    if (!user) return;
    this.membersService.getMember(user.username).subscribe({
>>>>>>> datingapp/main
      next: member => this.member = member
    })
  }

  updateMember() {
<<<<<<< HEAD
    this.memberService.updateMember(this.editForm?.value).subscribe({
=======
    this.membersService.updateMember(this.editForm?.value).subscribe({
>>>>>>> datingapp/main
      next: _ => {
        this.toastr.success("Profile updated!");
        this.editForm?.reset(this.member);
      }
    });
  }
}
