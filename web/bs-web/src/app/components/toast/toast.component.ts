import { Component, OnInit } from '@angular/core';
import { Toast, ToastService } from 'src/app/services/toast.service';

@Component({
  selector: 'app-toast',
  templateUrl: './toast.component.html',
  styleUrls: ['./toast.component.css']
})
export class ToastComponent implements OnInit {

  toasts: Toast[] = [];

  constructor(private toastService: ToastService) {}

  ngOnInit() {
    this.toastService.toasts$.subscribe(toasts => {
      this.toasts = toasts;
    });
  }

  getTypeTitle(toast: Toast){
    switch(toast.type){
      case 'error': 
        return 'Falha'
      case 'info':
        return 'Informação'
      case 'success':
        return 'Sucesso'
      case 'warning':
        return 'Alerta'
    }
  }
}
