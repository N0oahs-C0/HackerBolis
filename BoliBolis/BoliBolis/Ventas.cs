using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BoliBolis
{
    [Activity(Label = "Ventas")]
    public class Ventas : Activity
    {
        EditText? txtfkbolis, txtcantidad;
        Button btnguardar;
        int fkbolis, cantidad;
        HttpClient client = new HttpClient();
        protected override void OnCreate(Bundle? savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            txtcantidad = FindViewById<EditText>
                (Resource.Id.txtCantidad);
            txtfkbolis = FindViewById<EditText>
                (Resource.Id.txtFKbolis);
            var btnGuardar = FindViewById<Button>
                (Resource.Id.btnGuardar);
            btnguardar.Click += async delegate
            {
                try
                {

                    fkbolis = int.Parse(txtfkbolis.Text);
                    cantidad = int.Parse(txtcantidad.Text);
                    var API = $"http://192.168.215.49:89/Principal/AlmacenarBolis" +
                    $"costo={fkbolis}" + $"&categoria={cantidad}";
                    HttpResponseMessage response = client.GetAsync(API).Result; if (response.IsSuccessStatusCode)
                    {
                        var resultado = response.Content.ReadAsStringAsync().Result;
                        Toast.MakeText(this, resultado.ToString(), ToastLength.Long).Show();
                    }
                    txtfkbolis.Text = ""; txtcantidad.Text = "";
                }
                catch (Exception ex)
                {
                    Toast.MakeText(this, ex.Message, ToastLength.Long).Show();
                    throw;
                }

            };

        }
    }
}
