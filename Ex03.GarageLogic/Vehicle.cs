using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex03.GarageLogic
{
    public class Vehicle
    {
        string m_VehicleVendor;
        string m_LicensePlate;
        Energy m_VehicleEnergySource;
        List<Wheel> m_WheelsCollection;

        public Vehicle(string i_VehicleVendor, string i_LicensePlate, Energy i_VehicleEnergySource, List<Wheel> i_WheelsCollection)
        {
            m_VehicleVendor = i_VehicleVendor;
            m_LicensePlate = i_LicensePlate;
            m_VehicleEnergySource = i_VehicleEnergySource;
            m_WheelsCollection = i_WheelsCollection;
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

    }
}
