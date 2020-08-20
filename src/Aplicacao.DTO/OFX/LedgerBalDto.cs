using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Serialization;

namespace Aplicacao.DTO.OFX
{
    public class LedgerBalDto
    {
        [XmlElement("BALAMT")]
        public string Balamt { get; set; }

        [XmlElement("DTASOF")]
        public string DtAsof { get; set; }
    }
}
