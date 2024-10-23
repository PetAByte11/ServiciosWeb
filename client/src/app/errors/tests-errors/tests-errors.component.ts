import { HttpClient } from '@angular/common/http';
import { Component, inject } from '@angular/core';

@Component({
  selector: 'app-tests-errors',
  standalone: true,
  imports: [],
  templateUrl: './tests-errors.component.html',
  styleUrl: './tests-errors.component.css'
})
export class TestsErrorsComponent {
  baseurl = "http://localhost:5001/api/";
  private http = inject(HttpClient);
  validationErrors: string[] = [];

  get400Error(): void {
    this.http.get(this.baseurl + "buggy/bad-request").subscribe({
      next: (response) => console.log(response),
      error: (error) => console.log(error)
    })
  }

  get401Error(): void {
    this.http.get(this.baseurl + "buggy/auth").subscribe({
      next: (response) => console.log(response),
      error: (error) => console.log(error)
    })
  }

  get404Error(): void {
    this.http.get(this.baseurl + "buggy/not-found").subscribe({
      next: (response) => console.log(response),
      error: (error) => console.log(error)
    })
  }

  get500Error(): void {
    this.http.get(this.baseurl + "buggy/server-error").subscribe({
      next: (response) => console.log(response),
      error: (error) => console.log(error)
    })
  }

  get400ValidationError(): void {
    this.http.post(this.baseurl + "account/register", {}).subscribe({
      next: (response) => console.log(response),
      error: (error) => {
        console.log(error)
        this.validationErrors = error;
      }
    })
  }
}
