namespace OrderTracker.WPFAdmin.ViewModels
{
    public class MainViewModel : BaseViewModel
    {
        public OrdersViewModel OrdersVM { get; set; } = new OrdersViewModel();

        private bool? _IsPlaceOrderChecked;

        public bool? IsPlaceOrderChecked
        {
            get => _IsPlaceOrderChecked;
            set
            {
                _IsPlaceOrderChecked = value;
                IsHomeChecked = false;
                //IsOrderStatusChecked = false;
                //IsBeveragesChecked = false;
                //IsOrderHistoryChecked = false;
                OnPropertyChanged(nameof(IsPlaceOrderChecked));
            }
        }

        private bool? _IsOrderStatusChecked;

        public bool? IsOrderStatusChecked
        {
            get => _IsOrderStatusChecked;
            set
            {
                _IsOrderStatusChecked = value;
                //IsPlaceOrderChecked = false;
                //IsHomeChecked = false;

                //IsBeveragesChecked = false;
                //IsOrderHistoryChecked = false;
                OnPropertyChanged(nameof(IsOrderStatusChecked));
            }
        }

        private bool _IsBeveragesChecked;

        public bool IsBeveragesChecked
        {
            get => _IsBeveragesChecked;
            set
            {
                _IsBeveragesChecked = value;
                //IsPlaceOrderChecked = false;
                //IsHomeChecked = false;
                //IsOrderStatusChecked = false;

                //IsOrderHistoryChecked = false;
                OnPropertyChanged(nameof(IsBeveragesChecked));
            }
        }

        private bool _IsOrderHistoryChecked;

        public bool IsOrderHistoryChecked
        {
            get => _IsOrderHistoryChecked;
            set
            {
                _IsOrderHistoryChecked = value;
                //IsPlaceOrderChecked = false;
                //IsHomeChecked = false;
                //IsOrderStatusChecked = false;
                //IsBeveragesChecked = false;

                OnPropertyChanged(nameof(IsOrderHistoryChecked));
            }
        }

        private bool _IsHomeChecked = true;

        public bool IsHomeChecked
        {
            get => _IsHomeChecked;
            set
            {
                _IsHomeChecked = value;

                OnPropertyChanged(nameof(IsHomeChecked));
            }
        }
        public MainViewModel()
        {
            SignalStartup.Start();
        }
    }
}
