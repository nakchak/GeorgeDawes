using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;

namespace GeorgeDawes.Models {
    public class Tracker {
        private static readonly Random Random = new Random();
        [Key]
        public int Id { get; set; }
        [Required]
        public string Slug { get; set; }
        [Required]
        public string FriendlyName { get; set; }
        [Required]
        public int NumberOfPlayers { get; set; }
        public virtual List<CounterSpec> CounterSpecs { get; set; }
        public Tracker(bool generateSlug = false) {
            if(generateSlug) Slug = GenerateSlug();
        }
        private string GenerateSlug() {
            const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
            return new string(Enumerable.Repeat(chars, 7).Select(s => s[Random.Next(s.Length)]).ToArray());
        }
    }

    public class Player {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        public virtual List<Counter> Counters { get; set; }

    }

    public class Counter {
        [Key]
        public int Id { get; set; }
        [Required]
        public int Score { get; set; }
        public string Name { get; set; }
        public int StartingValue { get; set; }
        public int Multiplier { get; set; }
        public virtual Player Player { get; set; }
    }
    public class CounterSpec {
        public int Id { get; set; }
        public virtual Tracker Tracker { get; set; }
        public string Name { get; set; }
        public int StartingValue { get; set; }
        public int Multiplier { get; set; }
    }
}