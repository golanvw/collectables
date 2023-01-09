using SQLite;
using System;

namespace collectables.Models
{
    public class Item
    {
        [PrimaryKey, AutoIncrement]
        public int ItemId { get; set; }
        public string ItemNaam { get; set; }
        public string ItemTeKoop { get; set; }
        public int Prijs { get; set; }
    }
}