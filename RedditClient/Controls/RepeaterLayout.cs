using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Xamarin.Forms;

namespace RedditClient.Controls
{
    public class RepeaterLayout : StackLayout
    {
        #region Fields

        #endregion

        #region Constructors

        public RepeaterLayout()
        {
            
        }

        #endregion

        #region Bindable Properties

        public static readonly BindableProperty ItemsSourceProperty = BindableProperty.Create(
            nameof(ItemsSource),
            typeof(IList),
            typeof(RepeaterLayout), 
            propertyChanged: (bindable, oldValue, newValue) =>
            {
                var control = bindable as RepeaterLayout;
                control.ItemsSource = (IList)newValue;
                control.RebuildList();
            }
        );

        public static readonly BindableProperty ItemTemplateProperty = BindableProperty.Create(
            nameof(ItemTemplate),
            typeof(DataTemplate),
            typeof(RepeaterLayout), 
            propertyChanged: (bindable, oldValue, newValue) =>
            {
                var control = bindable as RepeaterLayout;
                control.RebuildList();
            }
        );

        public static readonly BindableProperty ItemTappedCommandProperty = BindableProperty.Create(
            nameof(ItemTappedCommand),
            typeof(Command<object>),
            typeof(RepeaterLayout)
        );

        #endregion

        #region Properties

        public IList ItemsSource
        {
            get => (IList)GetValue(ItemsSourceProperty);
            set { SetValue(ItemsSourceProperty, value); }
        }

        public DataTemplate ItemTemplate
        {
            get => (DataTemplate)GetValue(ItemTemplateProperty);
            set { SetValue(ItemTemplateProperty, value); }
        }

        public Command<object> ItemTappedCommand
        {
            get => (Command<object>)GetValue(ItemTappedCommandProperty);
            set { SetValue(ItemTappedCommandProperty, value); }
        }

        #endregion

        #region Methods

        public void RebuildList()
        {
            if (ItemsSource == null || ItemsSource.Count == 0)
            {
                this.Children.Clear();
                return;
            }

            foreach (var item in ItemsSource)
            {
                var view = this.GenerateItemLayout(item);

                if (view != null)
                {
                    this.Children.Add(view);
                }
            }
        }

        private View GenerateItemLayout(object context)
        {
            ViewCell content = (ViewCell)this.ItemTemplate.CreateContent();
            View view = content?.View;

            if (view == null)
            {
                return null;
            }

            view.BindingContext = context;

            if(ItemTappedCommand != null)
            {
				view.GestureRecognizers.Add(new TapGestureRecognizer() { Command = ItemTappedCommand });
            }

            return view;
        }

        #endregion
    }
}
