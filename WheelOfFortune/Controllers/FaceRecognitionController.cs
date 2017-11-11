using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace WheelOfFortune.Controllers
{
    public class FaceRecognitionController : Controller
    {
        private const string ServiceKey = "b75c2e1cabfd41928697c1d953303f5b";
        private const string EndPoint = "https://westeurope.api.cognitive.microsoft.com/face/v1.0/detect";


        [HttpGet]
        public async Task<dynamic> MakeAnalysis(string path, byte[] picture)
        {
            var client = new HttpClient();

            // Request headers.
            client.DefaultRequestHeaders.Add("Ocp-Apim-Subscription-Key", ServiceKey);


            using (var content = new ByteArrayContent(picture))
            {
                // This example uses content type "application/octet-stream".
                // The other content types you can use are "application/json" and "multipart/form-data".
                content.Headers.ContentType = new MediaTypeHeaderValue("application/octet-stream");

                // Execute the REST API call.
                var response = await client.PostAsync(EndPoint, content);


                // Get the JSON response.
                var contentString = await response.Content.ReadAsStringAsync();

                //if it contains the faceId it has tracked a face 
                return contentString.Contains("faceId");
            }
        }
    }
}