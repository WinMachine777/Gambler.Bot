﻿using Gambler.Bot.Strategies.Helpers;
using Gambler.Bot.Common.Helpers;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System.ComponentModel.DataAnnotations;
using Gambler.Bot.Classes;
using Gambler.Bot.Common.Games.Dice;
using Gambler.Bot.Common.Games.Crash;
using Gambler.Bot.Common.Games.Plinko;
using Gambler.Bot.Common.Games.Roulette;
using Gambler.Bot.Common.Games.Limbo;

namespace Gambler.Bot.Core.Storage
{
    /// <summary>
    /// Base interface for reading and writing data to and from a database.
    /// </summary>
    public class BotContext:DbContext
    {
        public DbSet<SiteDetails> Sites { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<SeedDetails> Seeds { get; set; }
        public DbSet<Currency> Currencies { get; set; }
        public DbSet<SessionStats> Sessions { get; set; }
        public DbSet<DiceBet> DiceBets { get; set; }
        public DbSet<LimboBet> LimboBets { get; set; }
        public DbSet<CrashBet> CrashBets { get; set; }
        public DbSet<PlinkoBet> PlinkoBets { get; set; }
        public DbSet<RouletteBet> RouletteBets { get; set; }
        public DbSet<TwistBet> TwistBets { get; set; }


        protected readonly ILogger _Logger;
        public BotContext()
        {
            _Logger = null;
        }
        public BotContext(ILogger logger )
        {
            _Logger = logger;
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            string password = null;
            if (Settings?.EncryptConstring??false)
            {
                //raise eventy to get connection string
            }
            string connectionstring = Settings?.GetConnectionString(password);
            if (connectionstring == null)
                connectionstring = "Data Source=GamblerBot.db;";
            switch (Settings?.Provider)
            {
                default:
                case "Sqlite": optionsBuilder.UseSqlite(connectionstring); break;
                case "SQLServer": optionsBuilder.UseSqlServer(connectionstring); break;
                case "PostGres": optionsBuilder.UseNpgsql(connectionstring); break;
                //case "MongoDB": optionsBuilder.UseMongoDB(connectionstring, "GamblerBot"); break;
                case "MySQL": optionsBuilder.UseMySQL(connectionstring); break;
            }
            
            base.OnConfiguring(optionsBuilder);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<SiteDetails>().Ignore(t => t.GameSettings);
            base.OnModelCreating(modelBuilder);
        }
        public string ProviderName { get; protected set; }

        protected BotContext(string ConnectionString)
        {
            
        }
        

        public PersonalSettings Settings
        {
            get ;
            set;
        }



        public void CreateTables()
        {
            /*
             perform db migration
             */
        }

    }
    
  
    
    public class User
    {
        
        public SiteDetails Site { get; set; }
        public string UserName { get; set; }
        [Key]
        public string UserId { get; set; }
    }
    
    

    
}
