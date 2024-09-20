using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex03.GarageLogic
{
    public class GarageClient
    {
        // Check how to write readonly data members
        private readonly string m_ClientName;
        private readonly string m_ClientPhoneNumber;
        private Vehicle m_ClientVehicle;
        private eVehicleStatus m_ClientVehicleStatus;

        public GarageClient(string i_ClientName, string i_ClientPhoneNumber, Vehicle i_ClientVehicle)
        {
            m_ClientName = i_ClientName;
            m_ClientPhoneNumber = i_ClientPhoneNumber;
            m_ClientVehicle = i_ClientVehicle;
            // Verify with Dor !!
            m_ClientVehicleStatus = eVehicleStatus.InRepair;
        }

        public string ClientName
        {
            get
            {
                return m_ClientName;
            }
        }

        public string ClientPhoneNumber
        {
            get
            {
                return m_ClientPhoneNumber;
            }
        }

        public Vehicle ClientVehicle
        {
            get
            {
                return m_ClientVehicle;
            }
        }

        public eVehicleStatus VehicleStatus
        {
            get
            {
                return m_ClientVehicleStatus;
            }
            set
            {
                m_ClientVehicleStatus = value;
            }
        }

        public override int GetHashCode()
        {
            return m_ClientVehicle.LicensePlate.GetHashCode();
        }

        public override string ToString()
        {
            string clientVehicleDetails;

            clientVehicleDetails = String.Format("Onwer name: {0}{1}" +
                "Owner phone number: {2}{1}" +
                "Vehicle's status in garage: {3}{1}" +
                "{4}",
                m_ClientName, Environment.NewLine, m_ClientPhoneNumber, 
                m_ClientVehicleStatus, m_ClientVehicle.ToString());

            return clientVehicleDetails;
        }
    }
}
