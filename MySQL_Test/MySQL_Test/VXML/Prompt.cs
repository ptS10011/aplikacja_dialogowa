using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Serialization;

namespace MySQL_Test.VXML
{
    public class Prompt
    {
        [XmlText]
        public string Value;
        [XmlAttribute("id")]
        public string Id;
    }
}
