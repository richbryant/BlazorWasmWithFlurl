using System.Threading.Tasks;
using ReactiveUI;
using RxUnit = System.Reactive.Unit;

namespace FlurlBlazor.Client.ViewModels
{
    public class CounterViewModel : ReactiveObject
    {
        private int _currentCount;

        private readonly ObservableAsPropertyHelper<int> _count;

        public CounterViewModel()
        {
            Increment = ReactiveCommand.CreateFromTask(IncrementCount);

            _count = Increment.ToProperty(this, x => x.CurrentCount, scheduler: RxApp.MainThreadScheduler);
        }

        public int CurrentCount => _count.Value;

        public ReactiveCommand<RxUnit, int> Increment { get; }

        private Task<int> IncrementCount()
        {
            _currentCount++;
            return Task.FromResult(_currentCount);
        }
    }
}