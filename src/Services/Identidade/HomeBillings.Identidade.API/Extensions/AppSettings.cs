namespace HomeBillings.Identidade.API.Extensions
{
    public class AppSettings
    {
        public string Secret { get; set; }
        public int ExpiresIn { get; set; }
        public string Emissor { get; set; }
        public string ValideIn { get; set; }
    }
}
