﻿using Gambler.Bot.AutoBet.Strategies;
using Gambler.Bot.AutoBet.Strategies.PresetListModels;
using System;
using System.Windows;
using System.Windows.Controls;

namespace KryGamesBotControls.Strategies.PresetList
{
    /// <summary>
    /// Interaction logic for PresetListControl.xaml
    /// </summary>
    public partial class PresetListControl : BaseControl, iStrategy
    {
        Gambler.Bot.Core.Games.Games Game = Gambler.Bot.Core.Games.Games.Dice;
        public Gambler.Bot.AutoBet.Strategies.PresetList Strategy { get; set; }
        public UserControl StartControl { get; set; } = new PresetDice();
        public PresetListControl()
        {
            InitializeComponent();
            this.DataContext = this;
            this.SizeChanged += PresetListControl_SizeChanged;
        }

        private void PresetListControl_SizeChanged(object sender, SizeChangedEventArgs e)
        {
            gcBets.Height = e.NewSize.Height - 24;
        }

        private void btnOpen_Click(object sender, RoutedEventArgs e)
        {

        }

        private void btnSaveSas_Click(object sender, RoutedEventArgs e)
        {

        }
    

        public event EventHandler StartBetting;

        public void GameChanged(Gambler.Bot.Core.Games.Games newGame)
        {
            Game = newGame;
            switch (newGame)
            {
                case Gambler.Bot.Core.Games.Games.Dice:
                    break;
            }
        }

        public void Saving()
        {
            //throw new NotImplementedException();
        }

        public void SetStrategy(BaseStrategy Strategy)
        {
            if (Strategy is Gambler.Bot.AutoBet.Strategies.PresetList lst)
            {
                this.Strategy = lst;
                
            }
            this.DataContext = this;
            StartControl.DataContext = this.Strategy;
            OnPropertyChanged(nameof(this.Strategy));
            tvBets.BestFitColumns();
        }

        public bool TopAlign()
        {
            return false;
        }

        private void TableView_AddingNewRow(object sender, System.ComponentModel.AddingNewEventArgs e)
        {
            switch (Game)
            {
                case Gambler.Bot.Core.Games.Games.Dice: e.NewObject = new PresetDiceBet { Amount = 0, Switch=false }; break;
            }
        }
    }
}
