using System;

namespace Cedesistemas.WheresMyStuff.Models
{
    //POCO: Plain Old CLR Object
    public class Item
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Location { get; set; }
        public DateTime DateTime { get; set; }
        public bool IsVisibleForAll { get; set; }
    }
}