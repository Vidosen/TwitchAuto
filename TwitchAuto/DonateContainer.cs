using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TwitchAuto
{
    class DonateContainer
    {
        public Donater[] Donaters;

        public DonateContainer(Donater[] donaters)
        {
            Donaters = donaters;
        }
        public DonateContainer()
        {
            Donaters = new Donater[3];
        }

    }

    [Serializable]
    class Donater
    {
        [JsonProperty]
        public string Sender { get; set; }
        [JsonProperty]
        public decimal Amount { get; set; }
    }
}
