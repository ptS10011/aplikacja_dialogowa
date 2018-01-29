using Microsoft.Speech.Recognition;
using Microsoft.Speech.Recognition.SrgsGrammar;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace MySQL_Test.Recognizer
{
        class Rozpoznawanie
        {
            private SpeechRecognitionEngine sre;

            public Rozpoznawanie(string jezyk)
            {
                sre = new SpeechRecognitionEngine(new System.Globalization.CultureInfo(jezyk)); //utworzenie obiektu rozpoznawania mowy o locale podanym w konstruktorze
                sre.SetInputToDefaultAudioDevice(); //ustawienie rozpoznawania na domyślne urządzenie output
            }

            public void UstawGramatyke(string path)
            {
                sre.UnloadAllGrammars();
                SrgsDocument doc = new SrgsDocument("../../" + path);
                sre.LoadGrammar(new Grammar(doc, Path.GetFileNameWithoutExtension(path)));
            }

            public string Nasluch()
            {
                RecognitionResult result = sre.Recognize(new TimeSpan(0, 0, 20)); //rozpoznawaj przez 20 sekund
                if (result == null)
                {
                    return null;
                }
                if (result.Semantics.Value != null)
                    return result.Semantics.Value.ToString();
                else if (result.Semantics.Count > 0)
                    return string.Join(";", result.Semantics.Select(x => x.Key + "=" + x.Value.Value).ToArray());

                return null;
            }
        }
}
