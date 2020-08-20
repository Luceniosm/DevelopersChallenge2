using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Serialization;

namespace Aplicacao.DTO.OFX
{
    public class Signonmsgsrsv1Dto
    {
        [XmlElement("SONRS")]
        public SonrsDto Sonrs { get; set; }
    }
}
