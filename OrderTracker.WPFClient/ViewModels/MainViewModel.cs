using OrderTracker.Data;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Windows.Input;
using System.Windows.Threading;

namespace OrderTracker.WPFClient.ViewModels
{
    public class MainViewModel : BaseViewModel
    {
        private readonly Dispatcher dispatcher = Dispatcher.CurrentDispatcher;
        public ICommand AcceptCommand { get; private set; }
        public ICommand RejectCommand { get; private set; }
        public MainViewModel()
        {
            SignalStartup.Start();
            SignalStartup.OrderedFoods.CollectionChanged += OrderedFoods_CollectionChanged;
            OrderedFoods = new ObservableCollection<FoodOrder>();
            AcceptCommand = new RelayCommand((x) =>
               {
                   SignalStartup.HubProxy.Invoke("OrderAcceptance", x.ToString(), true);
                   OrderedFoods.FirstOrDefault(y => y.OrderId == x.ToString()).OrderAcceptanceStatus = true;
                   
               });
            RejectCommand = new RelayCommand((x) =>
                {
                    SignalStartup.HubProxy.Invoke("OrderAcceptance", x.ToString(), false);
                    OrderedFoods.FirstOrDefault(y => y.OrderId == x.ToString()).OrderAcceptanceStatus = false;
                    FilteredFoods = new ObservableCollection<FoodOrder>( OrderedFoods.Where(y => y.OrderAcceptanceStatus != false));
                });
            
        }
        private ObservableCollection<FoodOrder> _OrderedFoods = new ObservableCollection<FoodOrder>();
        private ObservableCollection<FoodOrder> _FilteredFoods;

        public ObservableCollection<FoodOrder> FilteredFoods
        {
            get { return _FilteredFoods; }
            set
            {
                _FilteredFoods = value;
                OnPropertyChanged(nameof(OrderedFoods));
            }
        }
      
        public ObservableCollection<FoodOrder> OrderedFoods
        {
            get => _OrderedFoods;
            set
            {
                _OrderedFoods = value;
                OnPropertyChanged(nameof(OrderedFoods));
                FilteredFoods = new ObservableCollection<FoodOrder>(value.Where(x => x.OrderAcceptanceStatus != false));
                
            }
        }

        private void OrderedFoods_CollectionChanged(object sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e)
        {
            FoodOrder newlyAddedFoodOrder = (sender as ObservableCollection<FoodOrder>).Except(OrderedFoods).FirstOrDefault();
            if (newlyAddedFoodOrder != null)
            {
                dispatcher.Invoke(() => OrderedFoods.Add(newlyAddedFoodOrder));
            }
            OnPropertyChanged(nameof(OrderedFoods));
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
