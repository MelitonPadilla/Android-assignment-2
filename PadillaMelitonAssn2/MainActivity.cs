using Android.App;
using Android.Widget;
using Android.OS;
using Android.Content;

namespace PadillaMelitonAssn2
{
    [Activity(Label = "PadillaMelitonAssn2", MainLauncher = true, Icon = "@drawable/icon")]
    public class MainActivity : Activity
    {
        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);

            // Set our view from the "main" layout resource
            SetContentView (Resource.Layout.Main);
            // Button set up
            Button btnExitApp = (Button)FindViewById(Resource.Id.btnExitApp);
            btnExitApp.Click += btnExitApp_Click;
            Button btnAssumptions = (Button)FindViewById(Resource.Id.btnAssumptions);
            btnAssumptions.Click += btnAssumptions_Click;
            Button btnDialogBox = (Button)FindViewById(Resource.Id.btnDialogBox);
            btnDialogBox.Click += btnDialogBox_Click;

        }

        private void btnDialogBox_Click(object sender, System.EventArgs args)
        {
            // First create the alert, set the title and message.
            AlertDialog.Builder alert = new AlertDialog.Builder(this);
            alert.SetTitle("Confirm action");
            alert.SetMessage("Are you sure that you want to complete this action.");

            // Setup the three buttons. Here we are using lambda expressions
            // but the other event wiring technqiues will work too.
            alert.SetPositiveButton("Text", (senderAlert, args1) =>
            {
                // Input defualt phone number 
                var smsUri = Android.Net.Uri.Parse("smsto:7752238653");
                var smsIntent = new Intent(Intent.ActionSendto, smsUri);
                smsIntent.PutExtra("sms_body", "Hello from Xamarin.Android");
                StartActivity(smsIntent);
            });

            alert.SetNeutralButton("Cancel", (senderAlert, args1) =>
            {
                // do nothing
                // Toast.MakeText(this, "Neutral!", ToastLength.Short).Show();
            });

            alert.SetNegativeButton("E-Mail", (senderAlert, args1) =>
            {
                var email = new Intent(Intent.ActionSend);
                email.PutExtra(Android.Content.Intent.ExtraEmail, 
                    new string[] { "melitonnpadilla@gmail.com", "melitonmw@gmail.com" });
                email.PutExtra(Android.Content.Intent.ExtraSubject, "Hello Email");
                email.PutExtra(Android.Content.Intent.ExtraText,"Hello ");
                email.SetType("message/rfc822");
                // If no email set up can inform user what needs to be used
                StartActivity(Intent.CreateChooser(email, "Send Mail Using :"));
                //StartActivity(email);
            });

            // Display the alert. 
            alert.Show();
        }

        private void btnExitApp_Click(object sender, System.EventArgs args)
        {
            Finish();
        }

        private void btnAssumptions_Click(object sender, System.EventArgs args)
        {
            Intent activityIntent = new Intent(this, typeof(SecondActivity));
            StartActivity(activityIntent);
        }
    }
}

