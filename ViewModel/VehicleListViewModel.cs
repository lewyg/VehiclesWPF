using System;
using System.Collections.ObjectModel;
using System.Windows;
using System.Windows.Input;
using VehiclesWPF.Common;
using VehiclesWPF.Model;

namespace VehiclesWPF.ViewModel
{
    class VehicleListViewModel : ObservableObject
    {
        private ObservableCollection<VehicleModel> vehicles;
        public ObservableCollection<VehicleModel> Vehicles
        {
            get { return vehicles; }
            set
            {
                vehicles = value;
                OnPropertyChanged("Vehicles");
            }
        }

        private VehicleModel selectedVehucle;
        public VehicleModel SelectedVehicle
        {
            get { return selectedVehucle; }
            set
            {
                selectedVehucle = value;
                OnPropertyChanged("SelectedVehicle");
            }
        }

        private ICommand addVehicleCommand;
        public ICommand AddVehicleCommand
        {
            get
            {
                if (addVehicleCommand == null)
                {
                    addVehicleCommand = new RelayCommand(
                        view => addVehicle(view)
                    );
                }
                return addVehicleCommand;
            }
        }

        private ICommand removeVehicleCommand;
        public ICommand RemoveVehicleCommand
        {
            get
            {
                if (removeVehicleCommand == null)
                {
                    removeVehicleCommand = new RelayCommand(
                        param => Vehicles.Remove(SelectedVehicle),
                        param => Vehicles.Count > 0 && SelectedVehicle != null
                    );
                }
                return removeVehicleCommand;
            }
        }

        private ICommand showVehicleCommand;
        public ICommand ShowVehicleCommand
        {
            get
            {
                if (showVehicleCommand == null)
                {
                    showVehicleCommand = new RelayCommand(
                        view => showVehicle(view),
                        param => Vehicles.Count > 0 && SelectedVehicle != null
                    );
                }
                return showVehicleCommand;
            }
        }

        public VehicleListViewModel(ObservableCollection<VehicleModel> vehicles)
        {
            Vehicles = vehicles;
        }

        private void addVehicle(object param)
        {
            var vehicle = new VehicleModel();

            Vehicles.Add(vehicle);
            SelectedVehicle = vehicle;

            if (param != null)
                showVehicle(param);
        }

        private void showVehicle(object param)
        {
            if (param is Window)
            {
                var view = (Window)Activator.CreateInstance(param.GetType());
                view.DataContext = new VehicleViewModel(SelectedVehicle);
                view.ShowDialog();
            }
        }
    }
}
