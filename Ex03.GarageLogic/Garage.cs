﻿using System;
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
    }
}
