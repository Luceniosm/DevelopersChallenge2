using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Serialization;

namespace Aplicacao.DTO.OFX
{
    public class StmtrsDto
    {
        [XmlElement("CURDEF")]
        public string Curdef { get; set; }

        [XmlElement("BANKACCTFROM")]
        public BankAcctFromDto BankAcctFrom { get; set; }

        [XmlElement("BANKTRANLIST")]
        public BankTranListDto BankTranList { get; set; }

        [XmlElement("LEDGERBAL")]
        public LedgerBalDto LedgerBal { get; set; }

    }
}
