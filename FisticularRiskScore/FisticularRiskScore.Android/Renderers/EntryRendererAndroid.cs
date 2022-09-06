using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using FisticularRiskScore.Droid.Renderers;
using FisticularRiskScore.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;

//[assembly: ExportRenderer(typeof(MyCustomEntry), typeof(EntryRendererAndroid))]

namespace FisticularRiskScore.Droid.Renderers
{
    public class EntryRendererAndroid : EntryRenderer
    {
        public EntryRendererAndroid(Context context) : base(context)
        {
        }

        private MyCustomEntry customEntry;

        protected override void OnElementChanged(ElementChangedEventArgs<Entry> e)
        {
            base.OnElementChanged(e);

            if (e.OldElement == null)
            {
                //customEntry = (MyCustomEntry)e.NewElement;
                var gradientDrawable = new GradientStrokeDrawable();

                gradientDrawable.SetCornerRadius(customEntry.CornerRadius);
                gradientDrawable.SetColor(Color.White.ToAndroid());

                Control.SetBackground(gradientDrawable);
            }
        }
    }
}