using System;
using System.Linq;
using Aplicacao.Domain.Models;
using Aplicacao.DTO;
using Aplicacao.DTO.OFX;
using Aplicacao.Utility;
using AutoMapper;

namespace Aplicacao.Application.AutoMapper
{
    public class MappingProfile: Profile
    {
        public MappingProfile()
        {
            CreateMap<StmtrsDto, DataBankDto>()
                .ForMember(x => x.Id, opt => opt.MapFrom(_ =>  Guid.NewGuid()))
                .ForMember(x => x.Account, opt => opt.MapFrom(_ => _.BankAcctFrom.AcctId))
                .ForMember(x => x.CodeBank, opt => opt.MapFrom(_ => _.BankAcctFrom.BankId))
                .ForMember(x => x.Transactions, opt =>
                    opt.MapFrom(_ => _.BankTranList.Stmttrn.Select(
                        sel => new TransactionDto
                        {
                            Id = Guid.NewGuid(),
                            Description = string.Join( " ", sel.Memo.Split( new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries )),
                            TypeTransaction = sel.TrnType,
                            Amount = sel.Trnamt,
                            DateTrasaction = DateConvert.ToDate(sel.DtPosted)
                        }
                    )));

            CreateMap<StmttrnDto, TransactionDto>()
                .ForMember(x => x.Id, opt => opt.MapFrom(_ => Guid.NewGuid()))
                .ForMember(x => x.TypeTransaction, opt => opt.MapFrom(_ => _.TrnType))
                .ForMember(x => x.DateTrasaction, opt => opt.MapFrom(_ => DateConvert.ToDate(_.DtPosted)))
                .ForMember(x => x.Amount, opt => opt.MapFrom(_ => _.Trnamt))
                .ForMember(x => x.Description, opt =>
                    opt.MapFrom(_ => string.Join( " ", _.Memo.Split( new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries )) ));

            CreateMap<DataBank, DataBankDto>();

            CreateMap<Transaction, TransactionDto>();
        }
    }
}
