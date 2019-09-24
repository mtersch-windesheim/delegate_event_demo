using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DelegateEventDemo
{
    public class President
    {
        // Definitie van de delegate ('type' van de 'functie-variabele')
        public delegate void SpeechMethod(string speechText);

        // Declaratie van een variabele van ons delegate-type (kan verwijzen naar 1 of meer functies van het juiste type)
        public SpeechMethod PerformSpeech { get; set; }

        // Default constructor voor President: standaard worden alle speeches persoonlijk geschreeuwd en op Twitter gedumpt
        public President()
        {
            // Netjes een nieuwe delegate-instance voor de methode DeliverSpeechPersonally aanmaken, en aan PerformSpeech toewijzen.
            // (NB: door gebruik van '=' worden eventuele eerdere delegates in PerformSpeech *vervangen* door deze nieuwe delegate
            PerformSpeech = new SpeechMethod(SpeakPersonally);
            // De korte versie (C# regelt zelf instantiatie van een delegate), en toe*voegen* (+=) aan PerformSpeech.
            PerformSpeech += DumpOnTwitter;
        }
        // De president wordt gevraagd een speech te houden met een bepaalde tekst...
        public void DeliverSpeech(string speechText)
        {
            // ... en doet dat op de manier die hem nu goed uitkomt. (On-the-fly te bepalen of hij het zelf doet, of uitbesteedt.)
            PerformSpeech(speechText);
            Console.WriteLine("----------");    // Ter verduidelijking van de uitvoer: streepjes na elke speech
        }
        // De methode om persoonlijk een speech uit te spreken
        public void SpeakPersonally(string speechText)
        {
            // Teveel woorden = teveel gedoe
            if (speechText.Split(' ').Length > 8)
            {
                Console.WriteLine("WHO WROTE THIS CRAP! WAAAY TOO MANY WORDS!");
            }
            else
            {
                // Als je speecht, dan vooral DUIDELIJK SCHREEUWEN!
                Console.WriteLine(speechText.ToUpper());
            }
        }
        // Oh ja, Twitter niet vergeten!
        public void DumpOnTwitter(string speechText)
        {
            Console.WriteLine($"@PRESIDENT_DUDE: {speechText.Substring(0,Math.Min(speechText.Length, 40)).ToUpper()}!!!");
        }
    }
}
