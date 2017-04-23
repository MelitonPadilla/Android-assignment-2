using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;

namespace PadillaMelitonAssn2
{
    [Activity(Label = "FunctionActivity")]
    public class FunctionActivity : Activity
    {
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.function);
            // Create your application here
            TextView tvIntentPV = (TextView)FindViewById(Resource.Id.tvIntentPV);
            TextView tvIntentFV = (TextView)FindViewById(Resource.Id.tvIntentFV);
            TextView tvIntentPMT = (TextView)FindViewById(Resource.Id.tvIntentPMT);

            // Get extra data
            int amount = Intent.GetIntExtra("Amount",0);
            float interestRate = Intent.GetFloatExtra("Interest", 0);
            int term = Intent.GetIntExtra("Term", 0);

            //tvIntentPV.Text = " its" + amount;
            //tvIntentFV.Text = "its" + interestRate;
            //tvIntentPMT.Text = "its" + term;

            // Convert
            double rate = ((double)interestRate)/12;
            int numPayments = term * 12;
            double PMTanswer;
            double FVanswer;
            double PVanswer;

            // Start PMT
            PMTanswer = calcPMT(rate, numPayments, amount);
            tvIntentPMT.Text = "Result: " + PMTanswer;

            // Start FV
            FVanswer = calcFV(rate, numPayments, PMTanswer, amount);
            tvIntentFV.Text = "Result: " + FVanswer;

            // Start PV
            PVanswer = calcPV(FVanswer, numPayments, rate);
            tvIntentPV.Text = "Result: " + PVanswer;



        }

        public double calcPMT(double rate, int numberOfPayments, double amount)
        {
            double temp = System.Math.Pow((rate + 1), numberOfPayments);
            return ((-amount * temp) / ((temp - 1) * rate));
        }

        public double calcFV(double rate, int numberOfPayments, double payment, double amount)
        {
            double temp = System.Math.Pow(rate + 1, numberOfPayments);
            return ((-amount) * temp)-((payment / rate) * (temp - 1));
        }

        public double  calcPV(double futureValue, int numberOfPayments, double rate)
        {
            return ((futureValue) / Math.Pow(1 + rate, numberOfPayments));
        }
    
    }
}