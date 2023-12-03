namespace AppointmentMaker.Views.Services
{
    public class BusinessService
    {
        static decimal netWorthThreshold = 90000;
        static int painLevelThreshold = 5;

        public BusinessService() { }

        public bool PatientHasHighEnoughNetWorth(decimal value)
        {
            if (value > netWorthThreshold)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public bool PatientPainLevelMeetsRequirement(int level)
        {
            if (level > painLevelThreshold)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

    }
}
