namespace CSharpBasic.Models
{
    public class WhereAmIResponse
    {
        public string MyIP { get; set; }
        public string CountryCode { get; set; }

        public WhereAmIResponse(string myIp, string countryCode)
        {
            MyIP = myIp;
            CountryCode = countryCode;
        }
    }
}