using System;
using System.Windows.Input;
using VehiclesWPF.Model;

namespace VehiclesWPF.ViewModel
{
    class VehicleViewModel : ObservableObject
    {
        private VehicleModel vehicle;
        public VehicleModel Vehicle
        {
            get { return vehicle; }
            set
            {
                vehicle = value;
                OnPropertyChanged("Vehicle");
            }
        }

        private string brandName;
        public string BrandName
        {
            get { return brandName; }
            set
            {
                if (value != brandName)
                {
                    brandName = value;
                    OnPropertyChanged("BrandName");
                }
            }
        }

        private string modelName;
        public string ModelName
        {
            get { return modelName; }
            set
            {
                if (value != modelName)
                {
                    modelName = value;
                    OnPropertyChanged("ModelName");
                }
            }
        }

        private DateTime productionDate;
        public DateTime ProductionDate
        {
            get { return productionDate; }
            set
            {
                if (value != productionDate)
                {
                    productionDate = value;
                    OnPropertyChanged("ProductionDate");
                }
            }
        }

        private RegistrationNumber registrationNumber;
        public RegistrationNumber RegistrationNumber
        {
            get { return registrationNumber; }
            set
            {
                if (value != registrationNumber)
                {
                    registrationNumber = value;
                    OnPropertyChanged("RegistrationNumber");
                }
            }
        }

        private ICommand saveVehicleCommand;
        public ICommand SaveVehicleCommand
        {
            get
            {
                if (saveVehicleCommand == null)
                {
                    saveVehicleCommand = new RelayCommand(
                        param => saveVehicle()
                    );
                }
                return saveVehicleCommand;
            }
        }

        private ICommand closeVehicleCommand;
        public ICommand CloseVehicleCommand
        {
            get
            {
                if (closeVehicleCommand == null)
                {
                    closeVehicleCommand = new RelayCommand(
                        param => saveVehicle()
                    );
                }
                return closeVehicleCommand;
            }
        }

        public VehicleViewModel(VehicleModel vehicle)
        {
            Vehicle = vehicle;
            BrandName = Vehicle.BrandName;
            ModelName = vehicle.ModelName;
            ProductionDate = vehicle.ProductionDate;
            RegistrationNumber = vehicle.RegistrationNumber;
        }

        private void saveVehicle()
        {
            Vehicle.BrandName = BrandName;
            Vehicle.ModelName = ModelName;
            Vehicle.ProductionDate = ProductionDate;
            Vehicle.RegistrationNumber = RegistrationNumber;
        }
    }
}
