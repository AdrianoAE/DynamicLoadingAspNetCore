namespace Payments.Entities
{
    public class ProviderConfiguration
    {
        public int ProviderId { get; set; }
        public string PropertyName { get; set; }
        public string Value { get; set; }

        //■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■

        public ProviderConfiguration(string propertyName)
        {
            PropertyName = propertyName;
        }
    }
}
