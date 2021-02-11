using Microsoft.AspNetCore.Http;
using MvcCorePeliculaANS.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MvcCorePeliculaANS.Extension
{
    public static class SessionExtension
    {
        public static void SetObject(this ISession session, String key, Object value)
        {
            String data = HelperToolki.SerializeObject(value);

            session.SetString(key, data);
        }

        public static T GetObject<T>(this ISession session, String key)
        {

            String data = session.GetString(key);
            if (data == null)
            {
                return default(T);
            }
            return HelperToolki.DeseriablizeType<T>(data);
        }
    }
}
