using Microsoft.AspNetCore.Http;
using System.Text.Json;

namespace EcoVaccine.Domain.Shared.Utils
{
    public static class SessionExtensions
    {
        #region Methods

        public static T Get<T>(this ISession session, string key)
        {
             session.TryGetValue(key, out var value);

            return value == null ? default(T) :
                JsonSerializer.Deserialize<T>(value);
        }

        public static void Set<T>(this ISession session, string key, T value)
        {
            session.Set(key, JsonSerializer.SerializeToUtf8Bytes(value));
        }

        #endregion Methods
    }
}