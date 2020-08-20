using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Serialization;

namespace Aplicacao.DTO.OFX
{
    public class BankAcctFromDto
    {
        [XmlElement("BANKID")]
        public string BankId { get; set; }

        [XmlElement("ACCTID")]
        public string AcctId { get; set; }

        [XmlElement("ACCTTYPE")]
        public string AcctType { get; set; }
    }
}
