import {TransactionModel} from './transaction.model';

export class DataBankModel {
  id: string;
  account: string;
  codeBank: string;
  transactions: Array<TransactionModel>;
}
