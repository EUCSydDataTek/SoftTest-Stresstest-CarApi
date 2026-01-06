namespace CarApi.Services.LoadEmulation
{
    public class LoadEmulationOptions
    {
        public bool Enable = true;
        public uint MaxRequests = 2000;
        public uint RequestRefillAmount = 50;
        public uint RequestRefillRateMs = 10000;

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
