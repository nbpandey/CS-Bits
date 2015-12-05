using System;
using System.Collections.Generic;
using System.Web.Script.Serialization;

namespace ConsoleApplication1
{
    class JsonSerializeDemo
    {
  
        static void Main()
        {
            List<ListItem> oList = new List<ListItem>() {
                new ListItem() { UserId = "1", UserName = "Admin"},
                new ListItem() { UserId = "2", UserName = "JohnDoe", label = "Mr."},
                new ListItem() { UserId = "3", UserName = "JaneDoe", label = "Mrs."}
            };

            JavaScriptSerializer oSerializer = new JavaScriptSerializer();
            string sJSON = oSerializer.Serialize(oList);
            Console.WriteLine("Serializing List object into JSON....");
            Console.WriteLine(sJSON);

            List<ListItem> list = oSerializer.Deserialize<List<ListItem>>(sJSON);
            Console.WriteLine("\nDeSerializing List<Car> object into JSON....");
            foreach (var item in list)
            {
                Console.WriteLine("{0}. {2} {1}", item.UserId, item.UserName, item.label);
            }

            Console.ReadLine();
        }
    }

    class ListItem{
        public string UserId { get; set; }
        public string UserName {get; set;}
        public string label { get; set; }
    }
}
