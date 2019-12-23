﻿using J3Week.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace J3Week.Views
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class LoginPage : ContentPage
	{
        public LoginPage ()
		{
			InitializeComponent ();
            //BindingContext = new LoginViewModel(Navigation);
        }

        private void BtnLogin_Clicked(object sender, EventArgs e)
        {
            Navigation.PushModalAsync(new MainPage());
        }
    }
}