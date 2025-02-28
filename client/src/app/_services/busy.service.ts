import { inject, Injectable } from '@angular/core';
import { NgxSpinnerService } from 'ngx-spinner';

@Injectable({
  providedIn: 'root'
})
export class BusyService {
  busyRequestCount = 0;
  private spinnerService = inject(NgxSpinnerService);
<<<<<<< HEAD

=======
  
>>>>>>> datingapp/main
  busy(): void {
    this.busyRequestCount++;
    this.spinnerService.show(undefined, {});
  }

  idle(): void {
    this.busyRequestCount--;
    if (this.busyRequestCount <= 0) {
      this.busyRequestCount = 0;
      this.spinnerService.hide();
    }
  }
<<<<<<< HEAD
}
=======
}
>>>>>>> datingapp/main
