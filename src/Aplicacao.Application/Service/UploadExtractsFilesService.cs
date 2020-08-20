using Aplicacao.Application.Interface;
using Aplicacao.DTO;
using Aplicacao.DTO.OFX;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using AutoMapper;
using XmlConvert = Aplicacao.Utility.XmlConvert;

namespace Aplicacao.Application.Service
{
    public class UploadExtractsFilesService : IUploadExtractsFilesService
    {
        private readonly IMapper _mapper;

        public UploadExtractsFilesService(IMapper mapper)
        {
            _mapper = mapper;
        }
        public List<DataBankDto> ExtractData(List<FileDto> files)
        {
            var dataBanks = new List<DataBankDto>();
            foreach (var file in files.Select(item => ConvertStringToFileStream(item)).Where(file => file?.Bankmsgsrsv1?.Stmttrnrs?.Stmtrs != null))
            {
                GetDataBankList(dataBanks, file.Bankmsgsrsv1.Stmttrnrs.Stmtrs);
            }

            return dataBanks;
        }

        private void GetDataBankList(List<DataBankDto> dataBanks, StmtrsDto dataBankXml)
        {
            if (dataBanks.Any(el => el.CodeBank == dataBankXml.BankAcctFrom.BankId && el.Account == dataBankXml.BankAcctFrom.AcctId))
            {
                var dataBank = dataBanks.Find(el =>
                    el.CodeBank == dataBankXml.BankAcctFrom.BankId && el.Account == dataBankXml.BankAcctFrom.AcctId);
                foreach (var transaction in dataBankXml.BankTranList.Stmttrn)
                {
                    var itemTransaction = _mapper.Map<TransactionDto>(transaction);
                    if(dataBank != null && dataBank.Transactions.Any(el =>
                        el.Description.Equals(itemTransaction.Description) &&
                        el.Amount.Equals(itemTransaction.Amount) &&
                        el.DateTrasaction.Equals(itemTransaction.DateTrasaction) &&
                        el.TypeTransaction.Equals(itemTransaction.TypeTransaction)
                    )) continue;
                    dataBank.Transactions.Add(itemTransaction);
                }

                dataBank.Transactions.OrderBy(_ => _.DateTrasaction).ToList();
            }
            else
            {
                var map = _mapper.Map<DataBankDto>(dataBankXml);
                map.Transactions.OrderBy(_ => _.DateTrasaction).ToList();
                dataBanks.Add(map);
            }
        }

        private OfxDto ConvertStringToFileStream(FileDto item)
        {
            var convertStringToBytes = Convert.FromBase64String(item.base64StringFile);
            var fileInMemory = new StreamReader(new MemoryStream(convertStringToBytes));

            var stringXml = string.Empty;
            var lineRead = string.Empty;
            while ((lineRead = fileInMemory.ReadLine()) != null)
            {
                stringXml = CreateLineXml(stringXml, lineRead);
            }

            return XmlConvert.DeserializeObject<OfxDto>(stringXml);
        }

        private static string CreateLineXml(string stringXml, string lineRead)
        {
            if (!lineRead.Contains("<")) return stringXml;
            var validTagClosed = lineRead.Substring(lineRead.Length - 1);
            if (validTagClosed != ">")
            {
                var regex = new Regex(@"[^\<]+(?=\>)");
                var value = regex.Match(lineRead);
                var nameTag = value.Groups[0].ToString();

                stringXml += lineRead + $"</{nameTag}>";
            }
            else
                stringXml += lineRead;

            return stringXml;
        }
    }
}
