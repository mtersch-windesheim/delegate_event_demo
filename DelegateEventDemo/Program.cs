using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DelegateEventDemo
{
    class Program
    {
        //public delegate void DoeIets();

        //private static DoeIets[] dingen;

        static void Main(string[] args)
        {
            PresidentialSpeech();
            //dingen = new DoeIets[2];
            //dingen[0] = DingEen;
            //dingen[1] = DingTwee;

            //int doeding = new Random().Next(2);
            //dingen[doeding]();

            //PrintValues pv = new PrintValues();
        }

        //static void DingEen()
        //{
        //    Console.WriteLine("Ding 1");
        //}
        //static void DingTwee()
        //{
        //    Console.WriteLine("Ding 2");
        //}

        static void PresidentialSpeech()
        {
            // Er waren eens een president en een vicepresident...
            President trump = new President();
            VicePresident pence = new VicePresident();

            // De president geeft zelf zijn eerste speech
            // (NB: in de constructor van President zijn aan PerformSpeech nog de methoden DeliverSpeechPersonally en DumpOnTwitter gekoppeld)
            trump.DeliverSpeech("Just shut up about the environment");
            
            // Daarna is hij het zat, en mag de vicepresident het werk doen:
            // De vicepresident krijgt de verantwoordelijkheid toegeschoven (en pakt die netjes op, met instantieren van een delegate en alles er op en er aan)...
            trump.PerformSpeech = new President.SpeechMethod(pence.AddressCongress);
            // ...en mag gelijk aan het werk
            trump.DeliverSpeech("These are all lies! Fake News!");  // We vragen Trump een speech te geven, maar het is Pence die praat!
            
            // Oke, president Trump wil zelf nog wel iets op Twitter gooien
            trump.PerformSpeech += trump.DumpOnTwitter;
            // Dus vicepresident Pence praat, en president Trump twittert
            trump.DeliverSpeech("All Democrats are lying bastards!");
            
            // Trump vertrouwt Pence niet meer, en gaat zelf weer speechen
            trump.PerformSpeech -= pence.AddressCongress;
            trump.PerformSpeech += trump.SpeakPersonally;
            // Wat gebeurt er als de speechschrijver net aan Pence gewend was...?
            trump.DeliverSpeech("It seems to me that there are multiple ways to reduce the budget deficit, and we should choose the option that is best for our country.");
        }
    }
}
