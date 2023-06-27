using CommunityToolkit.Mvvm.ComponentModel;
using System.Collections.ObjectModel;
using System.Dynamic;
using System.Net;
using System.Text.Json.Serialization;

namespace Insult_Generator.Models
{
    public partial class Insults : ObservableObject
    {
        [ObservableProperty] ObservableCollection<string> _tabOne;
        [ObservableProperty] ObservableCollection<string> _tabTwo;
        [ObservableProperty] ObservableCollection<string> _tabThree;
    }
}
