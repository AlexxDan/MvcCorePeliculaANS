using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MvcCorePeliculaANS.Helpers
{
    public static class HelperToolki
    {
        public static String SerializeObject(Object objeto)
        {
            if (objeto == null)
                return null;

            String repsuesta = JsonConvert.SerializeObject(objeto);

            return repsuesta;
        }

        
        public static T DeseriablizeType<T>(String json)
        {

            return JsonConvert.DeserializeObject<T>(json);
        }
    }
}
