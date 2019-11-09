namespace bitpctechapi.Options
{
    public class JwtSettings
    {
        public string Secret { get; set; }
        public bool IsAdmin { get; set; }
        public string DevClientURL { get; set; }
        public string ProdClientURL { get; set; }
    }
}
