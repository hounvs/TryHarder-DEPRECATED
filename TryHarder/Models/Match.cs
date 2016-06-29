namespace TryHarder.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("LoL.Matches")]
    public partial class Match
    {
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public long MatchID { get; set; }

        public long? TimeStamp { get; set; }

        [StringLength(50)]
        public string Queue { get; set; }

        public bool? Processed { get; set; }

        public DateTime? LastUpdateDate { get; set; }
    }
}
