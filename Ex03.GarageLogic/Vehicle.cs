using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex03.GarageLogic
{
    public abstract class Vehicle
    {
        // In doc wrote "percentage of current energy - maybe to add float variable that describe it
        string m_VehicleVendor;
        string m_LicensePlate;
        Energy m_VehicleEnergySource;
        List<Wheel> m_WheelsCollection;

        public Vehicle(string i_VehicleVendor, string i_LicensePlate, int i_NumOfWheels, Wheel i_VehicleWheel, Energy i_VehicleEnergy)
        {
            m_VehicleVendor = i_VehicleVendor;
            m_LicensePlate = i_LicensePlate;
            
            m_WheelsCollection = new List<Wheel>();
            for (int i = 1; i <= i_NumOfWheels; i++)
            {
                m_WheelsCollection.Add(i_VehicleWheel);
            }

            m_VehicleEnergySource = i_VehicleEnergy;
        }

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
            return m_WheelsCollection[0].
        }
    }
}
