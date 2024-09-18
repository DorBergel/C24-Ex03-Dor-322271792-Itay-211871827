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

        // Methods for each action in the garage
        
        // Page 2 in doc, section 1
        public bool IsVehicleExists(string i_LicensePlateNumber)
        {
            return m_GarageClients != null && m_GarageClients.ContainsKey(i_LicensePlateNumber.GetHashCode());
        }
        
        public void AddNewClient(string i_ClientName, string i_ClientPhoneNumber, Vehicle i_ClientVehilce)
        {
            GarageClient newGarageClient = new GarageClient(i_ClientName, i_ClientPhoneNumber, i_ClientVehilce);
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
            m_GarageClients[i_LicensePlate.GetHashCode()].ClientVehicle.VehicleEnergySource.Refill(i_RequiredFuelToRefill, i_RequiredFuelType);
        }

        public void RefillElectricVehicle(string i_LicensePlate, float i_RequiredMinutesToRefill)
        {
            float requiredHoursToRefill = i_RequiredMinutesToRefill / 60;
            m_GarageClients[i_LicensePlate.GetHashCode()].ClientVehicle.VehicleEnergySource.Refill(requiredHoursToRefill);
        }

        public void PrintCarDetailesByLicensePlate(string i_LicensePlate)
        {
           
            for(int i = 0; i < m_GarageClients.Count; i++)
            {
                if (GarageClients[i].ClientVehicle.LicensePlate == i_LicensePlate)
                {
                    Console.WriteLine("License Plate: {0}", i_LicensePlate);
                    Console.WriteLine("Model: {0}", GarageClients[i].ClientVehicle.VehicleVendor);
                    Console.WriteLine("Owner: {0}", GarageClients[i].ClientName);
                    Console.WriteLine("Status in Garage: {0}", GarageClients[i].VehicleStatus);
                    Console.WriteLine("Wheels: ");
                    foreach (Wheel w in GarageClients[i].ClientVehicle.WheelsCollection)
                    {
                        Console.WriteLine("\t{0}", w.ToString());
                    }
                    
                    if(GarageClients[i].ClientVehicle.VehicleEnergySource is Fuel)
                    {
                        Console.WriteLine("Fuel - {0}: {1}/{2}",
                            (GarageClients[i].ClientVehicle.VehicleEnergySource as Fuel).FuelType.Value.ToString(),
                            GarageClients[i].ClientVehicle.VehicleEnergySource.CurrentEnergy,
                            GarageClients[i].ClientVehicle.VehicleEnergySource.MaxEnergy);
                        
                    }
                    else
                    {
                        Console.WriteLine("Electric: {0}/{1}",
                            GarageClients[i].ClientVehicle.VehicleEnergySource.CurrentEnergy,
                            GarageClients[i].ClientVehicle.VehicleEnergySource.MaxEnergy);
                    }
                    break;
                }
            }
        }
    }
}
