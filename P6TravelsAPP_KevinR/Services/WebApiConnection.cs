using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace P6TravelsAPP_KevinR.Services
{
    public static class WebApiConnection
    {
        //Esta clase auto instanciada permite configurar la ruta de consumo base
        //del servicio web API. Normalmente es un nombre DNS como www.misitio.com/api/
        //o la direccion IP del servidor como por ejemplo 85.25.45.10/api o local
        //como 192.168.0.195/api

        public static string BaseURL = "http://192.168.0.195:45455/api/";

        //aca tambien es importante incluir la info de seguridad como el API key
        //ya que debe ser incluido en cada llamada a los end point del API
        

        public static string ApiKeyName = "Apikey";
        public static string ApiKeyValue = "KevnRP620242abx123";



    }
}
