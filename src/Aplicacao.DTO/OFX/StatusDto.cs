using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Serialization;

namespace Aplicacao.DTO.OFX
{
    public class StatusDto
    {
        [XmlElement("CODE")]
        public string Code { get; set; }

        [XmlElement("SEVERITY")]
        public string Severity { get; set; }
    }
}
