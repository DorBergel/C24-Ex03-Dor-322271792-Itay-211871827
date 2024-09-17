using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex03.GarageLogic
{
    public class Truck : Vehicle
    {
        private bool m_IsIncludeHazardousMaterials;
        private float m_LuggageVolume;

        public Truck(string i_TruckVendor, string i_LicensePlate, string i_WheelsVendor, float i_MaxAirPressure, float i_CurrentAirPressure, eEngineType i_EngineType, float i_CurrentEnergy, float i_MaxEnergy, bool i_IsIncludeHazrdousMaterials, float i_LuggageVolume, eFuelType? i_FuelType)
            : base(i_TruckVendor, i_LicensePlate, i_WheelsVendor, 14, i_MaxAirPressure, i_CurrentAirPressure, i_EngineType, i_CurrentEnergy, i_MaxEnergy, eFuelType.Soler)
        {
            m_IsIncludeHazardousMaterials = i_IsIncludeHazrdousMaterials;
            m_LuggageVolume = i_LuggageVolume;
        }

        public bool IsIncludeHazardousMaterials
        {
            get
            {
                return m_IsIncludeHazardousMaterials;
            }
        }

        public float LuggageVolume
        {
            get
            {
                return m_LuggageVolume;
            }
        }
    }
}
