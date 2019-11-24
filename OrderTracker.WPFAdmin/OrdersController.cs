using OrderTracker.Data;
using OrderTracker.WPFAdmin.ViewModels;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Threading;

namespace OrderTracker.WPFAdmin
{
    public class OrdersController :BaseViewModel
    {
        private Dispatcher dispatcher = Dispatcher.CurrentDispatcher;
        private static OrdersController instance = null;
        private static readonly object padlock = new object();

        OrdersController()
        {
            if (OrderedFoods == null)
            {
                OrderedFoods = new TrulyObservableCollection<FoodOrder>();
            }
        }
        public void AddFood(FoodOrder order)
        {
            dispatcher.Invoke(() => OrderedFoods.Add(order));
        }
        public static OrdersController Instance
        {
            get
            {
                lock (padlock)
                {
                    if (instance == null)
                    {
                        instance = new OrdersController();
                    }
                    return instance;
                }
            }
        }

        private TrulyObservableCollection<FoodOrder> _OrderedFoods;

        public TrulyObservableCollection<FoodOrder> OrderedFoods
        {
            get { return _OrderedFoods; }
            set { _OrderedFoods = value; OnPropertyChanged(nameof(OrderedFoods)); }
        }
         public void Refresh()
        {
            OnPropertyChanged(nameof(OrderedFoods));
        }
       
            

    }
    public class TrulyObservableCollection<T> : ObservableCollection<T>
where T : INotifyPropertyChanged
    {
        private Dispatcher dispatcher = Dispatcher.CurrentDispatcher;
        public TrulyObservableCollection()
        : base()
        {
            CollectionChanged += new NotifyCollectionChangedEventHandler(TrulyObservableCollection_CollectionChanged);
        }

        void TrulyObservableCollection_CollectionChanged(object sender, NotifyCollectionChangedEventArgs e)
        {
            if (e.NewItems != null)
            {
                foreach (Object item in e.NewItems)
                {
                    (item as INotifyPropertyChanged).PropertyChanged += new PropertyChangedEventHandler(item_PropertyChanged);
                }
            }
            if (e.OldItems != null)
            {
                foreach (Object item in e.OldItems)
                {
                    (item as INotifyPropertyChanged).PropertyChanged -= new PropertyChangedEventHandler(item_PropertyChanged);
                }
            }
        }

        void item_PropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            NotifyCollectionChangedEventArgs a = new NotifyCollectionChangedEventArgs(NotifyCollectionChangedAction.Reset);
            dispatcher.Invoke(() => OnCollectionChanged(a));
        }
    }
}
