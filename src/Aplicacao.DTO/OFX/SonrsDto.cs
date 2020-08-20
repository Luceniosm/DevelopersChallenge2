using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Serialization;

namespace Aplicacao.DTO.OFX
{
    public class SonrsDto
    {
        [XmlElement("STATUS")]
        public StatusDto Status { get; set; }

        [XmlElement("DTSERVER")]
        public string DataServer { get; set; }

        [XmlElement("LANGUAGE")]
        public string Language { get; set; }
    }
}
