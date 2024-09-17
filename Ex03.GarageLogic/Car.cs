using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex03.GarageLogic
{
    public class Car : Vehicle
    {
        private eCarColor m_CarColor;
        private eNumOfCarDoors m_NumOfCarDoors;
        
        public Car(string i_CarVendor, string i_LicensePlate, string i_WheelsVendor, float i_MaxAirPressure, float i_CurrentAirPressure, eEngineType i_EngineType, float i_CurrentEnergy, float i_MaxEnergy, eCarColor i_CarColor, eNumOfCarDoors i_NumOfDoors, eFuelType? i_FuelType = null)
            : base(i_CarVendor, i_LicensePlate, i_WheelsVendor, 5, i_MaxAirPressure, i_CurrentAirPressure, i_EngineType, i_CurrentEnergy, i_MaxEnergy, i_FuelType)
        {
            m_CarColor = i_CarColor;
            m_NumOfCarDoors = i_NumOfDoors;
        }

        public eCarColor CarColor
        {
            get
            {
                return m_CarColor;
            }
        }

        public eNumOfCarDoors NumOfCarDoors
        {
            get
            {
                return m_NumOfCarDoors;
            }
        }
    }
}
