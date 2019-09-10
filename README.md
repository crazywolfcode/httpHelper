![logo](https://raw.githubusercontent.com/crazywolfcode/httpHelper/master/logo.png)
![dotnet-version](https://img.shields.io/badge/.net-%3E%3D4.0-blue.svg) 
![csharp-version](https://img.shields.io/badge/C%23-7.3-blue.svg) 
![IDE-version](https://img.shields.io/badge/IDE-vs2019-blue.svg)
[![nuget-version](https://img.shields.io/nuget/v/1.0.3)](https://www.nuget.org/packages/httpapihelper/)
![qq-group](https://img.shields.io/badge/qq-443055589-red.svg)
# httpApiHelper
基于 System.Net.HttpWebRequest 封装，方便，易用；引用函数式编程思想，让代码更加的优雅，高可读性。

## 说明
  * 只支持返回类型为 json 的请求
  * .SetHeaders() 该方法不必须，为满足需要认证和请求头信息的请求而设
  * .OnStart() 、.OnSuccess、.OnFailure()、.OnError() 这些方法不必须，与顺序无关。
  * .OnSuccess、.OnFailure()、.OnError() 互斥，只会调用其中一个。
  * 默认带Cookies 请求。
  
## 使用

Step 1：在nuget上添加对 httpapihelper 的引用或搜索 httpapihelper;; 

```Install-Package httpapihelper```

![import](https://raw.githubusercontent.com/crazywolfcode/httpHelper/master/import.png)

Step 2：添加引用 
  ```
  using HttpApiHelper;
  ```

Step 3：使用 

* GET 用法
  ```
  //简单用法
   public void TestGet()
        {
            string url = "http://127.0.0.1:8080/nbm/login/test";
            HttpWebRequestHelper<List<User>>.Instance              
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
                .Get(url); 
              
        }
  ```
  
  ```
  //基本用法
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
  ```
  
  ```
  public void TestGet()
        {
            string url = "http://127.0.0.1:8080/nbm/login/test";

            HttpWebRequestHelper<User>.Instance
                .OnStart(() =>
                {
                    Console.WriteLine("STart ...");
                })
                .OnSuccess((result) =>
                {
                    Console.WriteLine("Success ...");
                   User m = result.Data;                   
                   Console.WriteLine("name:" + m.name + " age :" + m.age);                    
                })
                .OnFailure((res) =>
                {
                    Console.WriteLine("Failure ..code:+" + res.Code + "...msc:" + res.Message);
                })
                .OnError((res) =>
                {
                    Console.WriteLine("Error ..code:+" + res.Code + "...msc:" + res.Message);
                })
                //.Get(url); //不需要传参
                .Get(url, "id=56"); // 带参数
        }
  ```
  
  * Post 用法
  
  ```
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
                  .SetHeaders(headerCollection) // 不必须
                 // .Post(url, collection); //参数类型为 NameValueCollection
                 //.Post<User>(url, user);  //参数为对像 
                 //.Post(url, "name=code&age=56"); //参数为字符串
                 .Post(url); //不需要参数
        }
  ```
  ```
            string url = "http://127.0.0.1:8080/nbm/login/test";
          
            HttpWebRequestHelper<User>.Instance                
                  .OnSuccess((result) =>
                  {
                      Console.WriteLine("Success ...");
                      User Users = result.Data;
                      for (int i = 0; i < Users.Count; i++)
                      {
                          User m = Users[i];
                          Console.WriteLine("name:" + m.name + " age :" + m.age + " salary:" + m.salary);
                      }
                  })                 
                 .Post(url);

  ```

## 捐赠
如果您觉得httpHelper还不错，并且刚好有些闲钱，那么可以选择以下方式来捐赠：

* 支付宝  
![qrcode](https://raw.githubusercontent.com/crazywolfcode/httpHelper/master/zfb.jpg)
* 微信  
![qrcode](https://raw.githubusercontent.com/crazywolfcode/httpHelper/master/wxRevard.png)
