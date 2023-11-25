using Android.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BoliBolis
{
    [Activity(Label = "Bolis")]
    public class Bolis : Activity
    {
        EditText? txtcosto, txtsabor, txtcategoria;
        Button btnguardar;
        string Sabor, Categoria;
        double Costo;
        HttpClient client = new HttpClient();
        protected override void OnCreate(Bundle? savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            txtcosto = FindViewById<EditText>
                (Resource.Id.txtCosto);
            txtcategoria = FindViewById<EditText>
                (Resource.Id.txtCategoria);
            txtsabor = FindViewById<EditText>
                (Resource.Id.txtSabor);
            var btnGuardar = FindViewById<Button>
                (Resource.Id.btnGuardar);
            btnguardar.Click += async delegate
            {
                try
                {
                
                    Sabor = txtsabor.Text;
                    Categoria = txtcategoria.Text;
                    Costo = double.Parse(txtcosto.Text);
                    var API = $"http://192.168.215.49:89/Principal/AlmacenarBolis" +
                    $"costo={Costo}" + $"&categoria={Categoria}" +
                    $"&sabor={Sabor}";
                    HttpResponseMessage response = client.GetAsync(API).Result; if (response.IsSuccessStatusCode)
                    {
                        var resultado = response.Content.ReadAsStringAsync().Result;
                        Toast.MakeText(this, resultado.ToString(), ToastLength.Long).Show();
                    }
                    txtsabor.Text = ""; txtcosto.Text = "";
                    txtcategoria.Text = ""; 
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
