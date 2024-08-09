using Newtonsoft.Json;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace P6TravelsAPP_KevinR.Models
{
    public class User
    {
        //aca no hace falta nombrar el objeto como DTO, solo es necesario en el
        //API. De hecho el equipo de desarrolo no deberia saber la forma del
        //modelo nativo en el API.

        [JsonIgnore]
        public RestRequest Request { get; set; }

        public int UsuarioID { get; set; }

        public string Correo { get; set; } = null!;

        public string Nombre { get; set; } = null!;

        public string? Telefono { get; set; }

        public string Contrasennia { get; set; } = null!;

        public int RolID { get; set; }

        public string? RolDescripcion { get; set; }

        //funcion que permite agregar un usuario
        public async Task<bool> AddUserAsync()
        {
            try
            {
                //este es el sufijo que completa la ruta de consumo del API
                string RouteSufix = string.Format("Users/AddUserFromApp");

                string URL = Services.WebApiConnection.BaseURL + RouteSufix;

                RestClient client = new RestClient(URL);

                Request = new RestRequest(URL, Method.Post);

                //agregamos la info de seguridad api key 
                Request.AddHeader(Services.WebApiConnection.ApiKeyName, Services.WebApiConnection.ApiKeyValue);

                //Cuando enviamos objetos hacia el API debemos serializarlos antes

                string SerializedModel = JsonConvert.SerializeObject(this);

                Request. AddBody(SerializedModel);
                
                //se ejecuta la llamada
                RestResponse response = await client.ExecuteAsync(Request);

                //validamos el resultado del llamado del API
                HttpStatusCode statusCode = response.StatusCode;

                if (response != null && statusCode == HttpStatusCode.Created)
                {
                    //usamos newtonsoft para descomponer el jason de respuesta del api y convertirlo
                    //en un objeto de tipo UserRol que se pueda entender en la progra


                    return true;

                }
                else
                {
                    return false;
                }

            }
            catch (Exception ex)
            {
                string message = ex.Message;
                throw;
            }
        }


    }
}
