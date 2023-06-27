using AdonisUI.Controls;
using Insult_Generator.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace Insult_Generator.Views;
/// <summary>
/// Interaction logic for MainView.xaml
/// </summary>
public partial class MainView : AdonisWindow
{
    private readonly MainViewModel viewModel;
    public MainView()
    {

        InitializeComponent();

        ((App)Application.Current).WindowPlace.Register(this);

        viewModel = new();
        DataContext = viewModel;
    }
}
