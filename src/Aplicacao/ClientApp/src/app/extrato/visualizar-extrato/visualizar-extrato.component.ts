import { Component, OnInit } from '@angular/core';
import { ExtratoService } from '../extrato.service';
import { FormGroup, Validators, FormBuilder, FormArray } from '@angular/forms';
import { DataBankModel } from '../model/data-bank.model';
import { element } from 'protractor';
import { TransactionModel } from '../model/transaction.model';
import { ConfirmService } from 'src/app/common/confirm/confirm.service';
import { ToastrService } from 'ngx-toastr';

@Component({
  selector: 'app-visualizar-extrato',
  templateUrl: './visualizar-extrato.component.html',
  styleUrls: ['./visualizar-extrato.component.css']
})
export class VisualizarExtratoComponent implements OnInit {
  form: FormGroup;
  formDataBank: FormGroup;
  dataBanks: DataBankModel[] = [];
  showList = false;
  editForm = false;

  selectedItem = {};


  constructor(
    private extratoService: ExtratoService,
    private formBuilder: FormBuilder,
    private confirmService: ConfirmService,
    private toastr: ToastrService,
  ) { }

  ngOnInit() {
    this.formBuild();
    this.getAccount();
  }

  formBuild(): void {
    this.form = this.formBuilder.group({
      id: ['', Validators.required]
    });

  }

  getAccount(): void {
    this.extratoService.getAccount().subscribe(_ => {
      if (_.success) {
        this.dataBanks = _.data as Array<DataBankModel>;
      } else {
        this.toastr.error('Erro ao buscar os dados!');
      }
    });
  }

  search() {
    this.extratoService.getExtractsByIdDataBank(this.form.get('id').value).subscribe(_ => {
      if (_.success) {
        const dataBank = this.dataBanks.find(el => el.id === this.form.get('id').value);
        this.formDataBank = this.formBuilder.group({
          id: [dataBank.id],
          account: [dataBank.account],
          codeBank: [dataBank.codeBank],
          transactions: this.formBuilder.array(_.data)
        });
        this.showList = true;
      } else {
        this.toastr.error('Erro ao buscar os dados!');
      }
    });
  }

  edit(item: any): void {
    this.editForm = true;
    this.showList = false;
    this.selectedItem = item;
  }

  cancel(item: boolean): void {
    this.editForm = item;
    this.showList = true;
  }

  confirmDelete(item: any) {
    this.confirmService.confirm({
      message: 'Dejesa confirmar a EXCLUSÃO?',
      btnOkText: 'Sim',
      btnCancelText: 'Não'
    }).subscribe((result) => result ? this.deleteItem(item) : null);
  }

  deleteItem(item: any): void {
    this.extratoService.deleteTransaction(item.id).subscribe(_ => {
      if (_.success) {
        const indexDeleteData = this.formDataBank.get('transactions').value.findIndex(el => el.id === item.id);
        if (indexDeleteData !== undefined) {
          const list = this.formDataBank.get('transactions') as FormArray;
          list.removeAt(indexDeleteData);
        }
        this.toastr.success('Transação excluida com sucesso!');
      } else {
        this.toastr.error('Erro ao excluir a transação!');
      }
    });
  }

  update(item: any): void {
    this.extratoService.updateTransaction(item).subscribe(_ => {
      if (_.success) {
        this.toastr.success('Transação atualizada com sucesso!');
        const updateData = this.formDataBank.get('transactions').value.find(el => el.id === item.id);
        if (updateData !== undefined) {
          updateData.id = _.data.id;
          updateData.description = _.data.description;
          updateData.amount = _.data.amount;
          updateData.dateTrasaction = _.data.dateTrasaction;
          updateData.typeTransaction = _.data.typeTransaction;
        }
        this.cancel(false);
      } else {
        this.toastr.error('Erro ao atualizada a transação!');
      }
    });
  }
}
