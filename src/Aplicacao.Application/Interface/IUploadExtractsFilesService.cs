using Aplicacao.DTO;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Aplicacao.Application.Interface
{
    public interface IUploadExtractsFilesService
    {
        List<DataBankDto> ExtractData(List<FileDto> files);
    }
}

