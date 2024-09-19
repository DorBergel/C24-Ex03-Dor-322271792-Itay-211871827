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

        public Truck(string i_TruckVendor, string i_LicensePlate, int i_NumOfWheels, Wheel i_TruckWheel, Energy i_TruckEnergy, bool i_IsIncludeHazrdousMaterials, float i_LuggageVolume)
            : base(i_TruckVendor, i_LicensePlate, i_NumOfWheels, i_TruckWheel, i_TruckEnergy)
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
