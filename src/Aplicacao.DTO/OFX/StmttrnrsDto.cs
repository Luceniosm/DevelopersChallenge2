using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Serialization;

namespace Aplicacao.DTO.OFX
{
    public class StmttrnrsDto
    {
        [XmlElement("TRNUID")]
        public string TrnuId { get; set; }

        [XmlElement("STATUS")]
        public StatusDto Status { get; set; }

        [XmlElement("STMTRS")]
        public StmtrsDto Stmtrs { get; set; }
    }
}
