using Android.Content;

namespace BoliBolis
{
    [Activity(Label = "@string/app_name", MainLauncher = true)]
    public class MainActivity : Activity
    {
        string Usuario, Pass;
        protected override void OnCreate(Bundle? savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            // Set our view from the "main" layout resource
            SetContentView(Resource.Layout.activity_main);
            var txtnombre = FindViewById<EditText>
                (Resource.Id.txtUsuario);
            var txtpass = FindViewById<EditText>
                (Resource.Id.txtContra);
            var imagen = FindViewById<ImageView>
                (Resource.Id.imgUsu);
            imagen.SetImageResource(Resource.Drawable.Usuario);
            var btnIngresar = FindViewById<Button>
                (Resource.Id.btnIngresar);
            btnIngresar.Click += delegate
            {
                Usuario = txtnombre.Text;
                Pass = txtpass.Text;
                if (Usuario == "Admin" && Pass == "123")
                {
                    Cargar();
                }
            };
        }
        private void BtnIngresar_Click(object? sender, EventArgs e)
        {
            throw new NotImplementedException();
        }

        public void Cargar()
        {
            Intent Ventana = new Intent(this, typeof(MenuBolis));
            StartActivity(Ventana);
        }
    }
}