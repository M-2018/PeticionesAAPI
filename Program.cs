using System.Net.Http;
using Newtonsoft.Json.Linq;
using System.Text;

namespace PeticionesAAPI
{
    internal class Program
    {
        static void Main(string[] args)
        {
            using (var client = new HttpClient())
            {
                //GET
                string url = "https://jsonplaceholder.typicode.com/posts/1";
                client.DefaultRequestHeaders.Clear();
                var response = client.GetAsync(url).Result;
                var res = response.Content.ReadAsStringAsync().Result;
                dynamic r = JObject.Parse(res);

                Console.WriteLine(r);

                //POST
                string urlPo = "https://jsonplaceholder.typicode.com/posts";
                client.DefaultRequestHeaders.Clear();
                string parametros = "{'title': 'Titulo prueba', 'body': 'Body prueba', 'userId': '23'}";
                dynamic jsonString = JObject.Parse(parametros);

                var httpContent = new StringContent(jsonString.ToString(), Encoding.UTF8, "application/json");
                var responsePo = client.PostAsync(urlPo, httpContent).Result;
                var resPo = responsePo.Content.ReadAsStringAsync().Result;
                dynamic rPo = JObject.Parse(resPo);

                Console.WriteLine(rPo);

                //PUT
                string urlPu = "https://jsonplaceholder.typicode.com/posts/1";
                client.DefaultRequestHeaders.Clear();
                string parametrosPu = "{'title': 'Titulo prueba Put', 'body': 'Body prueba Put', 'userId': '1'}";
                dynamic jsonStringPu = JObject.Parse(parametrosPu);

                var httpContentPu = new StringContent(jsonStringPu.ToString(), Encoding.UTF8, "application/json");
                var responsePu = client.PutAsync(urlPu, httpContentPu).Result;
                var resPu = responsePu.Content.ReadAsStringAsync().Result;
                dynamic rPu = JObject.Parse(resPu);

                Console.WriteLine(rPu);


                //PATCH
                string urlPa = "https://jsonplaceholder.typicode.com/posts/1";
                client.DefaultRequestHeaders.Clear();
                string parametrosPa = "{'title': 'Titulo prueba Patch'}";
                dynamic jsonStringPa = JObject.Parse(parametrosPa);

                var httpContentPa = new StringContent(jsonStringPa.ToString(), Encoding.UTF8, "application/json");
                var responsePa = client.PatchAsync(urlPa, httpContentPa).Result;
                var resPa = responsePa.Content.ReadAsStringAsync().Result;
                dynamic rPa = JObject.Parse(resPu);

                Console.WriteLine(rPa);

            }


        }
    }
}

//JObject: Es una clase proporcionada por la librería Newtonsoft.Json que representa un objeto JSON.

//JObject.Parse(res): La función Parse toma una cadena de texto que contiene datos en formato JSON y la convierte en un objeto JObject. En este caso, la cadena de texto está almacenada en la variable res.

//dynamic r = ...: La palabra clave dynamic en C# permite que el tipo de la variable sea determinado en tiempo de ejecución en lugar de tiempo de compilación. En este caso, la variable r se está declarando como dynamic para que pueda contener cualquier tipo de objeto.