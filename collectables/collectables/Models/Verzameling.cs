using SQLite;
using System;
using System.Collections.Generic;
using System.Text;

namespace collectables.Models
{
    internal class Verzameling
    {
        [PrimaryKey, AutoIncrement]
        public int VerzamelingID { get; set; }
        public string VerzamelingNaam { get; set; }
        public List<Item> Items { get; set; }
    }
}
