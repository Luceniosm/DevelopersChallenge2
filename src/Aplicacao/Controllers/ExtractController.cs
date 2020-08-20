using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Aplicacao.Application.Interface;
using Aplicacao.Controllers.Base;
using Aplicacao.DTO;
using Microsoft.AspNetCore.Mvc;

namespace Aplicacao.Controllers
{
    [Route("api/[controller]")]
    public class ExtractController : ApiController
    {
        private readonly IExtractService _extractService;
        public ExtractController(IExtractService extractService)
        {
            _extractService = extractService;
        }

        [HttpPost]
        [Route("save")]
        public async Task<IActionResult> SaveExtract([FromBody]List<DataBankDto> dataBank)
        {
            var result = await _extractService.SaveExtract(dataBank);
            return Response(result);
        }

        [HttpPost]
        [Route("updateTransaction")]
        public async Task<IActionResult> UpdateTransaction([FromBody] TransactionDto transaction)
        {
            var result = _extractService.UpdateTransaction(transaction);
            return Response(result);
        }

        [HttpGet]
        [Route("deleteTransaction")]
        public async Task<IActionResult> DeleteTransaction(Guid IdTransaction)
        {
            var result = _extractService.DeleteTransaction(IdTransaction);
            return Response(result);
        }

        [HttpGet]
        [Route("getAccount")]
        public async Task<IActionResult> GetAccount()
        {
            var result = await _extractService.GetAccount();
            return Response(result);
        }

        [HttpGet]
        [Route("getExtractsByIdDataBank")]
        public async Task<IActionResult> GetExtractsByIdDataBank(Guid idDataBank)
        {
            var result = await _extractService.GetExtractsByIdDataBank(idDataBank);
            return Response(result);
        }

       
    }
}
