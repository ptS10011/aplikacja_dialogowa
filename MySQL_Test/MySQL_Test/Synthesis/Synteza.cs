using Microsoft.Speech.Synthesis;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MySQL_Test.Synthesis
{
    class Synteza
    {
        private SpeechSynthesizer s;

        public Synteza(string jezyk)
        {
            s = new SpeechSynthesizer();
            System.Globalization.CultureInfo culture = new System.Globalization.CultureInfo(jezyk);
            foreach (InstalledVoice voice in s.GetInstalledVoices()) //przejrzyj listę zainstalowanych głosów i wybierz ten, który pasuje do wybranego w wywołaniu metody locale
            {
                VoiceInfo info = voice.VoiceInfo;
                if (info.Culture.Equals(culture))
                {
                    s.SelectVoice(info.Name);
                }
            }
            s.SetOutputToDefaultAudioDevice(); //ustaw wyjście na domyślne wyjście dźwięku
        }

        internal void Say(string prompt)
        {
            if (prompt == null)
                return;
            s.Speak(prompt);
        }
    }
}
