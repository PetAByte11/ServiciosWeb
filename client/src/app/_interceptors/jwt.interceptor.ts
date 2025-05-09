import { HttpInterceptorFn } from '@angular/common/http';
<<<<<<< HEAD
import { inject } from '@angular/core';
import { AccountService } from '../_services/account.service';
=======
import { AccountService } from '../_services/account.service';
import { inject } from '@angular/core';
>>>>>>> datingapp/main

export const jwtInterceptor: HttpInterceptorFn = (req, next) => {
  const accountService = inject(AccountService);

<<<<<<< HEAD
  if (accountService.currentUser()){
=======
  if (accountService.currentUser()) {
>>>>>>> datingapp/main
    req = req.clone({
      setHeaders: {
        Authorization: `Bearer ${accountService.currentUser()?.token}`
      }
<<<<<<< HEAD
    })
  }

=======
    });
  }
  
>>>>>>> datingapp/main
  return next(req);
};
