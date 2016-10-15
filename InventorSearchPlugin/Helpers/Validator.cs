using System;
using System.Windows.Forms;

namespace InventorSearchPlugin.Helpers
{
    public static class Validator
    {
        public static bool Validate(string host, string port, string user, string password, string dbName)
        {
            string errorMessage = "field is inccorect or empty, please check settings";
            return CheckIfEmptyOrNulValue(host, ErrorString("Host", errorMessage))
                   && CheckIfEmptyOrNulValue(port, ErrorString("Port", errorMessage))
                   && CheckIfEmptyOrNulValue(user, ErrorString("User", errorMessage))
                   && CheckIfEmptyOrNulValue(password, ErrorString("Password", errorMessage))
                   && CheckIfEmptyOrNulValue(dbName, ErrorString("Database name", errorMessage));
        }

        public static bool ValidateSearchFields(string width, string height, string length, string deviation)
        {
            string errorMessage = "field is inccorect or empty";
            return CheckIfEmptyOrNulValue(width, ErrorString("Width", errorMessage))
                   && CheckIfEmptyOrNulValue(height, ErrorString("Height", errorMessage))
                   && CheckIfEmptyOrNulValue(length, ErrorString("Length", errorMessage))
                   && CheckIfEmptyOrNulValue(deviation, ErrorString("Deviation", errorMessage));
        }

        private static string ErrorString(string errorFor, string errorMessage)
        {
            string errorString = String.Format("{0} {1}", errorFor, errorMessage);
            return errorString;
        }

        private static bool CheckIfEmptyOrNulValue(string checkField, string errorMesage)
        {
            if (String.IsNullOrEmpty(checkField))
            {
                MessageBox.Show(errorMesage);
            }
            else
            {
                return true;
            }
            return false;
        }
    }
}