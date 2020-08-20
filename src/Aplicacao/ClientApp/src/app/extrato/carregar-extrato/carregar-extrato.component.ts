import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, FormArray, FormControl } from '@angular/forms';
import { ExtratoService } from '../extrato.service';
import { DataBankModel } from '../model/data-bank.model';
import { TransactionModel } from '../model/transaction.model';
import { ToastrService } from 'ngx-toastr';
import { ConfirmService } from 'src/app/common/confirm/confirm.service';

@Component({
  selector: 'app-carregar-extrato',
  templateUrl: './carregar-extrato.component.html',
  styleUrls: ['./carregar-extrato.component.css']
})
export class CarregarExtratoComponent implements OnInit {
  form: FormGroup;
  editForm = false;
  showLodingFile = true;
  loading = false;

  selectedItem = {};
  extrats = [];
  uploadFiles = [];


  constructor(
    private formBuilder: FormBuilder,
    private extratoService: ExtratoService,
    private toastr: ToastrService,
    private confirmService: ConfirmService,
  ) { }

  ngOnInit() { }

  onChange(item: any): void {
    this.uploadFiles = [];
    const files = [].slice.call(item.target.files);
    files.map((file: File) => this.getFile(file).then((data) => {
      this.uploadFiles.push(data);
    }));
  }

  upload() {
    this.showLodingFile = false;
    this.loading = true;
    this.extratoService.uploadExtractsFiles(this.uploadFiles).subscribe(_ => {
      this.uploadFiles = [];
      this.loading = false;
      if (_.success) {
        const data = _.data as Array<DataBankModel>;
        data.forEach(element => {
          this.extrats.push(
            this.formBuilder.group({
              id: [element.id],
              account: [element.account],
              codeBank: [element.codeBank],
              transactions: this.formBuilder.array(element.transactions)
            })
          );
        });
      } else {
        this.uploadFiles = [];
        this.showLodingFile = true;
        this.toastr.error('Erro ao carregar o arquivo!');
      }
    });
  }

  edit(item: any): void {
    this.editForm = true;
    this.selectedItem = item;
  }

  save(item: any): void {
    const transactions = this.getTransaction(item);
    this.updateItem(transactions, item);
    this.editForm = false;
  }

  getTransaction(item: any): FormArray {
    const extrat = this.extrats.find(el => el.value.transactions.find(_ => _.id === item.id)) as FormGroup;
    if (extrat !== undefined) {
      return extrat.get('transactions') as FormArray;
    }
  }

  updateItem(lista: FormArray, item: TransactionModel): void {
    const indexUpdateData = lista.value.findIndex(element => element.id === item.id);
    if (indexUpdateData !== undefined) {
      lista.controls[indexUpdateData].patchValue({
        id: item.id,
        description: item.description,
        amount: item.amount,
        dateTrasaction: item.dateTrasaction,
        typeTransaction: item.typeTransaction,
      });
    }
  }

  confirmRemove(item: any) {
    this.confirmService.confirm({
      message: 'Dejesa remover o item?',
      btnOkText: 'Sim',
      btnCancelText: 'Não'
    }).subscribe((result) => result ? this.removeItem(item) : null);
  }

  removeItem(item: any): void {
    const transactions = this.getTransaction(item);
    const indexUpdateData = transactions.value.findIndex(element => element.id === item.id);
    if (indexUpdateData !== undefined) {
      transactions.removeAt(indexUpdateData);
    }
  }

  cancel(item: boolean): void {
    this.editForm = item;
  }

  getFile(file: File): Promise<any> {
    const reader = new FileReader();
    return new Promise((resolve, reject) => {
      reader.onerror = () => { reader.abort(); reject(new Error('Error parsing file')); };
      reader.onload = function (evt: any) {

        const bytes = Array.from(new Uint8Array(evt.target.result));
        const base64StringFile = btoa(bytes.map((item) => String.fromCharCode(item)).join(''));

        resolve({
          name: file.name,
          mimeType: file.type,
          base64StringFile: base64StringFile,
        });
      };
      reader.readAsArrayBuffer(file);
    });
  }

  saveExtract(): void {
    const dataList = [];
    this.extrats.forEach(element => {
      dataList.push(element.value);
    });

    this.extratoService.saveExtract(dataList).subscribe(_ => {
      if (_.success) {
        this.toastr.success('Dados salvos com sucesso!');
        this.clear();
      } else {
        this.toastr.error('Erro ao persistir os dados');
      }
    });
  }

  clear(): void {
    this.editForm = false;
    this.showLodingFile = true;

    this.selectedItem = {};
    this.extrats = [];
    this.uploadFiles = [];
  }
}
