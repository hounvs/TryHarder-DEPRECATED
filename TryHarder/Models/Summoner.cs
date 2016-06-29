namespace TryHarder.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("LoL.Summoners")]
    public partial class Summoner
    {
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public long SummonerID { get; set; }

        [Column("Summoner")]
        [StringLength(200)]
        public string Summoner1 { get; set; }

        public DateTime? LastUpdateDate { get; set; }
    }
}
