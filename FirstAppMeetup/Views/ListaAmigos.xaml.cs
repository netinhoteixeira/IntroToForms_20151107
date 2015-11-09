using System;
using System.Collections.Generic;
using System.Linq;
using Xamarin.Forms;

namespace FirstAppMeetup
{
	public partial class ListaAmigos : ContentPage
	{
		public ListaAmigos ()
		{
			InitializeComponent ();
			myPicker.Items.Add ("Nome");
			myPicker.Items.Add ("Numero");
			myPicker.SelectedIndexChanged += MyPicker_SelectedIndexChanged;
			lista.ItemsSource = new Amigo[] { 
				new Amigo ("Rafael Moura", "+5531991708983"),
				new Amigo ("Paulo He", "+5531991700001"),
				new Amigo ("Daniel", "+5531991703214"),
				new Amigo ("Rafael Sol", "+5531991704541"),
				new Amigo ("Leandro", "+5531991705555"),
				new Amigo ("Ricardo", "+5531991702313"),
				new Amigo ("Michael", "+5531991753243")
			};

			lista.ItemSelected += Lista_ItemSelected;


		}

		async void MyPicker_SelectedIndexChanged (object sender, EventArgs e)
		{
			
			aiLoad.IsRunning = true;
			Acr.UserDialogs.UserDialogs.Instance.ShowLoading ("Carregando");
			await System.Threading.Tasks.Task.Delay (5000);
			aiLoad.IsRunning = false;
			Acr.UserDialogs.UserDialogs.Instance.HideLoading ();
			switch (myPicker.SelectedIndex) {
			case 0:
				lista.ItemsSource = new Amigo[] { 
					new Amigo ("Rafael Moura", "+5531991708983"),
					new Amigo ("Paulo He", "+5531991700001"),
					new Amigo ("Daniel", "+5531991703214"),
					new Amigo ("Rafael Sol", "+5531991704541"),
					new Amigo ("Leandro", "+5531991705555"),
					new Amigo ("Ricardo", "+5531991702313"),
					new Amigo ("Michael", "+5531991753243")
				}.OrderBy (n => n.Nome);
				break;
			case 1:
				lista.ItemsSource = new Amigo[] { 
					new Amigo ("Rafael Moura", "+5531991708983"),
					new Amigo ("Paulo He", "+5531991700001"),
					new Amigo ("Daniel", "+5531991703214"),
					new Amigo ("Rafael Sol", "+5531991704541"),
					new Amigo ("Leandro", "+5531991705555"),
					new Amigo ("Ricardo", "+5531991702313"),
					new Amigo ("Michael", "+5531991753243")
				}.OrderBy (n => n.Numero);
				break;
			}
		}

		async void Search_TextChanged (object sender, TextChangedEventArgs e)
		{
			aiLoad.IsRunning = true;
			await System.Threading.Tasks.Task.Delay (5000);
			aiLoad.IsRunning = false;
			if (e.NewTextValue != null)
				lista.ItemsSource = new Amigo[] { 
					new Amigo ("Rafael Moura", "+5531991708983"),
					new Amigo ("Paulo He", "+5531991700001"),
					new Amigo ("Daniel", "+5531991703214"),
					new Amigo ("Rafael Sol", "+5531991704541"),
					new Amigo ("Leandro", "+5531991705555"),
					new Amigo ("Ricardo", "+5531991702313"),
					new Amigo ("Michael", "+5531991753243")
				}.Where (n => n.Nome.Contains (e.NewTextValue));
		}

		void Lista_ItemSelected (object sender, SelectedItemChangedEventArgs e)
		{
			if (lista.SelectedItem != null)
				DisplayAlert ("Amigo",	(lista.SelectedItem as Amigo).Nome, "ok");
		}
	}

	class Amigo
	{
		public Amigo (string _nome, string _num)
		{
			Nome = _nome;
			Numero = _num;
		}

		public string Nome {
			get;
			set;
		}

		public string Numero {
			get;
			set;
		}
	}
}

