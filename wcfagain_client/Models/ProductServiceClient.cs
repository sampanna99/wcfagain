using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Runtime.Serialization.Json;
using System.Text;
using System.Web.Script.Serialization;

namespace wcfagain_client.Models
{
    public class ProductServiceClient
    {
        private string BASE_URL = "http://localhost:50605/ServiceProduct.svc/";
        public List<Product> findAll()
        {
            try
            {
                var webclient = new WebClient();
                var json = webclient.DownloadString(BASE_URL + "findAll");
                var js = new JavaScriptSerializer();
                return js.Deserialize<List<Product>>(json);
            }
            catch
            {

                return null;
            }
        }



        public Product find(int id)
        {
            try
            {
                var webclient = new WebClient();
                string url = string.Format(BASE_URL + "find/{0}", id);
                var json = webclient.DownloadString(url);
                var js = new JavaScriptSerializer();
                return js.Deserialize<Product>(json);
            }
            catch
            {

                return null;
            }
        }

        public bool Create(Product product)
        {
            try
            {
                DataContractJsonSerializer ser = new DataContractJsonSerializer(typeof(Product));
                MemoryStream mem = new MemoryStream();
                ser.WriteObject(mem, product);
                string data = Encoding.UTF8.GetString(mem.ToArray(), 0, (int)mem.Length);
                WebClient webclient = new WebClient();
                webclient.Headers["Content-type"] = "application/json";
                webclient.Encoding = Encoding.UTF8;
                webclient.UploadString(BASE_URL + "create", "POST", data);
                return true;
            }
            catch
            {

                return false;
            }
        }

        public bool edit(Product product)
        {
            try
            {
                DataContractJsonSerializer ser = new DataContractJsonSerializer(typeof(Product));
                MemoryStream mem = new MemoryStream();
                ser.WriteObject(mem, product);
                string data = Encoding.UTF8.GetString(mem.ToArray(), 0, (int)mem.Length);
                WebClient webclient = new WebClient();
                webclient.Headers["Content-type"] = "application/json";
                webclient.Encoding = Encoding.UTF8;
                webclient.UploadString(BASE_URL + "edit", "PUT", data);
                return true;
            }
            catch
            {

                return false;
            }
        }

        public bool delete(Product product)
        {
            try
            {
                DataContractJsonSerializer ser = new DataContractJsonSerializer(typeof(Product));
                MemoryStream mem = new MemoryStream();
                ser.WriteObject(mem, product);
                string data = Encoding.UTF8.GetString(mem.ToArray(), 0, (int)mem.Length);
                WebClient webclient = new WebClient();
                webclient.Headers["Content-type"] = "application/json";
                webclient.Encoding = Encoding.UTF8;
                webclient.UploadString(BASE_URL + "delete", "DELETE", data);
                return true;
            }
            catch
            {

                return false;
            }
        }
    }
}