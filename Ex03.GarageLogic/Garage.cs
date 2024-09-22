using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex03.GarageLogic
{
    public class Garage
    {
        private Dictionary<int, GarageClient> m_GarageClients;

        public Garage()
        {
            m_GarageClients = new Dictionary<int, GarageClient>();
        }

        public Dictionary<int, GarageClient> GarageClients
        {
            get
            {
                return m_GarageClients;
            }
        }

        public bool IsVehicleExists(string i_LicensePlateNumber)
        {
            return m_GarageClients != null && m_GarageClients.ContainsKey(i_LicensePlateNumber.GetHashCode());
        }

        public void AddNewClient(string i_ClientName, string i_ClientPhoneNumber, Vehicle i_ClientVehicle)
        {
            GarageClient newGarageClient = new GarageClient(i_ClientName, i_ClientPhoneNumber, i_ClientVehicle);
            m_GarageClients.Add(newGarageClient.GetHashCode(), newGarageClient);
        }

        public List<string> GetLicensePlatesList(eVehicleStatus? i_VehicleStatus = null)
        {
            List<string> licensePlatesList;
            licensePlatesList = m_GarageClients.Count > 0 ? new List<string>() : null;

            if (i_VehicleStatus == null)
            {
                foreach(var item in m_GarageClients)
                {
                    licensePlatesList.Add(item.Value.ClientVehicle.LicensePlate);
                }
            }
            else
            {
                switch (i_VehicleStatus)
                {
                    case eVehicleStatus.InRepair:
                        foreach(var item in m_GarageClients)
                        {
                            if(item.Value.VehicleStatus == eVehicleStatus.InRepair)
                            {
                                licensePlatesList.Add(item.Value.ClientVehicle.LicensePlate);
                            }
                        }
                        break;

                    case eVehicleStatus.Repaired:
                        foreach (var item in m_GarageClients)
                        {
                            if (item.Value.VehicleStatus == eVehicleStatus.Repaired)
                            {
                                licensePlatesList.Add(item.Value.ClientVehicle.LicensePlate);
                            }
                        }
                        break;

                    case eVehicleStatus.Paid:
                        foreach (var item in m_GarageClients)
                        {
                            if (item.Value.VehicleStatus == eVehicleStatus.Paid)
                            {
                                licensePlatesList.Add(item.Value.ClientVehicle.LicensePlate);
                            }
                        }
                        break;
                }
            }

            return licensePlatesList;
        }

        public void ChangeVehicleStatus(string i_LicensePlate, eVehicleStatus i_NewVehicleStatus)
        {
            m_GarageClients[i_LicensePlate.GetHashCode()].VehicleStatus = i_NewVehicleStatus;
        }

        public void InflateWheelsToMaximum(string i_LicensePlate)
        {
            foreach(Wheel vehicleWheel in m_GarageClients[i_LicensePlate.GetHashCode()].ClientVehicle.WheelsCollection)
            {
                vehicleWheel.InflateWheel(vehicleWheel.MaxAirPressure - vehicleWheel.CurrentAirPressure);
            }
        }

        public void RefillRegularVehicle(string i_LicensePlate, eFuelType i_RequiredFuelType, float i_RequiredFuelToRefill)
        {
            if ((m_GarageClients[i_LicensePlate.GetHashCode()].ClientVehicle.VehicleEnergySource as Fuel).FuelType == i_RequiredFuelType)
            {
                m_GarageClients[i_LicensePlate.GetHashCode()].ClientVehicle.VehicleEnergySource.Refill(i_RequiredFuelToRefill, i_RequiredFuelType);
            }
            else
            {
                throw new ArgumentException("The fuel type that you chose does not match to the vehicle's fuel type.");
            }
        }

        public void RefillElectricVehicle(string i_LicensePlate, int i_RequiredMinutesToRefill)
        {
            float requiredHoursToRefill = (float)i_RequiredMinutesToRefill / 60;
            m_GarageClients[i_LicensePlate.GetHashCode()].ClientVehicle.VehicleEnergySource.Refill(requiredHoursToRefill);
        }

        public bool IsEngineTypeMatchToRequiredType(string i_LicensePlate, eEngineType i_RequiredVehicleType)
        {
            bool isMatch = false;
            
            if (m_GarageClients[i_LicensePlate.GetHashCode()].ClientVehicle.VehicleEnergySource is Fuel)
            {
                if (i_RequiredVehicleType == eEngineType.Fuel)
                {
                    isMatch = true;
                }
                else
                {
                    throw new ArgumentException("Error: your vehicle's engine based on fuel, but the action not relevant to that kind of vehicles.");
                }
            }
            else
            {
                if (i_RequiredVehicleType == eEngineType.Electric)
                {
                    isMatch = true;
                }
                else
                {
                    throw new ArgumentException("Error: your vehicle's engine based on electricity, but the action not relevant to that kind of vehicles.");
                }
            }

            return isMatch;
        }
    }
}
