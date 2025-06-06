﻿// <auto-generated />
using System;
using Gambler.Bot.Core.Storage;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace Gambler.Bot.Strategies.Migrations
{
    [DbContext(typeof(BotContext))]
    [Migration("20250320082451_nullableclientseed")]
    partial class nullableclientseed
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder.HasAnnotation("ProductVersion", "9.0.3");

            modelBuilder.Entity("Gambler.Bot.Common.Games.Crash.CrashBet", b =>
                {
                    b.Property<string>("BetID")
                        .HasColumnType("TEXT");

                    b.Property<decimal>("Amount")
                        .HasColumnType("TEXT");

                    b.Property<decimal>("Crash")
                        .HasColumnType("TEXT");

                    b.Property<string>("Currency")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<decimal>("Date")
                        .HasColumnType("TEXT");

                    b.Property<decimal>("Edge")
                        .HasColumnType("TEXT");

                    b.Property<int>("Game")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Guid")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<bool>("IsWin")
                        .HasColumnType("INTEGER");

                    b.Property<long>("Nonce")
                        .HasColumnType("INTEGER");

                    b.Property<decimal>("Payout")
                        .HasColumnType("TEXT");

                    b.Property<decimal>("Profit")
                        .HasColumnType("TEXT");

                    b.Property<string>("ServerHash")
                        .HasColumnType("TEXT");

                    b.Property<string>("ServerSeed")
                        .HasColumnType("TEXT");

                    b.Property<string>("Site")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<decimal>("TotalAmount")
                        .HasColumnType("TEXT");

                    b.Property<long>("Userid")
                        .HasColumnType("INTEGER");

                    b.HasKey("BetID");

                    b.ToTable("CrashBets");
                });

            modelBuilder.Entity("Gambler.Bot.Common.Games.Dice.DiceBet", b =>
                {
                    b.Property<string>("BetID")
                        .HasColumnType("TEXT");

                    b.Property<decimal>("Chance")
                        .HasColumnType("TEXT");

                    b.Property<string>("ClientSeed")
                        .HasColumnType("TEXT");

                    b.Property<string>("Currency")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<decimal>("Date")
                        .HasColumnType("TEXT");

                    b.Property<decimal>("Edge")
                        .HasColumnType("TEXT");

                    b.Property<int>("Game")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Guid")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<bool>("High")
                        .HasColumnType("INTEGER");

                    b.Property<bool>("IsWin")
                        .HasColumnType("INTEGER");

                    b.Property<long>("Nonce")
                        .HasColumnType("INTEGER");

                    b.Property<decimal>("Profit")
                        .HasColumnType("TEXT");

                    b.Property<decimal>("Roll")
                        .HasColumnType("TEXT");

                    b.Property<string>("ServerHash")
                        .HasColumnType("TEXT");

                    b.Property<string>("ServerSeed")
                        .HasColumnType("TEXT");

                    b.Property<string>("Site")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<decimal>("TotalAmount")
                        .HasColumnType("TEXT");

                    b.Property<long>("Userid")
                        .HasColumnType("INTEGER");

                    b.Property<int>("WinnableType")
                        .HasColumnType("INTEGER");

                    b.HasKey("BetID");

                    b.ToTable("DiceBets");
                });

            modelBuilder.Entity("Gambler.Bot.Common.Games.Limbo.LimboBet", b =>
                {
                    b.Property<string>("BetID")
                        .HasColumnType("TEXT");

                    b.Property<string>("ClientSeed")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("Currency")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<decimal>("Date")
                        .HasColumnType("TEXT");

                    b.Property<decimal>("Edge")
                        .HasColumnType("TEXT");

                    b.Property<int>("Game")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Guid")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<bool>("IsWin")
                        .HasColumnType("INTEGER");

                    b.Property<long>("Nonce")
                        .HasColumnType("INTEGER");

                    b.Property<decimal>("Payout")
                        .HasColumnType("TEXT");

                    b.Property<decimal>("Profit")
                        .HasColumnType("TEXT");

                    b.Property<decimal>("Result")
                        .HasColumnType("TEXT");

                    b.Property<string>("ServerHash")
                        .HasColumnType("TEXT");

                    b.Property<string>("ServerSeed")
                        .HasColumnType("TEXT");

                    b.Property<string>("Site")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<decimal>("TotalAmount")
                        .HasColumnType("TEXT");

                    b.Property<long>("Userid")
                        .HasColumnType("INTEGER");

                    b.Property<int>("WinnableType")
                        .HasColumnType("INTEGER");

                    b.HasKey("BetID");

                    b.ToTable("LimboBets");
                });

            modelBuilder.Entity("Gambler.Bot.Common.Games.Plinko.PlinkoBet", b =>
                {
                    b.Property<string>("BetID")
                        .HasColumnType("TEXT");

                    b.Property<string>("Currency")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<decimal>("Date")
                        .HasColumnType("TEXT");

                    b.Property<decimal>("Edge")
                        .HasColumnType("TEXT");

                    b.Property<int>("Game")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Guid")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<bool>("IsWin")
                        .HasColumnType("INTEGER");

                    b.Property<decimal>("Profit")
                        .HasColumnType("TEXT");

                    b.Property<string>("Site")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<decimal>("TotalAmount")
                        .HasColumnType("TEXT");

                    b.Property<long>("Userid")
                        .HasColumnType("INTEGER");

                    b.HasKey("BetID");

                    b.ToTable("PlinkoBets");
                });

            modelBuilder.Entity("Gambler.Bot.Common.Games.Roulette.RouletteBet", b =>
                {
                    b.Property<string>("BetID")
                        .HasColumnType("TEXT");

                    b.Property<string>("Currency")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<decimal>("Date")
                        .HasColumnType("TEXT");

                    b.Property<decimal>("Edge")
                        .HasColumnType("TEXT");

                    b.Property<int>("Game")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Guid")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<bool>("IsWin")
                        .HasColumnType("INTEGER");

                    b.Property<decimal>("Profit")
                        .HasColumnType("TEXT");

                    b.Property<string>("Site")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<decimal>("TotalAmount")
                        .HasColumnType("TEXT");

                    b.Property<long>("Userid")
                        .HasColumnType("INTEGER");

                    b.HasKey("BetID");

                    b.ToTable("RouletteBets");
                });

            modelBuilder.Entity("Gambler.Bot.Common.Helpers.Currency", b =>
                {
                    b.Property<string>("Symbol")
                        .HasColumnType("TEXT");

                    b.Property<byte[]>("Icon")
                        .IsRequired()
                        .HasColumnType("BLOB");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("Symbol");

                    b.ToTable("Currencies");
                });

            modelBuilder.Entity("Gambler.Bot.Common.Helpers.SeedDetails", b =>
                {
                    b.Property<string>("ServerHash")
                        .HasColumnType("TEXT");

                    b.Property<string>("ClientSeed")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<long?>("Nonce")
                        .HasColumnType("INTEGER");

                    b.Property<string>("PreviousClient")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("PreviousHash")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("PreviousServer")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("ServerSeed")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("ServerHash");

                    b.ToTable("Seeds");
                });

            modelBuilder.Entity("Gambler.Bot.Common.Helpers.SiteDetails", b =>
                {
                    b.Property<string>("name")
                        .HasColumnType("TEXT");

                    b.PrimitiveCollection<string>("Currencies")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.PrimitiveCollection<string>("Games")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<bool>("NonceBased")
                        .HasColumnType("INTEGER");

                    b.Property<bool>("canbank")
                        .HasColumnType("INTEGER");

                    b.Property<bool>("caninvest")
                        .HasColumnType("INTEGER");

                    b.Property<bool>("canresetseed")
                        .HasColumnType("INTEGER");

                    b.Property<bool>("cantip")
                        .HasColumnType("INTEGER");

                    b.Property<bool>("canwithdraw")
                        .HasColumnType("INTEGER");

                    b.Property<decimal>("edge")
                        .HasColumnType("TEXT");

                    b.Property<decimal>("maxroll")
                        .HasColumnType("TEXT");

                    b.Property<string>("siteurl")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<bool>("tipusingname")
                        .HasColumnType("INTEGER");

                    b.HasKey("name");

                    b.ToTable("Sites");
                });

            modelBuilder.Entity("Gambler.Bot.Core.Storage.User", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("TEXT");

                    b.Property<string>("Sitename")
                        .HasColumnType("TEXT");

                    b.Property<string>("UserName")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("UserId");

                    b.HasIndex("Sitename");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("Gambler.Bot.Strategies.Helpers.SessionStats", b =>
                {
                    b.Property<int>("SessionStatsId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<decimal>("AvgLoss")
                        .HasColumnType("TEXT");

                    b.Property<decimal>("AvgStreak")
                        .HasColumnType("TEXT");

                    b.Property<decimal>("AvgWin")
                        .HasColumnType("TEXT");

                    b.Property<long>("BestStreak")
                        .HasColumnType("INTEGER");

                    b.Property<long>("BestStreak2")
                        .HasColumnType("INTEGER");

                    b.Property<long>("BestStreak3")
                        .HasColumnType("INTEGER");

                    b.Property<long>("Bets")
                        .HasColumnType("INTEGER");

                    b.Property<decimal>("CurrentProfit")
                        .HasColumnType("TEXT");

                    b.Property<DateTime>("EndTime")
                        .HasColumnType("TEXT");

                    b.Property<decimal>("LargestBet")
                        .HasColumnType("TEXT");

                    b.Property<decimal>("LargestLoss")
                        .HasColumnType("TEXT");

                    b.Property<decimal>("LargestWin")
                        .HasColumnType("TEXT");

                    b.Property<long>("LossStreak")
                        .HasColumnType("INTEGER");

                    b.Property<long>("Losses")
                        .HasColumnType("INTEGER");

                    b.Property<decimal>("Luck")
                        .HasColumnType("TEXT");

                    b.Property<decimal>("MaxProfit")
                        .HasColumnType("TEXT");

                    b.Property<decimal>("MaxProfitSinceReset")
                        .HasColumnType("TEXT");

                    b.Property<decimal>("MinProfit")
                        .HasColumnType("TEXT");

                    b.Property<decimal>("MinProfitSinceReset")
                        .HasColumnType("TEXT");

                    b.Property<long>("NumLossStreaks")
                        .HasColumnType("INTEGER");

                    b.Property<long>("NumStreaks")
                        .HasColumnType("INTEGER");

                    b.Property<long>("NumWinStreaks")
                        .HasColumnType("INTEGER");

                    b.Property<decimal>("PorfitSinceLimitAction")
                        .HasColumnType("TEXT");

                    b.Property<decimal>("Profit")
                        .HasColumnType("TEXT");

                    b.Property<decimal>("ProfitPer24Hour")
                        .HasColumnType("TEXT");

                    b.Property<decimal>("ProfitPerBet")
                        .HasColumnType("TEXT");

                    b.Property<decimal>("ProfitPerHour")
                        .HasColumnType("TEXT");

                    b.Property<decimal>("ProfitSinceLastReset")
                        .HasColumnType("TEXT");

                    b.Property<long>("RunningTime")
                        .HasColumnType("INTEGER");

                    b.Property<bool>("Simulation")
                        .HasColumnType("INTEGER");

                    b.Property<DateTime>("StartTime")
                        .HasColumnType("TEXT");

                    b.Property<decimal>("StreakLossSinceLastReset")
                        .HasColumnType("TEXT");

                    b.Property<decimal>("StreakProfitSinceLastReset")
                        .HasColumnType("TEXT");

                    b.Property<decimal>("Wagered")
                        .HasColumnType("TEXT");

                    b.Property<long>("WinStreak")
                        .HasColumnType("INTEGER");

                    b.Property<long>("Wins")
                        .HasColumnType("INTEGER");

                    b.Property<long>("WorstStreak")
                        .HasColumnType("INTEGER");

                    b.Property<long>("WorstStreak2")
                        .HasColumnType("INTEGER");

                    b.Property<long>("WorstStreak3")
                        .HasColumnType("INTEGER");

                    b.Property<long>("laststreaklose")
                        .HasColumnType("INTEGER");

                    b.Property<long>("laststreakwin")
                        .HasColumnType("INTEGER");

                    b.Property<long>("winsAtLastReset")
                        .HasColumnType("INTEGER");

                    b.HasKey("SessionStatsId");

                    b.ToTable("Sessions");
                });

            modelBuilder.Entity("Gambler.Bot.Core.Storage.User", b =>
                {
                    b.HasOne("Gambler.Bot.Common.Helpers.SiteDetails", "Site")
                        .WithMany()
                        .HasForeignKey("Sitename");

                    b.Navigation("Site");
                });
#pragma warning restore 612, 618
        }
    }
}
