using MySQL_Test.VXML;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Windows.Forms;
using System.Xml;
using System.Xml.Serialization;

namespace MySQL_Test
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            Vxml data = null;
            using (XmlReader reader = XmlReader.Create("../../dialog_lab4.xml"))
            {
                XmlSerializer xml = new XmlSerializer(typeof(Vxml));
                data = (Vxml)xml.Deserialize(reader);
            }
            if (data == null)
                return;

            Form1 view = new Form1();
            SystemDialogowy app = new SystemDialogowy(data,
                new Recognizer.Rozpoznawanie(data.Lang),
                new Synthesis.Synteza(data.Lang),
                view);
            Thread t = new Thread(app.Run);
            view.SetAppThread(t);
            Application.Run(view);
        }
    }
}
