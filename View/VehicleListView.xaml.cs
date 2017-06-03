using System;
using System.Collections.ObjectModel;
using System.Windows;
using VehiclesWPF.Model;
using VehiclesWPF.ViewModel;

namespace VehiclesWPF.View
{
    public partial class VehicleListView : Window
    {
        public VehicleListView()
        {
            InitializeComponent();

            var vehicles = new ObservableCollection<VehicleModel>
            {
                new VehicleModel("Opel", "Vectra", new DateTime(2000,11,11), new RegistrationNumber("WWE 23123")),
                new VehicleModel("Audi", "A4", new DateTime(2004,07,21), new RegistrationNumber("WLS 12123")),
                new VehicleModel("Skoda", "Octavia", new DateTime(2011,05,25), new RegistrationNumber("LLU F3783")),
                new VehicleModel("Fiat", "Panda", new DateTime(2007,02,15), new RegistrationNumber("ZSZ AB111")),
                new VehicleModel("Mercedes", "Benz", new DateTime(2008,10,21), new RegistrationNumber("KRK YU553")),
                new VehicleModel("Volkswagen", "Passat", new DateTime(2007,02,15), new RegistrationNumber("WRC 2K234"))
            };

            DataContext = new VehicleListViewModel(vehicles);
        }

        protected override void OnClosed(EventArgs e)
        {
            base.OnClosed(e);

            Application.Current.Shutdown();
        }
    }
}
