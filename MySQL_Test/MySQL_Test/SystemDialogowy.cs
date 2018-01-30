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
        public DBConnect conn; //połączenie z bazą
        public Vxml vxml; //obiekt VXML, w którym znajduje się logika deserializera dla parsera
        public Rozpoznawanie recognizer; //obiekt rozpoznawania
        public Synteza synthesizer;
        private Form1 view; //zapisanie Form jako widoku, który następnie aktualizowany jest metodą SetView
        public List<String> lot; //lista, w której zapisywane są szczegóły lotu

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
                    }

                }
            this.EndDialog(lot);
        }

        public void EndDialog(List<String> lot)
        {
            var result = lot.ToArray();

            conn.InsertLot(result[0], result[1], result[2]);
            synthesizer.Say("Thank you for using our system");
            view.SetView("Thank you for using our system.", null);
        }
    }
}
