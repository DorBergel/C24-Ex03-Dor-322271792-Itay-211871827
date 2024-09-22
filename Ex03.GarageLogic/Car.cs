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
        
        public Car(string i_CarVendor, string i_LicensePlate, int i_NumOfWheels, Wheel i_CarWheel, Energy i_CarEnergy, eCarColor i_CarColor, eNumOfCarDoors i_NumOfDoors)
            : base(i_CarVendor, i_LicensePlate, i_NumOfWheels, i_CarWheel, i_CarEnergy)
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

        public override string ToString()
        {
            string output = String.Format("{0}" +
                "Car color: {2}{1}" +
                "Number of doors: {3}{1}",
                base.ToString(), Environment.NewLine, m_CarColor, m_NumOfCarDoors);

            return output;
        }
    }
}
