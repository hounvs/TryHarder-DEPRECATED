namespace TryHarder.Models
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class Model1 : DbContext
    {
        public Model1()
            : base("name=Model1")
        {
        }

        public virtual DbSet<Champion> Champions { get; set; }
        public virtual DbSet<Match> Matches { get; set; }
        public virtual DbSet<SummonerMatchQuarter> SummonerMatchQuarters { get; set; }
        public virtual DbSet<Summoner> Summoners { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Champion>()
                .Property(e => e.Champion1)
                .IsUnicode(false);

            modelBuilder.Entity<Match>()
                .Property(e => e.Queue)
                .IsUnicode(false);

            modelBuilder.Entity<SummonerMatchQuarter>()
                .Property(e => e.Region)
                .IsUnicode(false);

            modelBuilder.Entity<SummonerMatchQuarter>()
                .Property(e => e.Tier)
                .IsUnicode(false);

            modelBuilder.Entity<SummonerMatchQuarter>()
                .Property(e => e.Division)
                .IsUnicode(false);

            modelBuilder.Entity<SummonerMatchQuarter>()
                .Property(e => e.Role)
                .IsUnicode(false);

            modelBuilder.Entity<SummonerMatchQuarter>()
                .Property(e => e.Lane)
                .IsUnicode(false);

            modelBuilder.Entity<Summoner>()
                .Property(e => e.Summoner1)
                .IsUnicode(false);
        }
    }
}
