using System;

namespace VehiclesWPF.Model
{
    class VehicleModel : ObservableObject
    {
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
                    OnPropertyChanged("FullName");
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
                    OnPropertyChanged("FullName");
                }
            }
        }

        public string FullName
        {
            get { return BrandName + " " + ModelName; }
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
                    OnPropertyChanged("ProductionYear");
                }
            }
        }

        public int ProductionYear
        {
            get
            {
                return ProductionDate.Year;
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

        public VehicleModel(string brandName = "Brand", string modelName = "Model", DateTime productionDate = new DateTime(), RegistrationNumber registrationNumber = null)
        {
            BrandName = brandName;
            ModelName = modelName;
            ProductionDate = productionDate;
            RegistrationNumber = registrationNumber;
        }
    }
}
