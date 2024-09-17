using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex03.GarageLogic
{
    public class Motorcycle : Vehicle
    {
        private eLicenseType m_LicenseType;
        private int m_EngineVolume;

        public Motorcycle(string i_MotorcycleVendor, string i_LicensePlate, string i_WheelsVendor, float i_MaxAirPressure, float i_CurrentAirPressure, eEngineType i_EngineType, float i_CurrentEnergy, float i_MaxEnergy, eLicenseType i_LicenseType, int i_EngineVolume, eFuelType? i_FuelType = null)
            : base(i_MotorcycleVendor, i_LicensePlate, i_WheelsVendor, 2, i_MaxAirPressure, i_CurrentAirPressure, i_EngineType, i_CurrentEnergy, i_MaxEnergy, i_FuelType)
        {
            m_LicenseType = i_LicenseType;
            m_EngineVolume = i_EngineVolume;
        }

        public eLicenseType LicenseType
        {
            get
            {
                return m_LicenseType;
            }
        }

        public int EngineVolume
        {
            get
            {
                return m_EngineVolume;
            }
        }
    }
}
