using System;

namespace Cedesistemas.WheresMyStuff.Models
{
    public class Stuff
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Location { get; set; }
        public DateTime DateTime { get; set; }
        public bool IsVisibleForAll { get; set; }
    }
}