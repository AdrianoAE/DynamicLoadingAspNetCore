using System;

namespace Microsoft.Extensions.DependencyInjection
{
    public static class ServiceProviderExtensions
    {
        //https://stackoverflow.com/questions/53884417/net-core-di-ways-of-passing-parameters-to-constructor
        public static T ResolveWith<T>(this IServiceProvider provider, params object[] parameters) where T : class =>
            ActivatorUtilities.CreateInstance<T>(provider, parameters);
    }
}
