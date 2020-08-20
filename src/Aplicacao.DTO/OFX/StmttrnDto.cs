using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Serialization;

namespace Aplicacao.DTO.OFX
{
    [XmlRoot("STMTTRN")]
    public class StmttrnDto
    {
        [XmlElement("TRNTYPE")]
        public string TrnType { get; set; }

        [XmlElement("DTPOSTED")]
        public string DtPosted { get; set; }

        [XmlElement("TRNAMT")]
        public decimal Trnamt { get; set; }

        [XmlElement("MEMO")]
        public string Memo { get; set; }
    }
}
