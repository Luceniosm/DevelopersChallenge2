import { Component, OnInit, Input, Output, EventEmitter } from '@angular/core';
import { PageChangedEvent } from 'ngx-bootstrap/pagination';

@Component({
  selector: 'app-listar-extrato',
  templateUrl: './listar-extrato.component.html',
  styleUrls: ['./listar-extrato.component.css']
})
export class ListarExtratoComponent implements OnInit {
  @Input() form;
  @Output() editEmit = new EventEmitter();
  @Output() deleteEmit = new EventEmitter();
  returnedArray: [];

  constructor() { }

  ngOnInit() {
    this.returnedArray = this.form.get('transactions').value.slice(0, 5);
  }

  edit(item: any): void {
    this.editEmit.emit(item);
  }

  deleteItem(item): void {
    this.deleteEmit.emit(item);
  }

  pageChanged(event: PageChangedEvent): void {
    debugger
    const startItem = (event.page - 1) * event.itemsPerPage;
    const endItem = event.page * event.itemsPerPage;
    this.returnedArray = this.form.get('transactions').value.slice(startItem, endItem);
  }

}
