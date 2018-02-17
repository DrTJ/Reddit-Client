using System;
using System.Collections.Generic;
using System.Diagnostics;
using Xamarin.Forms;

namespace RedditClient.Pages
{
    public partial class MasterPage
    {
        public MasterPage()
        {
            InitializeComponent();
        }

        protected override void OnSizeAllocated(double width, double height)
        {
            base.OnSizeAllocated(width, height);

            if (this.Width > this.Height)
            {
                this.IsPresented = true;
                IsGestureEnabled = false;
            }
            else
            {
                IsGestureEnabled = true;
            }
        }
    }
}
