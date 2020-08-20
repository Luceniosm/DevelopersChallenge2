using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Serialization;

namespace Aplicacao.DTO.OFX
{
    [XmlRoot("OFX")]
    public class OfxDto
    {
        [XmlElement("SIGNONMSGSRSV1")]
        public Signonmsgsrsv1Dto Signonmsgsrsv1 { get; set; }

        [XmlElement("BANKMSGSRSV1")]
        public Bankmsgsrsv1Dto Bankmsgsrsv1 { get; set; }
    }
}
