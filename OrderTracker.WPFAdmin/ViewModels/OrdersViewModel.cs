using OrderTracker.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Windows.Input;
namespace OrderTracker.WPFAdmin.ViewModels
{
    public class OrdersViewModel : BaseViewModel
    {
        #region Properties
        private List<FoodItem> _AddedFood;

        public List<FoodItem> AddedFood
        {
            get => _AddedFood;
            set { _AddedFood = value; OnPropertyChanged(nameof(AddedFood)); }
        }

        private bool _IsAllFood;

        public bool IsAllFood
        {
            get => _IsAllFood;
            set
            {
                _IsAllFood = value;
                FilteredFoodItems = (value) ? FoodItems.FindAll(x => !x.IsVeg) : FoodItems.FindAll(x => x.IsVeg);
                OnPropertyChanged(nameof(IsAllFood));
            }
        }

        private List<FoodItem> _FoodItems;

        public List<FoodItem> FoodItems
        {
            get => _FoodItems;
            set { _FoodItems = value; OnPropertyChanged(nameof(FoodItems)); }
        }

        private List<FoodItem> _FilteredFoodItems;

        public List<FoodItem> FilteredFoodItems
        {
            get => _FilteredFoodItems;
            set { _FilteredFoodItems = value; OnPropertyChanged(nameof(FilteredFoodItems)); }
        }
        public ICommand AddFoodCommand { get; set; }
        public ICommand PlaceOrderCommand { get; set; }
        private double _TotalAmount;

        public double TotalAmount
        {
            get => _TotalAmount;
            set { _TotalAmount = value; OnPropertyChanged(nameof(TotalAmount)); }
        }
        private int _TotalCount;

        public int TotalCount
        {
            get => _TotalCount;
            set { _TotalCount = value; OnPropertyChanged(nameof(TotalCount)); }
        }
        private string _OrderNumber;

        public string OrderNumber
        {
            get => _OrderNumber;
            set { _OrderNumber = value; OnPropertyChanged(nameof(OrderNumber)); }
        }

        #endregion

        public OrdersViewModel()
        {
            GetAllFoodItems();
            AddFoodCommand = new RelayCommand((x) => ExecuteAddFoodCommand(x));
            AddedFood = new List<FoodItem>();
            PlaceOrderCommand = new RelayCommand((x) =>
            {
                ExecutePlaceOrderCommand(x);
            }, x => AddedFood.Any());

        }

        private void ExecutePlaceOrderCommand(object x)
        {
            //Generate A Unique Order number
            OrderNumber = string.Concat(IsAllFood ? "N" : "V", Guid.NewGuid().ToString().Replace("-", ""));
            SignalStartup.HubProxy.Invoke("OrderFood", AddedFood, OrderNumber);
            OrdersController.Instance.AddFood(new FoodOrder()
            {
                FoodItems = AddedFood,
                OrderId = OrderNumber,
                IsComepleted = false,
                OrderAcceptanceStatus = null,
                OrderPercentage = 0

            });
            AddedFood = new List<FoodItem>();
            TotalAmount = 0;
            TotalCount = 0;
        }

        private void ExecuteAddFoodCommand(object x)
        {
            AddedFood.Add(FoodItems.Find(y => y.FoodId == (int)x));
            TotalAmount = AddedFood.Sum(z => z.Price);
            TotalCount = AddedFood.Count();
        }

        private void GetAllFoodItems()
        {
            IFoodDataProvider provider = new TempFoodDataProvider();
            FoodItems = provider.GetFoodItems()?.ToList();
            FilteredFoodItems = new List<FoodItem>(FoodItems);
        }

    }
    public class BaseViewModel : INotifyPropertyChanged
    {
        protected virtual bool ThrowOnInvalidPropertyName
        {
            get;
            private set;
        }
        [Conditional("DEBUG")]
        [DebuggerStepThrough]
        public void VerifyPropertyName(string propertyName)
        {
            // Verify that the property name matches a real,
            // public, instance property on this object.
            if (TypeDescriptor.GetProperties(this)[propertyName] == null)
            {
                string msg = "Invalid property name: " + propertyName;

                if (ThrowOnInvalidPropertyName)
                {
                    throw new Exception(msg);
                }

                Debug.Fail(msg);
            }
        }
        public event PropertyChangedEventHandler PropertyChanged;
        protected virtual void OnPropertyChanged(string PropertyName)
        {
            VerifyPropertyName(PropertyName);
            PropertyChangedEventHandler handler = PropertyChanged;
            if (handler == null)
            {
                return;
            }

            PropertyChangedEventArgs e = new PropertyChangedEventArgs(PropertyName);
            handler(this, e);
        }
    }
}
