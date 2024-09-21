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
            m_MaxAirPressure = i_MaxAirPressure;
            if (i_CurrentAirPressure >= 0 && i_CurrentAirPressure <= m_MaxAirPressure)
            {
                m_CurrentAirPressure = i_CurrentAirPressure;
            }
            else
            {
                throw new ValueOutOfRangeException(0, m_MaxAirPressure);
            }
        }

        public void InflateWheel(float i_InflatePressure)
        {
            if (m_CurrentAirPressure + i_InflatePressure <= m_MaxAirPressure)
            {
                m_CurrentAirPressure += i_InflatePressure;
            }
            else
            {
                throw new ValueOutOfRangeException(0, m_MaxAirPressure);
            }
        }

        public float CurrentAirPressure
        {
            get
            {
                return m_CurrentAirPressure;
            }
            set
            {
                if (value >= 0 && value <= m_MaxAirPressure)
                {
                    m_CurrentAirPressure = value;
                }
                else
                {
                    throw new ValueOutOfRangeException(0, m_MaxAirPressure);
                }
            }
        }

        public float MaxAirPressure
        {
            get
            {
                return m_MaxAirPressure;
            }
        }

        public string Vendor
        {
            get
            {
                return m_Vendor;
            }
        }

        public override string ToString()
        {
            return $"Vendor: {m_Vendor}, Air pressure: {m_CurrentAirPressure}/{m_MaxAirPressure}";
        }
    }
}
