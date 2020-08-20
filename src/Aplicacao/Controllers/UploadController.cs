using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Aplicacao.Application.Interface;
using Aplicacao.Application.Service;
using Aplicacao.Controllers.Base;
using Aplicacao.DTO;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Aplicacao.Controllers
{
    [Route("api/[controller]")]
    public class UploadController : ApiController
    {
        private readonly IUploadExtractsFilesService _uploadExtractsFilesService;

        public UploadController(IUploadExtractsFilesService uploadExtractsFilesService)
        {
            _uploadExtractsFilesService = uploadExtractsFilesService;
        }

        [HttpPost]
        [Route("uploadFiles")]
        public IActionResult UploadFiles([FromBody]List<FileDto> files)
        {
            var result = _uploadExtractsFilesService.ExtractData(files);
            return Response(result);
        }
    }
}
