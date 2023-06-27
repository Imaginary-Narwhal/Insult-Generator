using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System;
using System.Collections.Generic;
using System.Diagnostics.Metrics;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Threading;
using Insult_Generator.Models;
using System.Text.Json.Serialization;
using System.Text.Json;
using System.IO;

namespace Insult_Generator.ViewModels;
public partial class MainViewModel : ObservableObject
{
    [ObservableProperty] private string _firstInsult;
    [ObservableProperty] private string _secondInsult;
    [ObservableProperty] private string _thirdInsult;
    [ObservableProperty] private string _buttonText;
    [ObservableProperty] private bool _isWaiting;

    private readonly DispatcherTimer timer;
    private Random rnd;
    private int countdown = 500;
    public MainViewModel()
    {
        ButtonText = "Insult Someone!";
        IsWaiting = true;

        var insults = JsonSerializer.Deserialize<Insults>(File.ReadAllText("insults.json"));
        rnd = new();
        
        timer = new();
        timer.Tick += (object s, EventArgs args) =>
        {
            IsWaiting = false;
            ButtonText = "Insulting ...";
            Application.Current.Dispatcher.Invoke(() =>
            {
                FirstInsult = insults.TabOne[rnd.Next(insults.TabOne.Count - 1)];
                SecondInsult = insults.TabTwo[rnd.Next(insults.TabTwo.Count - 1)];
                ThirdInsult = insults.TabThree[rnd.Next(insults.TabThree.Count - 1)];
            });
            countdown = countdown - 50;
            if(countdown < 0)
            {
                timer.Stop();
                IsWaiting = true;
                ButtonText = "Insult Someone!";
                countdown = 500;
            }
        };
        timer.Interval = TimeSpan.FromMilliseconds(50);
    }

    [RelayCommand]
    private void InsultSomeone()
    {
        timer.Start();
    }
}