namespace CarApi.Services.LoadEmulation
{
    public class LoadEmulationOptions
    {
        public bool Enable = false;
        public uint MaxRequests = 100;
        public uint RequestRefillAmount = 10;
        public uint RequestRefillRateMs = 5000;

        public int CalculateCurrentSteps(uint CurrentRemaining)
        {
            var Step = CalculateOneStep();

            if (Step == 0)
                return 50;

            return Convert.ToInt32(CurrentRemaining / Step);
        }

        public int CalculateOneStep()
        {
            return Convert.ToInt32(MaxRequests / 100);
        }

    }
}
