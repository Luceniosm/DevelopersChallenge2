import { Injectable } from '@angular/core';
import { BsModalRef, BsModalService } from 'ngx-bootstrap/modal';
import { Observable } from 'rxjs';
import { ConfirmComponent } from './confirm.component';


@Injectable({
  providedIn: 'root',
})
export class ConfirmService {
  modalRef: BsModalRef;
  message: string;
  btnOkText = 'Sim';
  btnCancelText = 'Não';
  result: boolean;


  constructor(private modalService: BsModalService) { }

  public confirm(o: any): Observable<boolean> {
    this.modalRef = this.modalService.show(ConfirmComponent, {
      animated: true, backdrop: 'static', class: 'modal-sm, modal-dialog-centered'
    });
    this.modalRef.content.message = o.message || this.message;
    this.modalRef.content.btnOkText = o.btnOkText || this.btnOkText;
    this.modalRef.content.btnCancelText = o.btnCancelText || this.btnCancelText;

    return new Observable<boolean>(this.getConfirmSubscriber());
  }

  private getConfirmSubscriber() {
    return (observer) => {
      const subscription = this.modalService.onHidden.subscribe((reason: string) => {
        observer.next(this.modalRef.content.result);
        observer.complete();
      });

      return {
        unsubscribe() {
          subscription.unsubscribe();
        }
      };
    };
  }
}
