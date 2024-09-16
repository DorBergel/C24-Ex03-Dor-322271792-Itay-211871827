using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex03.GarageLogic
{
    public class Wheel
    {
        string m_Vendor;
        float m_CurrentAirPressure;
        float m_MaxAirPressure;

        public Wheel(string i_Vendor, float i_CurrentAirPressure, float i_MaxAirPressure)
        {
            m_Vendor = i_Vendor;
            m_CurrentAirPressure = i_CurrentAirPressure;
            m_MaxAirPressure = i_MaxAirPressure;
        }

        public void InflateWheel(float i_InflatePressure)
        {
            if(m_CurrentAirPressure + i_InflatePressure <= m_MaxAirPressure)
            {
                m_CurrentAirPressure += i_InflatePressure;
            }
            else
            {
                // TODO Value out of range exception
            }
        }
    }
}
