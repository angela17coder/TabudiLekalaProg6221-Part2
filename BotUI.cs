// Integrate SpeechSynthesizer for bot communication
using System.Speech.Synthesis;

namespace CybersecurityChatbot
{
    public static class BotUI
    {
        private static SpeechSynthesizer voice = new SpeechSynthesizer();

        public static void Speak(string text)
        {
            try
            {
                voice.SpeakAsync(text);
            }
            catch
            {

            }
        }
    }
}
