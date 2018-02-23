using System;
using Xamarin.Forms;

namespace RedditClient.Controls
{
    public class AdvancedListView : ListView
    {
        public AdvancedListView() : base()
        {
            ItemTapped += (sender, e) =>
            {
                if(ItemTappedCommand?.CanExecute(e.Item) ?? false)
                {
                    ItemTappedCommand.Execute(e.Item);
                }
            };

            ItemSelected += (sender, e) => SelectedItem = null;
        }

        #region Bindable properties

        public static readonly BindableProperty ItemTappedCommandProperty = BindableProperty.Create(
            nameof(ItemTappedCommand),
            typeof(Command),
            typeof(AdvancedListView));

        public Command ItemTappedCommand
        {
            get { return (Command)GetValue(ItemTappedCommandProperty); }
            set { SetValue(ItemTappedCommandProperty, value); }
        }

        #endregion
    }
}
