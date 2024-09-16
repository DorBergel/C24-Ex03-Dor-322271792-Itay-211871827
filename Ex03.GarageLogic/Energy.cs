using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex03.GarageLogic
{
    public abstract class Energy
    {
        float m_CurrentEnergy;
        readonly float m_MaxEnergy;
        
        public Energy(float i_CurrentEnergy,  float i_MaxEnergy)
        {
            m_CurrentEnergy = i_CurrentEnergy;
            m_MaxEnergy = i_MaxEnergy;
        }

        public abstract void Refill(float i_RefillEnergy);

        public float CurrentEnergy
        {
            get
            {
                return m_CurrentEnergy;
            }
            set
            {
                m_CurrentEnergy = value;
            }
        }

        public float MaxEnergy
        {
            get
            {
                return m_MaxEnergy;
            }
        }

    }
}
