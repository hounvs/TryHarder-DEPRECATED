namespace TryHarder.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("LoL.Champions")]
    public partial class Champion
    {
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int ChampionID { get; set; }

        [Column("Champion")]
        [StringLength(200)]
        public string Champion1 { get; set; }
    }
}
