using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Constants_NS
{
    public static class Constants
    {
        // General constants
        public const int MaxUsers = 1000;
        public const string ApplicationName = "MyApp";

        // Nested class for database-related constants
        public static class ErrorMessages
        {
            public static string NotImplemeted(string file, string element)
            {
                return $"Error at: {file}.cs -> {element} \nMessage: Something Went Wrong";
            }
        }
    }
}
