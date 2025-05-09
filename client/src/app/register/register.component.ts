import { Component, inject, input, output } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { AccountService } from '../_services/account.service';
import { ToastrService } from 'ngx-toastr';

@Component({
  selector: 'app-register',
  standalone: true,
  imports: [FormsModule],
  templateUrl: './register.component.html',
  styleUrl: './register.component.css'
})
export class RegisterComponent {
  private accountService = inject(AccountService);
<<<<<<< HEAD
  //usersFromHomeComponent = input.required<any>();
=======
  // usersFromHomeComponent = input.required<any>();
>>>>>>> datingapp/main
  private toastr = inject(ToastrService);
  cancelRegister = output<boolean>();
  model: any = {};

  register(): void {
    this.accountService.register(this.model).subscribe({
      next: (response) => {
        console.log(response);
<<<<<<< HEAD
        this.cancel()
      },
      error: (error) => {
=======
        this.cancel();
      },
      error: (error) => {
        console.log(error);
>>>>>>> datingapp/main
        this.toastr.error(error.errors);
      }
    });
  }

<<<<<<< HEAD
  cancel(): void{
=======
  cancel(): void {
>>>>>>> datingapp/main
    this.cancelRegister.emit(false);
  }
}
