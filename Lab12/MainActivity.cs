using Android.App;
using Android.Widget;
using Android.OS;
using Android.Views;
using Android.Content;
using System;
using Android.Graphics;

namespace Lab12
{
    [Activity(Label = "Lab12", MainLauncher = true, Icon = "@drawable/icon")]
    public class MainActivity : Activity
    {
        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);
            Validate();

            // Set our view from the "main" layout resource
            SetContentView (Resource.Layout.Main);
            var ListColors = FindViewById<ListView>(Resource.Id.listView1);
            ListColors.Adapter = new CustomAdapters.ColorAdapter(
                this,
                Resource.Layout.ListItem,
                Resource.Id.textView1,
                Resource.Id.textView2,
                Resource.Id.imageView1);

            //// Establecemos el contenido para el MainActivity
            //// var MyLayout = new MyViewGroup(this);
            //// Establecemos el contenido
            //// SetContentView(MyLayout);
        }

        private async void Validate()
        {
            string myDevice = Android.Provider.Settings.Secure.GetString(ContentResolver, Android.Provider.Settings.Secure.AndroidId);

            var ServiceClient = new SALLab12.ServiceClient();
            var Result = await ServiceClient.ValidateAsync("geduartev@gmail.com", "cpx762tt", myDevice);
            var ValidateMessage = FindViewById<TextView>(Resource.Id.ValidateMessageTextView);
            ValidateMessage.SetPadding(40, 20, 0, 0);
            ValidateMessage.Text = $"{Result.Status}\n{Result.FullName}\n{Result.Token}";
        }
    }

    class MyViewGroup : ViewGroup
    {
        Context ViewGroupContext;

        public MyViewGroup(Context context) : base(context)
        {
            this.ViewGroupContext = context;
        }

        protected override void OnLayout(bool changed, int l, int t, int r, int b)
        {
            // Agregando un elemento de interfaz de usuario.
            
            // Establecer color de fondo al Layout
            this.SetBackgroundColor(Color.Fuchsia);
            // Agregamos un objeto View
            var MyView = new View(ViewGroupContext);
            // Un view es un objeto que se dibuja en la pantalla, es algo con lo que el usuario puede interactuar.
            MyView.SetBackgroundColor(Color.Blue);
            // Personalizamos la ubicación sobre el layout
            MyView.Layout(20, 20, 150, 150);
            // Lo agregamos al layout
            AddView(MyView);
        }
    }
 }

