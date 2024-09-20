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

        public Motorcycle(string i_MotorcycleVendor, string i_LicensePlate, int i_NumOfWheels, Wheel i_MotorcycleWheel, Energy i_MotorcycleEnergy, eLicenseType i_LicenseType, int i_EngineVolume)
            : base(i_MotorcycleVendor, i_LicensePlate, i_NumOfWheels, i_MotorcycleWheel, i_MotorcycleEnergy)
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

        public override string ToString()
        {
            string output = String.Format("{0}{1}" +
                "License type: {2}{1}" +
                "Engine volume: {3}{1}",
                base.ToString(), Environment.NewLine, m_LicenseType, m_EngineVolume);

            return output;
        }
    }
}
