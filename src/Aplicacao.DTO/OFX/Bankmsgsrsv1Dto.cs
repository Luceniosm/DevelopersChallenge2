using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Serialization;

namespace Aplicacao.DTO.OFX
{
    public class Bankmsgsrsv1Dto
    {
        [XmlElement("STMTTRNRS")]
        public StmttrnrsDto Stmttrnrs { get; set; }
    }
}
