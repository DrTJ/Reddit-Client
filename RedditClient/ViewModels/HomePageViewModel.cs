using System;
using RedditClient.Models;
using Xamarin.Forms;

namespace RedditClient.ViewModels
{
    public class HomePageViewModel : ViewModelBase
    {
        #region Fields

        private RedditPost currentPost;

        #endregion

        #region Constructors

        public HomePageViewModel()
        {
            CurrentPost = null;
            MessagingCenter.Subscribe<DrawerPageViewModel, RedditPost>(this, "ShowPost", LoadPost);
        }

        #endregion

        #region Properties

        public RedditPost CurrentPost
        {
            get { return currentPost; }
            set { SetProperty(ref currentPost, value); }
        }

        #endregion

        #region Commands

        #endregion

        #region Methods

        private void LoadPost(object sender, RedditPost post)
        {
            CurrentPost = post;
        }

        #endregion
    }
}
