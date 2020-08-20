using System;
using System.Collections.Generic;
using System.Text;

namespace Aplicacao.DTO
{
    public class FileDto
    {
        public byte[] file { get; set; }
        public string name { get; set; }
        public string mimeType { get; set; }
        public string base64StringFile { get; set; }
    }
}

