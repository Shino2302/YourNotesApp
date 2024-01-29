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
    public class ApiServiceAuthentication
    {
        public static async Task<bool> Login(UserAuthentication usuario)
        {
            try
            {
                HttpClient cliente = new HttpClient();
                var body = JsonConvert.SerializeObject(usuario);
                var contenido = new StringContent(body, Encoding.UTF8, "applicacion/json");
                var response = await cliente.PostAsync(AppSettings.ApiAuthentication("LOGIN"), contenido);
                if (response.StatusCode.Equals(HttpStatusCode.OK))
                {
                    var jsonResultante = await response.Content.ReadAsStringAsync();
                    ResponseAuthentication oResponse = JsonConvert.DeserializeObject<ResponseAuthentication>(jsonResultante);
                    AppSettings.oAuthentication = oResponse;
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch(Exception ex) 
            {
                string t = ex.Message;
                return false;
            }
        }
        public static async Task<bool> RegistrarUsuario(Usuario oUsuario)
        {
            bool respuesta = true;
            try
            {
                UserAuthentication oUser = new UserAuthentication()
                {
                    Email = oUsuario.Email,
                    Password = oUsuario.Password,
                    ReturnSecureToken = true
                };

                HttpClient cliente = new HttpClient();
                var body = JsonConvert.SerializeObject(oUser);
                var contenido = new StringContent(body, Encoding.UTF8, "application/json");
                var response = await cliente.PostAsync(AppSettings.ApiAuthentication("SIGNIN"), contenido);
                if (response.StatusCode.Equals(HttpStatusCode.OK))
                {
                    var jsonResultante = await response.Content.ReadAsStringAsync();
                    ResponseAuthentication oResponse = JsonConvert.DeserializeObject<ResponseAuthentication>(jsonResultante);
                    if(oResponse != null)
                    {
                        respuesta = await ApiServicesFirebase.RegistrarUsuario(oUsuario, oResponse);
                    }
                    else
                    {
                        respuesta = false;
                    }
                }
            }
            catch(Exception ex)
            {
                string t = ex.Message;
                respuesta = false;
            }
            return respuesta;
        }
    }
}
