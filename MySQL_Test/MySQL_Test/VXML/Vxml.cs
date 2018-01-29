using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Serialization;

namespace MySQL_Test.VXML
{
        [XmlRoot("vxml", Namespace = "http://www.w3.org/2001/vxml")]
        public class Vxml
        {
            [XmlElement("nomatch")]
            public string NoMatch;
            [XmlElement("form")]
            public List<Form> Forms;

            [XmlAttribute("version")]
            public string Version;
            [XmlAttribute("xmlns")]
            public string Xmlns;
            [XmlAttribute("xml:lang")]
            public string Lang;
        }
}
