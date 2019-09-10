using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Text;
using Newtonsoft.Json;
using HttpHelper;
namespace HttpHelperDemo
{
    public class Test
    {
        public void TestPost()
        {
            string url = "http://127.0.0.1:8080/nbm/login/test";
            NameValueCollection collection = new NameValueCollection
            {
                {"name","code"},
                {"age","80" },
                {"salary","12.90" }
            };
            System.Net.WebHeaderCollection headerCollection = new System.Net.WebHeaderCollection
           {
               {"token","qmfamdfasdfm" }
           };
           User user = new User() { name = "code", age = 90, salary = 89.09 };

            HttpWebRequestHelper<List<User>>.Instance
                  .OnStart(() =>
                  {
                      Console.WriteLine("-------------STart ...");
                  })
                  .OnSuccess((result) =>
                  {
                      Console.WriteLine("Success ...");
                      List<User> Users = result.Data;
                      for (int i = 0; i < Users.Count; i++)
                      {
                          User m = Users[i];
                          Console.WriteLine("name:" + m.name + " age :" + m.age + " salary:" + m.salary);
                      }
                  })
                  .OnFailure((res) =>
                  {
                      Console.WriteLine("Failure ..code:+" + res.Code + "...msc:" + res.Message);
                  })
                  .OnError((res) =>
                  {
                      Console.WriteLine("Error ..code:+" + res.Code + "...msc:" + res.Message);
                  })
                  .SetHeaders(headerCollection)
                 // .Post(url, collection);
                 //.Post<User>(url, user);
                 //.Post(url, "name=code&age=56");
                 .Post(url);
        }

        public void TestGet()
        {
            string url = "http://127.0.0.1:8080/nbm/login/test";

            HttpWebRequestHelper<List<User>>.Instance
                .OnStart(() =>
                {
                    Console.WriteLine("STart ...");
                })
                .OnSuccess((result) =>
                {
                    Console.WriteLine("Success ...");
                    List<User> Users = result.Data;
                    for (int i = 0; i < Users.Count; i++)
                    {
                        User m = Users[i];
                        Console.WriteLine("name:" + m.name + " age :" + m.age);
                    }
                })
                .OnFailure((res) =>
                {
                    Console.WriteLine("Failure ..code:+" + res.Code + "...msc:" + res.Message);
                })
                .OnError((res) =>
                {
                    Console.WriteLine("Error ..code:+" + res.Code + "...msc:" + res.Message);
                })
                .Get(url); //不需要传参
                           //.Get(url, "name=code&age=56"); // 带参数
        }

    }
}
