using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DelegateEventDemo
{
    public class VicePresident
    {
        // De vicepresident heeft zijn eigen wijze om een speech te houden
        public void AddressCongress(string speechText)
        {
            Console.WriteLine($"Esteemed members of the Congress of the United States Of America, I would like to state the following: {speechText}");
        }
    }
}
