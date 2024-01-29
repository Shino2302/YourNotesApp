using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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

        public static async Task<Dictionary<string, Notas>> ObtenerListaDeNotas()
        {
            Dictionary<string, Notas> oObejeto = new Dictionary<string, Notas>();
            try
            {
                HttpClient cliente = new HttpClient();
                string apiUrlFormat = string.Concat(AppSettings.ApiFirebase, "notas/{0}.json?auth={1}");
                var response = await cliente.GetAsync(string.Format(apiUrlFormat, AppSettings.oAuthentication.IdToken));
                if (response.StatusCode.Equals(HttpStatusCode.OK))
                {
                    var cadenaJson = await response.Content.ReadAsStringAsync();
                    if(cadenaJson != null)
                    {
                        oObejeto = JsonConvert.DeserializeObject<Dictionary<string, Notas>>(cadenaJson);
                    }
                    return oObejeto;
                }
                else
                {
                    return oObejeto;
                }
            }
            catch(Exception ex)
            {
                string t = ex.Message;
                return oObejeto;
            }
        }
        public static async Task<bool> AgregarNota(Notas oNota)
        {
            Usuario oObjeto = new Usuario();
            try
            {
                HttpClient cliente = new HttpClient();
                var body = JsonConvert.SerializeObject(oNota);
                var contenido = new StringContent(body, Encoding.UTF8, "application/{0}.json?auth={1}");

                string apiFormat = string.Concat(AppSettings.ApiFirebase, "notas/{0}.json?auth={1}");
                var response = await cliente.PostAsync(string.Format(apiFormat, AppSettings.oAuthentication.LocalId, AppSettings.oAuthentication.IdToken), contenido);
                if (response.StatusCode.Equals(HttpStatusCode.OK))
                    return true;
                else
                    return false;
            }
            catch(Exception ex)
            {
                string t = ex.Message;
                return false;
            }
        }
        public static async Task<bool> EliminarNota(string IdNota)
        {
            Usuario oObjeto = new Usuario();
            try
            {
                HttpClient cliente = new HttpClient();
                string apiFormat = string.Concat(AppSettings.ApiFirebase, "notas/{0}/{1}.json?auth={2}");
                var response = await cliente.DeleteAsync(string.Format(apiFormat, AppSettings.oAuthentication.LocalId, IdNota, AppSettings.oAuthentication.IdToken));
                if (response.StatusCode.Equals(HttpStatusCode.OK))
                    return true;
                else
                    return false;
            }
            catch(Exception ex)
            {
                string t = ex.Message;
                return false;
            }
        }

    }
}
