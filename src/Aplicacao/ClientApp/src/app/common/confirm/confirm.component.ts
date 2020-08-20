import { Component, OnInit } from '@angular/core';
import { BsModalRef } from 'ngx-bootstrap/modal';

@Component({
  selector: 'app-confirm',
  templateUrl: './confirm.component.html',
  styleUrls: ['./confirm.component.css']
})
export class ConfirmComponent implements OnInit {

  message: string;
  btnOkText: string;
  btnCancelText: string;
  result: boolean;

  constructor(public bsModalRef: BsModalRef) { }

  public ngOnInit(): void {
  }

  confirm(): void {
    this.bsModalRef.hide();
    this.result = true;
  }

  decline(): void {
    this.bsModalRef.hide();
    this.result = false;
  }

}
