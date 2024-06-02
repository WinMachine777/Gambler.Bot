﻿using Avalonia.Threading;
using Gambler.Bot.AutoBet.Helpers;
using Gambler.Bot.AutoBet.Strategies.Abstractions;
using Gambler.Bot.Common.Events;
using Gambler.Bot.Common.Interfaces;
using Gambler.Bot.Core.Events;
using Gambler.Bot.Core.Sites;
using Microsoft.Extensions.Logging;
using ReactiveUI;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using static Community.CsharpSqlite.Sqlite3;

namespace Gambler.Bot.ViewModels.Common
{
    public class SimulationViewModel:ViewModelBase
    {
        Stopwatch SimTimer = new Stopwatch();

        private BaseSite currentsite;

        public BaseSite CurrentSite
        {
            get { return currentsite; }
            set { currentsite = value; }
        }

        private BaseStrategy strategy;

        public BaseStrategy Strategy
        {
            get { return strategy; }
            set { strategy = value; }
        }

        public InternalBetSettings BetSettings { get; set; }

        private Gambler.Bot.AutoBet.Helpers.Simulation simulation;

        public Gambler.Bot.AutoBet.Helpers.Simulation CurrentSimulation
        {
            get { return simulation; }
            set { simulation = value; }
        }

        private SessionStatsViewModel statsViewModel;

        public SessionStatsViewModel Stats
        {
            get { return statsViewModel; }
            set { statsViewModel = value; }
        }

        private decimal startingBalance;

        public decimal StartingBalance
        {
            get { return startingBalance; }
            set { startingBalance = value; }
        }

        private long numberOfBets;

        public long NumberOfBets
        {
            get { return numberOfBets; }
            set { numberOfBets = value; }
        }

        private decimal progress;

        public decimal Progress
        {
            get { return progress; }
            set { progress = value; this.RaisePropertyChanged(); }
        }

        public TimeSpan TimeRunning { get; set; }
        public TimeSpan ProjectedTime { get; set; }
        public TimeSpan ProjectedRemaining { get; set; }


        public SimulationViewModel(ILogger logger):base(logger)
        {
           StartCommand = ReactiveCommand.Create(Start);
            StopCommand = ReactiveCommand.Create(Stop);
            SaveCommand = ReactiveCommand.Create(Save);
            Stats = new SessionStatsViewModel(logger);
        }

        private bool canSave;

        public bool CanSave
        {
            get { return canSave; }
            set { canSave = value; this.RaisePropertyChanged(); }
        }

        private bool log=true;

        public bool Log
        {
            get { return log; }
            set { log = value; this.RaisePropertyChanged(); }
        }

        private bool running;

        public bool Running
        {
            get { return running; }
            set { running = value; this.RaisePropertyChanged(); this.RaisePropertyChanged(nameof(NotRunning)); }
        }

        public bool NotRunning
        {
            get { return !Running; }            
        }

        public ICommand StopCommand { get; }
        void Stop()
        {
            CurrentSimulation?.StopSim();
        }

        public ICommand StartCommand { get; }
        void Start()
        {
            if (Running)
                return;
            CurrentSimulation = new Gambler.Bot.AutoBet.Helpers.Simulation(null);
            CurrentSimulation.Initialize(StartingBalance, NumberOfBets, CurrentSite, currentsite.SiteDetails, Strategy, BetSettings, "tmp.sim", Log);
            CanSave = false;
            CurrentSimulation.OnSimulationWriting += CurrentSimulation_OnSimulationWriting;
            CurrentSimulation.OnSimulationComplete += CurrentSimulation_OnSimulationComplete;
            CurrentSimulation.OnBetSimulated += CurrentSimulation_OnBetSimulated;
            SimTimer.Start();
            Running = true;
            CanSave = false;
            CurrentSimulation.Start();
            Stats.Stats = CurrentSimulation.Stats;
        }
        List<decimal> Bets = new List<decimal>();
        private void CurrentSimulation_OnBetSimulated(object? sender, BetFinisedEventArgs e)
        {
            //Bets.Add(e.NewBet.Profit);
            if (Bets.Count > 0 && Bets.Count % 100 == 0)
            {
               /* if (chrt.Enabled)
                {
                    chrt.AddRange(Bets);
                    Bets = new List<decimal>();
                }*/
            }
        }

        private void CurrentSimulation_OnSimulationComplete(object? sender, EventArgs e)
        {
            Finished();
        }

        void Finished()
        {
            if (!Dispatcher.UIThread.CheckAccess())
                Dispatcher.UIThread.Invoke(Finished);
            else
            {
                
                SimTimer.Stop();
                Gambler.Bot.AutoBet.Helpers.Simulation tmp = CurrentSimulation;
                Stats.StatsUpdated(tmp.Stats);
                long ElapsedMilliseconds = SimTimer.ElapsedMilliseconds;
                Progress = (decimal)tmp.TotalBetsPlaced / (decimal)tmp.Bets;
                decimal totaltime = ElapsedMilliseconds / Progress;
                TimeRunning = TimeSpan.FromMilliseconds(ElapsedMilliseconds);
                ProjectedTime = TimeSpan.FromMilliseconds((double)totaltime);
                ProjectedRemaining = TimeSpan.FromMilliseconds((double)totaltime - ElapsedMilliseconds);

                this.RaisePropertyChanged(nameof(Progress));
                this.RaisePropertyChanged(nameof(TimeRunning));
                this.RaisePropertyChanged(nameof(ProjectedTime));
                this.RaisePropertyChanged(nameof(ProjectedRemaining));
                this.RaisePropertyChanged(nameof(CurrentSimulation));

                Running = false;
                SimTimer.Reset();
                CanSave = true;
            }
        }

        void UpdateStats()
        {
            if (!Dispatcher.UIThread.CheckAccess())
                Dispatcher.UIThread.Invoke(UpdateStats);
            else
            {
                Gambler.Bot.AutoBet.Helpers.Simulation tmp = CurrentSimulation;
                //Console.WriteLine("Simulation Progress: " + tmp.TotalBetsPlaced + " bets of " + tmp.Bets);

                if (tmp.TotalBetsPlaced > 0)
                {
                    long ElapsedMilliseconds = SimTimer.ElapsedMilliseconds;
                    progress = (decimal)tmp.TotalBetsPlaced / (decimal)tmp.Bets;

                    decimal totaltime = ElapsedMilliseconds / Progress;
                    TimeRunning = TimeSpan.FromMilliseconds(ElapsedMilliseconds);
                    ProjectedTime = TimeSpan.FromMilliseconds((double)totaltime);
                    ProjectedRemaining = TimeSpan.FromMilliseconds((double)totaltime - ElapsedMilliseconds);

                    this.RaisePropertyChanged(nameof(Progress));
                    this.RaisePropertyChanged(nameof(TimeRunning));
                    this.RaisePropertyChanged(nameof(ProjectedTime));
                    this.RaisePropertyChanged(nameof(ProjectedRemaining));
                    this.RaisePropertyChanged(nameof(CurrentSimulation));
                    Stats.StatsUpdated(CurrentSimulation.Stats);
                }
            }
        }

        private void CurrentSimulation_OnSimulationWriting(object? sender, EventArgs e)
        {
            UpdateStats();
        }

        public ICommand SaveCommand { get; }
        public void Save()
        {
           /* SaveFileDialog dg = new SaveFileDialog();
            if (dg.ShowDialog() ?? false)
            {
                CurrentSimulation.MoveLog(dg.FileName);
            }*/
        }
    }
}
