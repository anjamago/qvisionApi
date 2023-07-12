namespace Domain.Dtos.settings
{
    public class JwtSetting
    {
        public string Issuer { set; get; }
        public string Audience { set; get; }
        public string Key { set; get; }
    }
}
