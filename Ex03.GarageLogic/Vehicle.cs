using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex03.GarageLogic
{
    public abstract class Vehicle
    {
        private string m_VehicleVendor;
        private string m_LicensePlate;
        private Energy m_VehicleEnergySource;
        private List<Wheel> m_WheelsCollection;

        public Vehicle(string i_LicensePlate)
        {
            m_LicensePlate = i_LicensePlate;
        }
        
        public Vehicle(string i_VehicleVendor, string i_LicensePlate, int i_NumOfWheels, Wheel i_VehicleWheel, Energy i_VehicleEnergy)
        {
            m_VehicleVendor = i_VehicleVendor;
            m_LicensePlate = i_LicensePlate;
            m_VehicleEnergySource = i_VehicleEnergy;
            m_WheelsCollection = new List<Wheel>();
            for (int i = 1; i <= i_NumOfWheels; i++)
            {
                m_WheelsCollection.Add(i_VehicleWheel);
            }
        }

        public abstract void InitVehicleData(string i_VehicleVendor, int i_NumOfWheels, Wheel i_VehicleWheel, Energy i_VehicleEnergy, Dictionary<string, string> i_ExtraProperties);

        public string VehicleVendor
        {
            get
            {
                return m_VehicleVendor;
            }
            set
            {
                m_VehicleVendor = value;
            }
        }

        public string LicensePlate
        {
            get
            {
                return m_LicensePlate;
            }
            set
            {
                m_LicensePlate = value;
            }
        }

        public Energy VehicleEnergySource
        {
            get
            {
                return m_VehicleEnergySource;
            }
            set
            {
                m_VehicleEnergySource = value;
            }
        }

        public List<Wheel> WheelsCollection
        {
            get
            {
                return m_WheelsCollection;
            }
            set
            {
                m_WheelsCollection = value;
            }
        }

        public float GetMaxAirPressure()
        {
            return m_WheelsCollection[0].MaxAirPressure;
        }

        public string GetWheelsVendor()
        {
            return m_WheelsCollection[0].Vendor;
        }

        public override string ToString()
        {
            string output;
            StringBuilder wheelsDetails = new StringBuilder();

            for (int i = 0; i < m_WheelsCollection.Count; i++)
            {
                wheelsDetails.AppendLine($"Wheel #{i + 1}: {m_WheelsCollection[i].ToString()}");
            }

            output = String.Format("License plate: {0}{1}" +
                "Vehicle's vendor: {2}{1}" +
                "{3}{1}" +
                "{4}",
                m_LicensePlate, Environment.NewLine, m_VehicleVendor, 
                m_VehicleEnergySource.ToString(), wheelsDetails.ToString());

            return output;
        }
    }
}
