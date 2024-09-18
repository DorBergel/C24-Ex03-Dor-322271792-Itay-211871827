using Ex03.GarageLogic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex03.ConsoleUI
{
    public class UI
    {
        private Garage m_Garage;

        public UI()
        {
            m_Garage = new Garage();
        }

        // Method to manage the app should be here

        public void InitOptionsMenu()
        {
            string optionMenuMsg =
                String.Format("Welcome to the Garage! Please enter the digit of action you want to select:" + Environment.NewLine
                + "1. Inserting new vehicle to the garage" + Environment.NewLine
                + "2. Showing all the license plates that in the garage (with option to filter by vehicle status in the garage)" + Environment.NewLine
                + "3. Changing the vehicle status in the garage" + Environment.NewLine
                + "4. Inflating the vehicle's wheels to the maximum" + Environment.NewLine
                + "5. Refilling a vehicle powered by fuel" + Environment.NewLine
                + "6. Charging an electric vehicle" + Environment.NewLine
                + "7. Showing complete vehicle data by license plate");
            Console.WriteLine(optionMenuMsg);
        }

        public string ChooseFromListOfOptions(string[] i_OptionsToList)
        {
            string userDigitInput = null;
            int intUserDigitInput;
            bool isValidInput = false;
            StringBuilder messageInList = new StringBuilder();

            for (int i = 0; i < i_OptionsToList.Length; i++)
            {
                messageInList.AppendLine($"{i + 1}. {i_OptionsToList[i]}");
            }

            do
            {
                try
                {
                    Console.WriteLine("Enter the digit (between 1 to {0}) of your desired selection", i_OptionsToList.Length);
                    Console.WriteLine(messageInList.ToString());
                    userDigitInput = Console.ReadLine();
                    isValidInput = checkIfDigitInRange(userDigitInput, i_OptionsToList.Length);
                }
                catch (FormatException formatException)
                {
                    Console.WriteLine(formatException.Message);
                }
                catch (ArgumentException argumentException)
                {
                    Console.WriteLine(argumentException.Message);
                }
                catch (ValueOutOfRangeException valueOutOfRangeException)
                {
                    Console.WriteLine(valueOutOfRangeException.Message);
                }
                
            } while (!isValidInput);

            intUserDigitInput = userDigitInput != null ? int.Parse(userDigitInput) : -1;

            return intUserDigitInput != -1 ? i_OptionsToList[intUserDigitInput - 1] : null;
        }

        private bool checkIfDigitInRange(string i_UserDigitInput, int i_MaxDigit)
        {
            int intUserInput;
            bool isDigitInRange = true;

            if (!int.TryParse(i_UserDigitInput, out intUserInput))
            {
                isDigitInRange = false;
                throw new FormatException("Error: Only digits are allowed!");
            }
            else if (intUserInput > i_MaxDigit || intUserInput < 1)
            {
                isDigitInRange = false;
                throw new ValueOutOfRangeException(1, i_MaxDigit);
            }

            return isDigitInRange;
        }

        public string GetUserInput<T>(string i_InstructionsToInput)
        {
            string userInput = null;
            bool isValidInput = false;

            do
            {
                try
                {
                    Console.WriteLine(i_InstructionsToInput);
                    userInput = Console.ReadLine();
                    isValidInput = checkIsValidInput<T>(userInput);
                }
                catch (FormatException formatException)
                {
                    Console.WriteLine(formatException.Message);
                }
                catch (ArgumentException argumentException)
                {
                    Console.WriteLine(argumentException.Message);
                }
            } while (!isValidInput);

            return userInput;
        }

        private bool checkIsValidInput<T>(string i_UserInput)
        {
            bool isValidInput = true;

            if (typeof(T) == typeof(int))
            {
                if (!int.TryParse(i_UserInput, out _))
                {
                    isValidInput = false;
                    throw new FormatException("Error: Only digits are allowed!");
                }
            }
            else if (typeof(T) == typeof(float))
            {
                if (!float.TryParse(i_UserInput,out _))
                {
                    isValidInput = false;
                    throw new FormatException("Error: Only digits are allowed!");
                }
            }
            else if (typeof(T) == typeof(string))
            {
                if (string.IsNullOrEmpty(i_UserInput))
                {
                    throw new ArgumentException("Error: Input cannot be empty!");
                }
            }

            return isValidInput;
        }

        public void InsertNewVehicleToGarage()
        {
            string vehicleLicensePlate = GetUserInput<string>("Enter your vehicle's license plate:");
            if (m_Garage.IsVehicleExists(vehicleLicensePlate))
            {
                Console.WriteLine("The vehicle is already in the garage.");
                m_Garage.GarageClients[vehicleLicensePlate.GetHashCode()].VehicleStatus = eVehicleStatus.InRepair;
            }
            else
            {
                string stringVehicleType = ChooseFromListOfOptions(Enum.GetNames(typeof(eVehicleType)));
                eVehicleType vehicleType = (eVehicleType)Enum.Parse(typeof(eVehicleType), stringVehicleType);
            }
        }
    }
}
