import { Component, OnInit, Input, Output, EventEmitter } from '@angular/core';

@Component({
  selector: 'app-listar-extrato',
  templateUrl: './listar-extrato.component.html',
  styleUrls: ['./listar-extrato.component.css']
})
export class ListarExtratoComponent implements OnInit {
  @Input() form;
  @Output() editEmit = new EventEmitter();
  @Output() deleteEmit = new EventEmitter();
  p = 1;

  constructor() { }

  ngOnInit() {
  }

  edit(item: any): void {
    this.editEmit.emit(item);
  }

  deleteItem(item): void {
    this.deleteEmit.emit(item);
  }

}
