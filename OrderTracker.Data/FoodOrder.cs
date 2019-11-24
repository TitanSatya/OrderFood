using System.Collections.Generic;
using System.ComponentModel;

namespace OrderTracker.Data
{
    public class FoodOrder : INotifyPropertyChanged
    {
        private string _OrderId;

        public string OrderId
        {
            get => _OrderId;
            set { _OrderId = value; OnPropertyChanged(nameof(OrderId)); }
        }

        private List<FoodItem> _FoodItems;

        public List<FoodItem> FoodItems
        {
            get => _FoodItems;
            set { _FoodItems = value; OnPropertyChanged(nameof(FoodItems)); }
        }
        private bool? _OrderAcceptanceStatus;

        public bool? OrderAcceptanceStatus
        {
            get => _OrderAcceptanceStatus;
            set
            {
                _OrderAcceptanceStatus = value;
                OnPropertyChanged(nameof(OrderAcceptanceStatus));
            }
        }
        private int _OrderPercentage;

        public int OrderPercentage
        {
            get => _OrderPercentage;
            set { _OrderPercentage = value; OnPropertyChanged(nameof(OrderPercentage)); }
        }


        private bool _IsComepleted;

        public bool IsComepleted
        {
            get => _IsComepleted;
            set => _IsComepleted = value;
        }




        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged(string propertyname)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyname));
        }
    }
}
