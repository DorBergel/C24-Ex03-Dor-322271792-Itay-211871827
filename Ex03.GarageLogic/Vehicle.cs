using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex03.GarageLogic
{
    public class Vehicle
    {
        // In doc wrote "percentage of current energy - maybe to add float variable that describe it
        string m_VehicleVendor;
        string m_LicensePlate;
        Energy m_VehicleEnergySource;
        List<Wheel> m_WheelsCollection;

        /*public Vehicle(string i_VehicleVendor, string i_LicensePlate, Energy i_VehicleEnergySource, List<Wheel> i_WheelsCollection)
        {
            m_VehicleVendor = i_VehicleVendor;
            m_LicensePlate = i_LicensePlate;
            m_VehicleEnergySource = i_VehicleEnergySource;
            m_WheelsCollection = i_WheelsCollection;
        }*/

        public Vehicle(string i_VehicleVendor, string i_LicensePlate, string i_WheelsVendor, int i_NumOfWheels, float i_MaxAirPressure, float i_CurrentAirPressure, eEngineType i_EngineType, float i_CurrentEnergy, float i_MaxEnergy, eFuelType? i_FuelType = null)
        {
            m_VehicleVendor = i_VehicleVendor;
            m_LicensePlate = i_LicensePlate;
            
            m_WheelsCollection = new List<Wheel>();
            for (int i = 1; i <= i_NumOfWheels; i++)
            {
                m_WheelsCollection.Add(new Wheel(i_WheelsVendor, i_CurrentAirPressure, i_MaxAirPressure));
            }

            if (i_EngineType == eEngineType.Fuel)
            {
                m_VehicleEnergySource = new Fuel(i_CurrentEnergy, i_MaxEnergy, i_FuelType);
            }
            else
            {
                m_VehicleEnergySource = new Electric(i_CurrentEnergy, i_MaxEnergy);
            }
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
