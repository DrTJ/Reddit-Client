using System;
using System.Collections.Generic;
using RedditClient.Models;
using Xamarin.Forms;

namespace RedditClient.ViewModels
{
    public class DrawerPageViewModel : ViewModelBase
    {
        #region Fields
		
        private List<RedditPost> drawerItems;

        private Command itemTappedCommand;

        private Command dismissItemCommand;

        private Command dismissAllCommand;

        private Command pullToRefreshCommand;

        #endregion

        #region Constructors

        public DrawerPageViewModel()
        {
            DrawerItems = new List<RedditPost>
            {
                new RedditPost { PostTitle = "Post 1 Post 1 Post 1 Post 1 Post 1 Post 1", PostText="Some post text will appear here! Some post text will appear here! ", AuthorName = "Mohammad", CommentsCount = 2000, FormattedPublishDate = "18 hours ago", IsRead = false, ImagePath = "" },
                new RedditPost { PostTitle = "Post 2", PostText="Some post text will appear here! Some post text will appear here! ", AuthorName = "Mohammad", CommentsCount = 158, FormattedPublishDate = "9 hours ago", IsRead = false, ImagePath = "" },
                new RedditPost { PostTitle = "Post 3", PostText="Some post text will appear here! Some post text will appear here! ", AuthorName = "Mohammad", CommentsCount = 233, FormattedPublishDate = "4 hours ago", IsRead = true, ImagePath = "" },
                new RedditPost { PostTitle = "Post 1 Post 1 Post 1 Post 1 Post 1 Post 1", PostText="Some post text will appear here! Some post text will appear here! ", AuthorName = "Mohammad", CommentsCount = 2000, FormattedPublishDate = "18 hours ago", IsRead = false, ImagePath = "" },
                new RedditPost { PostTitle = "Post 2", PostText="Some post text will appear here! Some post text will appear here! ", AuthorName = "Mohammad", CommentsCount = 158, FormattedPublishDate = "9 hours ago", IsRead = false, ImagePath = "" },
                new RedditPost { PostTitle = "Post 3", PostText="Some post text will appear here! Some post text will appear here! ", AuthorName = "Mohammad", CommentsCount = 233, FormattedPublishDate = "4 hours ago", IsRead = true, ImagePath = "" },
                new RedditPost { PostTitle = "Post 1 Post 1 Post 1 Post 1 Post 1 Post 1", PostText="Some post text will appear here! Some post text will appear here! ", AuthorName = "Mohammad", CommentsCount = 2000, FormattedPublishDate = "18 hours ago", IsRead = false, ImagePath = "" },
                new RedditPost { PostTitle = "Post 2", PostText="Some post text will appear here! Some post text will appear here! ", AuthorName = "Mohammad", CommentsCount = 158, FormattedPublishDate = "9 hours ago", IsRead = false, ImagePath = "" },
                new RedditPost { PostTitle = "Post 3", PostText="Some post text will appear here! Some post text will appear here! ", AuthorName = "Mohammad", CommentsCount = 233, FormattedPublishDate = "4 hours ago", IsRead = true, ImagePath = "" },
                new RedditPost { PostTitle = "Post 1 Post 1 Post 1 Post 1 Post 1 Post 1", PostText="Some post text will appear here! Some post text will appear here! ", AuthorName = "Mohammad", CommentsCount = 2000, FormattedPublishDate = "18 hours ago", IsRead = false, ImagePath = "" },
                new RedditPost { PostTitle = "Post 2", PostText="Some post text will appear here! Some post text will appear here! ", AuthorName = "Mohammad", CommentsCount = 158, FormattedPublishDate = "9 hours ago", IsRead = false, ImagePath = "" },
                new RedditPost { PostTitle = "Post 3", PostText="Some post text will appear here! Some post text will appear here! ", AuthorName = "Mohammad", CommentsCount = 233, FormattedPublishDate = "4 hours ago", IsRead = true, ImagePath = "" },
                new RedditPost { PostTitle = "Post 1 Post 1 Post 1 Post 1 Post 1 Post 1", PostText="Some post text will appear here! Some post text will appear here! ", AuthorName = "Mohammad", CommentsCount = 2000, FormattedPublishDate = "18 hours ago", IsRead = false, ImagePath = "" },
                new RedditPost { PostTitle = "Post 2", PostText="Some post text will appear here! Some post text will appear here! ", AuthorName = "Mohammad", CommentsCount = 158, FormattedPublishDate = "9 hours ago", IsRead = false, ImagePath = "" },
                new RedditPost { PostTitle = "Post 3", PostText="Some post text will appear here! Some post text will appear here! ", AuthorName = "Mohammad", CommentsCount = 233, FormattedPublishDate = "4 hours ago", IsRead = true, ImagePath = "" },
                new RedditPost { PostTitle = "Post 1 Post 1 Post 1 Post 1 Post 1 Post 1", PostText="Some post text will appear here! Some post text will appear here! ", AuthorName = "Mohammad", CommentsCount = 2000, FormattedPublishDate = "18 hours ago", IsRead = false, ImagePath = "" },
                new RedditPost { PostTitle = "Post 2", PostText="Some post text will appear here! Some post text will appear here! ", AuthorName = "Mohammad", CommentsCount = 158, FormattedPublishDate = "9 hours ago", IsRead = false, ImagePath = "" },
                new RedditPost { PostTitle = "Post 3", PostText="Some post text will appear here! Some post text will appear here! ", AuthorName = "Mohammad", CommentsCount = 233, FormattedPublishDate = "4 hours ago", IsRead = true, ImagePath = "" },
                new RedditPost { PostTitle = "Post 1 Post 1 Post 1 Post 1 Post 1 Post 1", PostText="Some post text will appear here! Some post text will appear here! ", AuthorName = "Mohammad", CommentsCount = 2000, FormattedPublishDate = "18 hours ago", IsRead = false, ImagePath = "" },
                new RedditPost { PostTitle = "Post 2", PostText="Some post text will appear here! Some post text will appear here! ", AuthorName = "Mohammad", CommentsCount = 158, FormattedPublishDate = "9 hours ago", IsRead = false, ImagePath = "" },
                new RedditPost { PostTitle = "Post 3", PostText="Some post text will appear here! Some post text will appear here! ", AuthorName = "Mohammad", CommentsCount = 233, FormattedPublishDate = "4 hours ago", IsRead = true, ImagePath = "" },
                new RedditPost { PostTitle = "Post 1 Post 1 Post 1 Post 1 Post 1 Post 1", PostText="Some post text will appear here! Some post text will appear here! ", AuthorName = "Mohammad", CommentsCount = 2000, FormattedPublishDate = "18 hours ago", IsRead = false, ImagePath = "" },
                new RedditPost { PostTitle = "Post 2", PostText="Some post text will appear here! Some post text will appear here! ", AuthorName = "Mohammad", CommentsCount = 158, FormattedPublishDate = "9 hours ago", IsRead = false, ImagePath = "" },
                new RedditPost { PostTitle = "Post 3", PostText="Some post text will appear here! Some post text will appear here! ", AuthorName = "Mohammad", CommentsCount = 233, FormattedPublishDate = "4 hours ago", IsRead = true, ImagePath = "" },
                new RedditPost { PostTitle = "Post 1 Post 1 Post 1 Post 1 Post 1 Post 1", PostText="Some post text will appear here! Some post text will appear here! ", AuthorName = "Mohammad", CommentsCount = 2000, FormattedPublishDate = "18 hours ago", IsRead = false, ImagePath = "" },
                new RedditPost { PostTitle = "Post 2", PostText="Some post text will appear here! Some post text will appear here! ", AuthorName = "Mohammad", CommentsCount = 158, FormattedPublishDate = "9 hours ago", IsRead = false, ImagePath = "" },
                new RedditPost { PostTitle = "Post 3", PostText="Some post text will appear here! Some post text will appear here! ", AuthorName = "Mohammad", CommentsCount = 233, FormattedPublishDate = "4 hours ago", IsRead = true, ImagePath = "" },
                new RedditPost { PostTitle = "Post 1 Post 1 Post 1 Post 1 Post 1 Post 1", PostText="Some post text will appear here! Some post text will appear here! ", AuthorName = "Mohammad", CommentsCount = 2000, FormattedPublishDate = "18 hours ago", IsRead = false, ImagePath = "" },
                new RedditPost { PostTitle = "Post 2", PostText="Some post text will appear here! Some post text will appear here! ", AuthorName = "Mohammad", CommentsCount = 158, FormattedPublishDate = "9 hours ago", IsRead = false, ImagePath = "" },
                new RedditPost { PostTitle = "Post 3", PostText="Some post text will appear here! Some post text will appear here! ", AuthorName = "Mohammad", CommentsCount = 233, FormattedPublishDate = "4 hours ago", IsRead = true, ImagePath = "" },
                new RedditPost { PostTitle = "Post 1 Post 1 Post 1 Post 1 Post 1 Post 1", PostText="Some post text will appear here! Some post text will appear here! ", AuthorName = "Mohammad", CommentsCount = 2000, FormattedPublishDate = "18 hours ago", IsRead = false, ImagePath = "" },
                new RedditPost { PostTitle = "Post 2", PostText="Some post text will appear here! Some post text will appear here! ", AuthorName = "Mohammad", CommentsCount = 158, FormattedPublishDate = "9 hours ago", IsRead = false, ImagePath = "" },
                new RedditPost { PostTitle = "Post 3", PostText="Some post text will appear here! Some post text will appear here! ", AuthorName = "Mohammad", CommentsCount = 233, FormattedPublishDate = "4 hours ago", IsRead = true, ImagePath = "" },
            };
        }

        #endregion

        #region Properties

        public List<RedditPost> DrawerItems
        {
            get { return drawerItems; }
            set { SetProperty(ref drawerItems, value); }
        }

        #endregion

        #region Commands

        public Command ItemTappedCommand => itemTappedCommand ?? (itemTappedCommand = new Command(data =>
        {
            MessagingCenter.Send<DrawerPageViewModel, RedditPost>(this, "ShowPost", data as RedditPost);
        }));

        public Command DismissItemCommand => dismissItemCommand ?? (dismissItemCommand = new Command(data =>
        {
        }));

        public Command DismissAllCommand => dismissAllCommand ?? (dismissAllCommand = new Command(() =>
        {
        }));

        public Command PullToRefreshCommand => pullToRefreshCommand ?? (pullToRefreshCommand = new Command(() =>
        {

        }));

        #endregion

        #region Methods

        #endregion
    }
}
