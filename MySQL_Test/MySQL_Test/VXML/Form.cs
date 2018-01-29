using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Serialization;

namespace MySQL_Test.VXML
{
    [XmlRootAttribute("form")]
    public class Form
    {

        [XmlElement("grammar")]
        public Grammar Grammar;
        [XmlElement("prompt")]
        public string Prompt;
        [XmlElement("field")]
        public List<Field> Fields;
        [XmlElement("filled")]
        public string Filled;
    }
}
