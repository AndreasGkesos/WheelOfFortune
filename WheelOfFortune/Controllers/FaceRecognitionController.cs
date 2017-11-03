using System;
using System.Collections.Generic;
using System.Configuration;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using Microsoft.ProjectOxford.Face;
using Microsoft.ProjectOxford.Face.Contract;
using System.Net.Http;
using System.Net.Http.Headers;
using Microsoft.Ajax.Utilities;

namespace WheelOfFortune.Controllers
{
    public class FaceRecognitionController : Controller
    {

        private static string ServiceKey = "b75c2e1cabfd41928697c1d953303f5b";
        private static string EndPoint = ConfigurationManager.AppSettings["FaceServiceEndPoint"];

                [HttpGet]
                public  async Task<dynamic> GetDetectedFaces(string path)
                {
                  //var photo = new byte[userPhoto.ContentLength];
                  
                     if (path.IsNullOrWhiteSpace()) return false;
                    try
                    {
                      
                    // Create Instance of Service Client by passing Servicekey as parameter in constructor 
                            var faceServiceClient = new FaceServiceClient(ServiceKey);
                            var faces = await faceServiceClient.DetectAsync(path, true, true, new FaceAttributeType[] { FaceAttributeType.Gender, FaceAttributeType.Age, FaceAttributeType.Smile, FaceAttributeType.Glasses });
                            var results = faces.Length;


                            return results != 0;
                

                      
                    }
                    catch (FaceAPIException)
                    {
                        //do exception work
                    }
        
                    return false;
                }
//        [HttpGet]
//        public async Task<dynamic> MakeAnalysisRequest(byte[] picture)
//        {
//            var client = new HttpClient();
//
//            // Request headers.
//            client.DefaultRequestHeaders.Add("Subscription-Key", ServiceKey);
//
//            // Request parameters. A third optional parameter is "details".
//            const string requestParameters = "returnFaceId=true&returnFaceLandmarks=false&returnFaceAttributes=age,gender,headPose,smile,facialHair,glasses,emotion,hair,makeup,occlusion,accessories,blur,exposure,noise";
//
//            // Assemble the URI for the REST API Call.
//            var uri = EndPoint + "?" + requestParameters;
//
//            // Request body. Posts a locally stored JPEG image.
//          
//
//            using (var content = new ByteArrayContent(picture))
//            {
//                // This example uses content type "application/octet-stream".
//                // The other content types you can use are "application/json" and "multipart/form-data".
//                content.Headers.ContentType = new MediaTypeHeaderValue("application/json");
//
//                // Execute the REST API call.
//                var response = await client.PostAsync(uri, content);
//               
//                // Get the JSON response.
//                var contentString = await response.Content.ReadAsStringAsync();
//
//                // Display the JSON response.
//                Debug.WriteLine("\nResponse:\n" + contentString);
//
//                return true;
//            }
//        }
    }
}