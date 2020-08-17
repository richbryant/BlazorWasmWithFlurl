using System.Reactive.Threading.Tasks;
using System.Threading.Tasks;
using FlurlBlazor.Client.ViewModels;

namespace FlurlBlazor.Client.Views
{
    public partial class FetchDataView
    {
        public FetchDataView()
        {
            ViewModel = new FetchDataViewModel();
        }

        protected override async Task OnInitializedAsync()
        {
            await ViewModel.LoadForecasts.Execute().ToTask();
        }
    }
}
