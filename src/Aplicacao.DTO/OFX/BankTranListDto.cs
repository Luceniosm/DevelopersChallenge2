using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Serialization;

namespace Aplicacao.DTO.OFX
{
    public class BankTranListDto
    {
        [XmlElement("DTSTART")]
        public string DtStart { get; set; }

        [XmlElement("DTEND")]
        public string DtEnd { get; set; }

        [XmlElement("STMTTRN")]
        public StmttrnDto[] Stmttrn { get; set; }
    }
}
