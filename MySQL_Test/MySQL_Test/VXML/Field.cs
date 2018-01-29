using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Serialization;

namespace MySQL_Test.VXML
{
    public class Field
    {
        [XmlAttribute("name")]
        public string Name;
        [XmlElement("grammar")]
        public Grammar Grammar;
        [XmlElement("prompt")]
        public string Prompt;
        [XmlElement("filled")]
        public string Filled;
        public string Value;
    }
}
