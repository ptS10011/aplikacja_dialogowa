using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MySQL_Test.Recognizer;
using MySQL_Test.Synthesis;
using MySQL_Test.VXML;

namespace MySQL_Test
{
    class SystemDialogowy
    {
        public DBConnect conn;
        public Vxml vxml;
        public Rozpoznawanie recognizer;
        public Synteza synthesizer;
        private Form1 view;
        public List<String> lot;

        public SystemDialogowy(Vxml vxml, Rozpoznawanie recognizer, Synteza synthesizer, Form1 widok)
        {
            this.vxml = vxml;
            this.recognizer = recognizer;
            this.synthesizer = synthesizer;
            this.view = widok;
            conn = new DBConnect();
        }

        public void Run()
        {
            lot = new List<String>();
            //synthesizer.Say("Test");
            foreach (Form form in vxml.Forms)
            {
                if (form.Grammar != null)
                {
                    recognizer.UstawGramatyke(form.Grammar.Src);
                    view.SetView(form.Prompt, null);
                    synthesizer.Say(form.Prompt);
                    bool done = false;
                    while (!done)
                    {
                        string result = recognizer.Nasluch();
                        if (!string.IsNullOrWhiteSpace(result))
                        {
                            lot.Add(result);
                            //appointment.SetAttributes(result, "");
                        }
                        done = true;
                    }
                }
                else
                {
                    synthesizer.Say(form.Prompt);
                }
                foreach (Field field in form.Fields)
                {
                        recognizer.UstawGramatyke(field.Grammar.Src);
                        view.SetView(field.Prompt, null);
                        synthesizer.Say(field.Prompt);
                        bool done = false;
                        while (!done)
                        {
                            string result = recognizer.Nasluch();
                            if (!string.IsNullOrWhiteSpace(result))
                            {
                                lot.Add(result);
                                field.Value = result;
                                done = true;
                            }
                            else
                            {
                                synthesizer.Say(vxml.NoMatch);
                            }
                        }
                        //synthesizer.Say(field.Filled + appointment.GetAttribute(field.Name));
                    }

                }
            this.EndDialog(lot);
        }

        public void EndDialog(List<String> lot)
        {
            //foreach (i in lot)
           // {
                //conn.InsertLot(lot.)
                synthesizer.Say("Thank you for using our system");
                view.SetView("Thank you for using our system.", null);
           // }
            /*else
            {
                synthesizer.Say("There were errors please call again");
                view.SetView("There were errors please call again.", null);
            }*/
        }
    }
}
