using J3Week.Models;
using J3Week.Views;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace J3Week.ViewModels
{
    public class LoginViewModel
    {
        public INavigation Navigation { get; set; }
        public Command LoginCommand { get; }

        public LoginViewModel(INavigation appNav)
        {
            Navigation = appNav;
            LoginCommand = new Command(async () => await ExeLoginCommand());
        }

        private async Task ExeLoginCommand()
        {
            var client = new HttpClient();
            client.BaseAddress = new Uri("http://10.0.2.2");


            Debug.WriteLine("Tạo object data");

            var data = new InfoLogin()
            {
                Email = "eri@email",
                Passwords = "123"
                // Tắt đi thì không cần login
                //Email = username.Text,
                //Passwords = password.Text,

            };
            Debug.WriteLine("Chuyển json data");
            string jsonMessage = JsonConvert.SerializeObject(data);
            //string jsonData = @"{""Email"" : ""eri@email"", ""Passwords"" : ""123""}";

            var content = new StringContent(jsonMessage, Encoding.UTF8, "application/json");
            //HttpResponseMessage response = await client.PostAsync("/foo/login", content);

            HttpResponseMessage response = await client.PostAsync("/login", content);

            string result = await response.Content.ReadAsStringAsync();

            Debug.WriteLine("Kết quả");
            Debug.WriteLine(result);


            Debug.WriteLine("Chuyển object");
            ResponseLogin responselogin = JsonConvert.DeserializeObject<ResponseLogin>(result);

            Debug.WriteLine("Gọi if");
            if (responselogin.code == 1)
            {
                Debug.WriteLine("Đúng");
                await Navigation.PushModalAsync(new Views.Profile());
            }
            else
            {
                await Navigation.PushModalAsync(new LoginError());
            }
        }
    }
}
