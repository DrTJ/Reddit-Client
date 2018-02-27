using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using RedditClient.Helpers;
using RedditClient.Models;
using Xamarin.Forms;

namespace RedditClient.ViewModels
{
    public class DrawerPageViewModel : ViewModelBase
    {
        #region Fields
		
        private ObservableCollection<RedditPost> drawerItems;

        private Command<RedditPost> itemTappedCommand;

        private Command<RedditPost> dismissItemCommand;

        private Command dismissAllCommand;

        private Command pullToRefreshCommand;

        #endregion

        #region Constructors

        public DrawerPageViewModel()
        {
            DrawerItems = new ObservableCollection<RedditPost>(RedditPost.LoadItems());
        }

        #endregion

        #region Properties

        public ObservableCollection<RedditPost> DrawerItems
        {
            get { return drawerItems; }
            set { SetProperty(ref drawerItems, value); }
        }

        #endregion

        #region Commands

        public Command<RedditPost> ItemTappedCommand => itemTappedCommand ?? (itemTappedCommand = new Command<RedditPost>(data =>
        {
            data.MarkAsRead();
            MessagingCenter.Send(this, nameof(MessageNames.ShowPost), data);

        }));

        public Command<RedditPost> DismissItemCommand => dismissItemCommand ?? (dismissItemCommand = new Command<RedditPost>(data =>
        {
            var index = DrawerItems.IndexOf(data);
            if (index >= 0)
            {
                DrawerItems.RemoveAt(index);
                OnPropertyChange(nameof(DrawerItems));
            }
        }));

        public Command DismissAllCommand => dismissAllCommand ?? (dismissAllCommand = new Command(() =>
        {
            DrawerItems?.Clear();
            MessagingCenter.Send(this, nameof(MessageNames.Deselect));
        }));

        public Command PullToRefreshCommand => pullToRefreshCommand ?? (pullToRefreshCommand = new Command(() =>
        {
            DrawerItems = new ObservableCollection<RedditPost>(RedditPost.LoadItems());
        }));

        #endregion

        #region Methods

        #endregion
    }
}
