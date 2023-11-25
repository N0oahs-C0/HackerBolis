using Android.Content;
using Android.Media;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BoliBolis
{
    [Activity(Label = "Menu_Principal")]
    public class MenuBolis : Activity
    {
        protected override void OnCreate(Bundle? savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            // Set our view from the "main" layout resource
            SetContentView(Resource.Layout.MenuActivity);
            var imagen1 = FindViewById<ImageView>
                (Resource.Id.imgIngresarBolis);
            imagen1.SetImageResource(Resource.Drawable.Bolis);
            var imagen2 = FindViewById<ImageView>
                (Resource.Id.imgVerBolis);
            imagen2.SetImageResource(Resource.Drawable.VerBolis);
            var imagen3 = FindViewById<ImageView>
                (Resource.Id.imgIngresarVentas);
            imagen3.SetImageResource(Resource.Drawable.Ventas);
            var imagen4 = FindViewById<ImageView>
                (Resource.Id.imgVerVentas);
            imagen4.SetImageResource(Resource.Drawable.VerVentas);
            var btnAddBolis = FindViewById<Button>
                (Resource.Id.btnAddBolis);
            var btnAddVentas = FindViewById<Button>
                (Resource.Id.btnAddVentas);
            var btnverbolis = FindViewById<Button>
                (Resource.Id.btnViewBolis);
            var btnverventas = FindViewById<Button>
                (Resource.Id.btnViewVentas);
            btnAddBolis.Click += delegate
            {
                CargarBolis();
            };
            btnAddVentas.Click += delegate
            {
                CargarVentas();
            };
            btnverbolis.Click += delegate
            {
                try
                {
                    Id = int.Parse(txtId.Text); var API =
                    $"http://192.168.215.49:89/Principal/ConsultarVentas?id={Id}"; var json = await TraerDatos(API);
                    foreach (var repo in json)
                    {
                        txtFkBolis.Text = repo.Bolis; txtCantidad.Text = repo.Cantidad.ToString();
                        txtFecha.Text = repo.Fecha;

                        CargarVBolis();
                    }
                }
                catch (Exception ex)
                {
                    Toast.MakeText(this, ex.Message, ToastLength.Long).Show();
                    throw;
                }
            };
            btnverventas.Click += delegate
            {
                CargarVVentas();    
            };

        }

        public void CargarBolis()
        {
            Intent Ventana = new Intent(this, typeof(Bolis));
            StartActivity(Ventana);
        }
        public void CargarVentas()
        {
            Intent Ventana = new Intent(this, typeof(Ventas));
            StartActivity(Ventana);
        }
        public void CargarVBolis()
        {
            Intent Ventana = new Intent(this, typeof(VerBolis));
            StartActivity(Ventana);
        }
        public void CargarVVentas()
        {
            Intent Ventana = new Intent(this, typeof(VerVentas));
            StartActivity(Ventana);
        }

    }
}
