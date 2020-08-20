import { Component, EventEmitter, OnInit, Output, Input } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';

@Component({
  selector: 'app-editar-extrato',
  templateUrl: './editar-extrato.component.html',
  styleUrls: ['./editar-extrato.component.css']
})
export class EditarExtratoComponent implements OnInit {
  form: FormGroup;
  @Input() selectedItem;
  @Output() cancelEmit = new EventEmitter();
  @Output() saveEmit = new EventEmitter();

  constructor(
    private formBuilder: FormBuilder
  ) { }

  ngOnInit() {
    this.buildForm();
    this.loadData();
  }

  buildForm(): void {
    this.form = this.formBuilder.group({
      id: [''],
      description: ['', Validators.required],
      amount: ['',  Validators.required],
      dateTrasaction: ['',  Validators.required],
      typeTransaction: ['',  Validators.required]
    });
  }

  loadData(): void {
    this.form.patchValue({
      id: this.selectedItem.id,
      description: this.selectedItem.description,
      amount: this.selectedItem.amount,
      dateTrasaction: this.selectedItem.dateTrasaction,
      typeTransaction: this.selectedItem.typeTransaction,
    });
  }

  cancel(): void {
    this.cancelEmit.emit(false);
  }

  save(): void {
    this.saveEmit.emit(this.form.value);
  }

  isValid(input) {
    return (input.invalid || !input.valid) && (input.dirty || input.touched);
  }

}
