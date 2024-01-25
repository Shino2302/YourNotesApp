using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using YourNotesApp.Model;

namespace YourNotesApp.Servicios
{
    public class ApiServicesFirebase
    {
        public static async Task<bool> RegistrarUsuario(Usuario nuevoUsuario, ResponseAuthentication responsed)
        {
            try
            {
                HttpClient cliente = new HttpClient();
                var body = JsonConvert.SerializeObject(nuevoUsuario);
                var contenido = new StringContent(body, Encoding.UTF8, "application/json");
                var formatoApi = string.Concat(AppSettings.ApiFirebase, "{0}/{1}.json?auth={2}");

                var response = await cliente.PutAsync(
                    string.Format(formatoApi, "usuarios", responsed.LocalId, responsed.LocalId),
                    contenido);
                if (response.StatusCode.Equals(HttpStatusCode.OK))
                    return true;
                else
                    return false;
            }
            catch (Exception ex)
            {
                string t = ex.Message;
                return false;
            }
        }

        public static async Task<Usuario> ObtenerUsuario()
        {
            Usuario usuarioObtenido = new Usuario();
            try
            {
                HttpClient client = new HttpClient();
                string apiFormat = string.Concat(AppSettings.ApiFirebase, "usuarios/{0}.json?auth={1}");
                var response = await client.GetAsync(string.Format(apiFormat, AppSettings.oAuthentication.LocalId, AppSettings.oAuthentication.IdToken));
                if (response.StatusCode.Equals(HttpStatusCode.OK))
                {
                    var jsonString = await response.Content.ReadAsStringAsync();
                    if (jsonString != "null")
                        usuarioObtenido = JsonConvert.DeserializeObject<Usuario>(jsonString);
                    return usuarioObtenido;
                }
                else
                    return usuarioObtenido;
            }
            catch(Exception ex) 
            {
                string t = ex.Message;
                return usuarioObtenido;
            }
        }

    }
}
