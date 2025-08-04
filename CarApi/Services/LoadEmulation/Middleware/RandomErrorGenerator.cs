namespace CarApi.Services.LoadEmulation.Middleware
{
    public class RandomErrorGenerator
    {

        private Random _Random;

        public RandomErrorGenerator(int seed) 
        {    
            _Random = new Random(seed);
        }

        public int GenerateRandomErrorCode()
        {
            int index = _Random.Next(0,_ErrorCodes.Count);
            return _ErrorCodes[index];
        }

        private List<int> _ErrorCodes = new List<int>()
        {
            203, //Non-Authoritative Information
            400, //Bad request
            401, //Unauthorized
            403, //Forbidden
            404, //Not found
            405, //Method not allowed
            406, //Not acceptable
            408, //Request Timeout
            410, //Gone
            413, //Content too large
            414, //Uri too long
            415, //Unsupported media type
            416, //Range Not Satisfiable
            417, //Expectation Failed
            418, //I am a teapot
            421, //Misdirected Request
            425, //Too early
            429, //Too many requests
            431, //Request Header Fields Too Large
            451, //Unavailable For Legal Reasons
            500, //Internal Server Error
            501, //Not Implemented
            502, //Bad gateway
            503, //Service Unavailable
            504, //Gateway Timeout
            505, //HTTP Version Not Supported
            510, //Not Extended
            511, //Network Authentication Required
        }; 

    }
}
