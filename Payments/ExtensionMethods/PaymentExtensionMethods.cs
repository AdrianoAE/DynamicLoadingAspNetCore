using Payments.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace Payments.Extensions
{
    public static class PaymentExtensionMethods
    {
        public static Dictionary<string, IPaymentMethod> GetPaymentMethods<T>(this T assembly) where T : IProvider
        {
            return assembly.GetType().Assembly.GetTypes()
                                              .Where(t => typeof(IPaymentMethod).IsAssignableFrom(t) && !t.IsInterface && !t.IsAbstract)
                                              .ToDictionary(t => t.Name, t => (IPaymentMethod)Activator.CreateInstance(t));
        }

        //═════════════════════════════════════════════════════════════════════════════════════════

        public static Dictionary<string, object> ToDictionary<T>(this T obj) where T : class
        {
            return obj.GetType()
                      .GetProperties(BindingFlags.Instance | BindingFlags.Public)
                      .ToDictionary(prop => prop.Name, prop => prop.GetValue(obj));
        }
    }
}
