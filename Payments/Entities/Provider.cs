namespace Payments.Entities
{
    public class Provider
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public bool IsActive { get; set; }

        //═════════════════════════════════════════════════════════════════════════════════════════

        public FluentList<ProviderConfiguration> Configuration { get; }


        //■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■

        #region --- Constructors
        //Required by Entity Framework
        protected Provider()
        {

        }

        //─────────────────────────────────────────────────────────────────────────────────────────

        public Provider(string name, FluentList<ProviderConfiguration> configuration)
        {
            Name = name;
            IsActive = false;
            Configuration = configuration;
        }
        #endregion
    }
}
