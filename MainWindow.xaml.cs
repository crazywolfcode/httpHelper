using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using HttpHelper;

namespace HttpHelperDemo
{
    /// <summary>
    /// MainWindow.xaml 的交互逻辑
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }


        private void Btn1_Click(object sender, RoutedEventArgs e)
        {
            TestGet();
        }

        private void Generic_Click(object sender, RoutedEventArgs e)
        {

            testPost();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {

            testPost();
           
        }

        public void testPost()
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
            Model model = new Model() { name = "code", age = 90, salary = 89.09 };

            HttpWebRequestHelper<List<Model>>.Instance
                  .OnStart(() =>
                  {
                      Console.WriteLine("-------------STart ...");
                  })
                  .OnSuccess((result) =>
                  {
                      Console.WriteLine("Success ...");
                      List<Model> models = result.Data;
                      for (int i = 0; i < models.Count; i++)
                      {
                          Model m = models[i];
                          Console.WriteLine("name:" + m.name + " age :" + m.age + " salary:" + m.salary);
                      }
                  })
                  .OnFailure((res) =>
                  {
                      Console.WriteLine("Failure ..code:+" + res.Code + "...msc:" + res.Message);
                  })
                  .OnError((res) =>
                  {
                      MessageBox.Show(res.Code + " : " + res.Message);
                      Console.WriteLine("Error ..code:+" + res.Code + "...msc:" + res.Message);
                  })
                  .SetHeaders(headerCollection)
                 // .Post(url, collection);
                 .Post<Model>(url, model);
        }


        public void TestGet()
        {
            string url = "http://127.0.0.1:8080/nbm/login/test";

            HttpWebRequestHelper<List<Model>>.Instance
                .OnStart(() =>
                {
                    Console.WriteLine("STart ...");
                })
                .OnSuccess((result) =>
                {
                    Console.WriteLine("Success ...");
                    List<Model> models = result.Data;
                    for (int i = 0; i < models.Count; i++)
                    {
                        Model m = models[i];
                        Console.WriteLine("name:" + m.name + " age :" + m.age);
                    }
                })
                .OnFailure((res) =>
                {
                    Console.WriteLine("Failure ..code:+" + res.Code + "...msc:" + res.Message);
                })
                .OnError((res) =>
                {
                    MessageBox.Show(res.Code + " : " + res.Message);
                    Console.WriteLine("Error ..code:+" + res.Code + "...msc:" + res.Message);
                })
                .Get(url, "name=code&age=56");
        }
    }
}
