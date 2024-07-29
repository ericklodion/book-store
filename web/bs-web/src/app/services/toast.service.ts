import { Injectable } from '@angular/core';
import { BehaviorSubject } from 'rxjs';

export interface Toast {
  message: string;
  type: 'success' | 'error' | 'info' | 'warning';
}

@Injectable({
  providedIn: 'root'
})
export class ToastService {
  private toastsSubject = new BehaviorSubject<Toast[]>([]);
  toasts$ = this.toastsSubject.asObservable();
  
  constructor() { }

  private toasts: Toast[] = [];

  showToast(message: string, type: 'success' | 'error' | 'info' | 'warning' = 'info') {
    const toast: Toast = { message, type };
    this.toasts.push(toast);
    this.toastsSubject.next(this.toasts);
    setTimeout(() => this.removeToast(toast), 3000);
  }

  private removeToast(toast: Toast) {
    this.toasts = this.toasts.filter(t => t !== toast);
    this.toastsSubject.next(this.toasts);
  }
}
