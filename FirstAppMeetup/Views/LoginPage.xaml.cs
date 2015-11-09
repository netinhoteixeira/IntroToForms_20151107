using System;
using System.Collections.Generic;

using Xamarin.Forms;

namespace FirstAppMeetup
{
	public partial class LoginPage : ContentPage
	{
		public LoginPage ()
		{
			InitializeComponent ();
		}

		void Login_Clicked(object sender, EventArgs e){
			Navigation.PushAsync (new ListaAmigos());
		}
	}
}

