using System;
using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;

namespace PadillaMelitonAssn2
{
    [Activity(Label = "Assumptions")]
    public class SecondActivity : Activity
    {
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.Second);
            // Create button to submit and test form
            Button btnSubmitForm = (Button)FindViewById(Resource.Id.btnSubmitForm);
            btnSubmitForm.Click += btnSubmitForm_Click;
        }

        private void btnSubmitForm_Click(object sender, EventArgs args)
        {
            // variables
            int amount;
            float interestRate;
            int term;
            bool resultOp1, resultOp2, resultOp3;

            // Set values
            EditText etAmountIn = (EditText)FindViewById(Resource.Id.etAmountIn);
            EditText etInterestRateIn = (EditText)FindViewById(Resource.Id.etIntrestRateIn);
            EditText etTermIn = (EditText)FindViewById(Resource.Id.etTermIn);
            TextView txtResultOuput = (TextView)FindViewById(Resource.Id.txtResultOutput);

            // Test for actual input
            // Attempt to convert input to a number
            resultOp1 = int.TryParse(etAmountIn.Text, out amount);
            resultOp2 = float.TryParse(etInterestRateIn.Text, out interestRate);
            resultOp3 = int.TryParse(etTermIn.Text, out term);

            //Test for correct input
            if (resultOp1 == true && resultOp2 == true && resultOp3 == true )
            {
                // Test for value parameters
                if (amount < 1000001 && amount > 999 && term > 0 && term < 31 && Math.Abs(interestRate) > 0.00 && Math.Abs(interestRate) < 0.21)
                {
                    // Load data and send to next form
                    Intent activityIntent = new Intent(this, typeof(FunctionActivity));

                    // Pass data to activity three
                    activityIntent.PutExtra("Amount", amount);
                    activityIntent.PutExtra("Interest", interestRate);
                    activityIntent.PutExtra("Term", term);
        
                    StartActivity(activityIntent);
                    txtResultOuput.Text = " Data Accepted";
                }
                else
                {
                    txtResultOuput.Text = "Error: Input is invalid or incorrect format, try again";
                }

            }
            else
            {
                txtResultOuput.Text = "Error: Input is invalid or incorrect format, try again";
            }



        }
    }
}