 using System.Globalization;

namespace First_MVC_App.Models
{
    public class DoctorModel
    {
        public static string CheckTemp(string temp)
        {
            float temperature = float.Parse(temp);

            if (temperature >= 38)
                return "You have a fever";
            else if (temperature <= 35)
                return "You have hypothermia";
            else
                return "You are healthy";
        }
    }
}
