using System.Reactive.Threading.Tasks;
using System.Threading.Tasks;
using FlurlBlazor.Client.ViewModels;

namespace FlurlBlazor.Client.Views
{
    public partial class GreetingView
    {
        public GreetingView()
        {
            ViewModel = new GreetingViewModel();
        }

        public async Task Clear()
        {
            await ViewModel.Clear.Execute().ToTask();
        }
    }
}
