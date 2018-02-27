using System;
using System.Collections.Generic;
using RedditClient.ViewModels;

namespace RedditClient.Models
{
    public class RedditPost : ObservableModel
    {
        #region Fields

        private string postTitle;

        private string postText;

        private bool isRead;

        private string authorName;

        private string formattedPublishDate;

        private int commentsCount;

		private string imagePath;

        #endregion

        #region Constructors

        #endregion

        #region Properties

        public string PostTitle
        {
            get { return postTitle; }
            set { SetProperty(ref postTitle, value); }
        }

        public string PostText
        {
            get { return postText; }
            set { SetProperty(ref postText, value); }
        }

        public bool IsRead
        {
            get { return isRead; }
            set { SetProperty(ref isRead, value); }
        }

        public string AuthorName
        {
            get { return authorName; }
            set { SetProperty(ref authorName, value); }
        }

        public string FormattedPublishDate
        {
            get { return formattedPublishDate; }
            set { SetProperty(ref formattedPublishDate, value); }
        }

        public int CommentsCount
        {
            get { return commentsCount; }
            set { SetProperty(ref commentsCount, value); }
        }

        public string ImagePath
        {
            get { return imagePath; }
            set { SetProperty(ref imagePath, value); }
        }

        #endregion
   
        #region Methods

        public void MarkAsRead()
        {
            IsRead = true;
        }

        public static List<RedditPost> LoadItems()
        {
            var result = new List<RedditPost>();

            for (int i = 0; i < 50; i++)
            {
                result.Add(new RedditPost
                {
                    PostTitle = $"Post {i + 1}",
                    PostText = "Some post text will appear here! Some post text will appear here! ",
                    AuthorName = "Mohammad",
                    CommentsCount = 2000 + i,
                    FormattedPublishDate = $"{i + 1} hours ago",
                    IsRead = i % 2 == 0,
                    ImagePath = ""
                });
            }

            return result;
        }

        #endregion
    }
}
