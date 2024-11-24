import { Component, inject, OnInit } from '@angular/core';
import { MembersService } from '../../_services/members.service';
import { ActivatedRoute } from '@angular/router';
import { Member } from '../../_models/member';

@Component({
  selector: 'app-members-detail',
  standalone: true,
  imports: [],
  templateUrl: './members-detail.component.html',
  styleUrl: './members-detail.component.css'
})
export class MembersDetailComponent implements OnInit{
  private memberService = inject(MembersService);
  private route = inject(ActivatedRoute);
  member?: Member;

  ngOnInit(): void {
    this.loadMember();
  }

  loadMember(){
    const username = this.route.snapshot.paramMap.get("username");
    if (!username) return;
    this.memberService.getMember(username).subscribe({
      next: (member) => this.member = member
    });
  }
}
