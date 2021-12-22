using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;

using Foundation;
using Kapicua25.iOS.CustomRenderers;
using Kapicua25.Renderer;
using UIKit;
using Xamarin.Forms;
using Xamarin.Forms.Platform.iOS;

[assembly: ExportRenderer(typeof(BorderlessEntryWithDoneButton), typeof(BorderlessEntryRendererWithDoneButton))]
namespace Kapicua25.iOS.CustomRenderers
{
    public class BorderlessEntryRendererWithDoneButton : EntryRenderer
    {
        protected override void OnElementChanged(ElementChangedEventArgs<Entry> e)
        {
            base.OnElementChanged(e);

            if (Control != null && Element != null)
            {
                Control.BackgroundColor = Xamarin.Forms.Color.Transparent.ToUIColor();
                Control.Layer.BackgroundColor = Xamarin.Forms.Color.Transparent.ToCGColor();
                Control.BorderStyle = UITextBorderStyle.None;
                this.AddDoneButton();
            }
        }

        protected void AddDoneButton()
        {
            var toolbar = new UIToolbar(new RectangleF(0.0f, 0.0f, 50.0f, 44.0f));
            toolbar.BackgroundColor = UIColor.LightGray;
            var doneButton = new UIBarButtonItem(UIBarButtonSystemItem.Done, delegate
            {
                this.Control.ResignFirstResponder();
                var baseEntry = this.Element.GetType();
                ((IEntryController)Element).SendCompleted();
            });

            toolbar.Items = new UIBarButtonItem[] {
                new UIBarButtonItem (UIBarButtonSystemItem.FlexibleSpace),
                doneButton
            };
            this.Control.InputAccessoryView = toolbar;
        }
    }
}