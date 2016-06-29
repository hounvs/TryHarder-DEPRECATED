namespace TryHarder.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("LoL.SummonerMatchQuarters")]
    public partial class SummonerMatchQuarter
    {
        [StringLength(20)]
        public string Region { get; set; }

        [Key]
        [Column(Order = 0)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public long SummonerID { get; set; }

        [Key]
        [Column(Order = 1)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public long MatchID { get; set; }

        [Key]
        [Column(Order = 2)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int TimeBucketID { get; set; }

        public long? DurationInSeconds { get; set; }

        public int ParticipantID { get; set; }

        [Required]
        [StringLength(20)]
        public string Tier { get; set; }

        [StringLength(10)]
        public string Division { get; set; }

        public int Team { get; set; }

        public int ChampionID { get; set; }

        [StringLength(20)]
        public string Role { get; set; }

        [StringLength(20)]
        public string Lane { get; set; }

        public int? ChampionKills { get; set; }

        public int? EliteMonsterKills { get; set; }

        public int? BuildingKills { get; set; }

        public int? Deaths { get; set; }

        public int? ChampionKillAssists { get; set; }

        public int? BuildingKillAssists { get; set; }

        public double? GoldPerMin { get; set; }

        public double? ExpPerMin { get; set; }

        public long? TotalDamageDealtByPlayer { get; set; }

        public long? TotalDamageTakenByPlayer { get; set; }

        public long? TotalDamageDealtToChampions { get; set; }

        public double? CreepsKilledPerMin { get; set; }

        public double? WardsPerMin { get; set; }

        public bool? MatchWin { get; set; }
    }
}
