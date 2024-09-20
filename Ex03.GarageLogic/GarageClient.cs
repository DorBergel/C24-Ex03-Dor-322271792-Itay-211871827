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
            StringBuilder wheelsDetails = new StringBuilder();

            for (int i = 0; i < m_ClientVehicle.WheelsCollection.Count; i++) 
            {
                wheelsDetails.AppendLine($"Wheel #{i + 1}: {m_ClientVehicle.WheelsCollection[i].ToString()}");
            }

            clientVehicleDetails = String.Format("License plate: {0}{1}" +
                "Model: {2}{1}" +
                "Owner name: {3}{1}" +
                "Owner phone number: {4}{1}" +
                "Status in garage: {5}{1}" +
                "Wheels details (vendor, air pressure): {1}" +
                "{6}" +
                "Energy source: {7}{1}" +
                "Energy status (current energy / max energy): {8}/{9}{1}",
                m_ClientVehicle.LicensePlate, Environment.NewLine, m_ClientVehicle.VehicleVendor,
                m_ClientName, m_ClientPhoneNumber, m_ClientVehicleStatus, wheelsDetails, _, m_ClientVehicle.VehicleEnergySource.CurrentEnergy, m_ClientVehicle.VehicleEnergySource.MaxEnergy);
            // Need to add: energy type, fuel type, extra properties for each vehicle type...

            return clientVehicleDetails;
        }
    }
}
