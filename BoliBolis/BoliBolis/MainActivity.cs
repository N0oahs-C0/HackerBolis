namespace BoliBolis
{
    [Activity(Label = "@string/app_name", MainLauncher = true)]
    public class MainActivity : Activity
    {
        TextView txtnombre, txtpass;
        ImageView imagen;
        protected override void OnCreate(Bundle? savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            // Set our view from the "main" layout resource
            SetContentView(Resource.Layout.activity_main);
            txtpass = FindViewById<TextView>(Resource.Id.txtContra);
            txtnombre = FindViewById<TextView>(Resource.Id.txtUsuario);
            imagen = FindViewById<ImageView>(Resource.Id.imgUsu);
        }
    }
}