using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GFGTests
{
    /**
         * Your Twitter object will be instantiated and called as such:
         * Twitter obj = new Twitter();
         * obj.PostTweet(userId,tweetId);
         * IList<int> param_2 = obj.GetNewsFeed(userId);
         * obj.Follow(followerId,followeeId);
         * obj.Unfollow(followerId,followeeId);
         */

    public class Twitter
    {
        public class DescComparer<T> : IComparer<T>
        {
            public int Compare(T x, T y)
            {
                return Comparer<T>.Default.Compare(y, x);
            }
        }

        public struct Tweet : IComparable
        {
            public readonly int Id;
            public readonly DateTime CreationDate;

            public Tweet(int id)
            {
                Id = id;
                CreationDate = DateTime.Now;
            }

            public int CompareTo(object obj)
            {
                return CreationDate.CompareTo(obj);
            }
        }

        private Dictionary<int, List<Tweet>> Tweets { get; set; }
        private Dictionary<int, HashSet<int>> Followers { get; set; } //Key = user, Value = followees
        public const int MaxNewsFeed = 10;

        /** Initialize your data structure here. */
        public Twitter()
        {
            Tweets = new Dictionary<int, List<Tweet>>();
            Followers = new Dictionary<int, HashSet<int>>();
        }

        /** Compose a new tweet. */
        public void PostTweet(int userId, int tweetId)
        {
            if (Tweets.ContainsKey(userId))
            {
                Tweets[userId].Insert(0, new Tweet(tweetId));
            }
            else
            {
                Tweets.Add(userId, new List<Tweet> { new Tweet(tweetId)});
            }
        }

        /** Retrieve the 10 most recent tweet ids in the user's news feed. Each item in the news feed must be posted by users who the user followed or by the user herself. Tweets must be ordered from most recent to least recent. */
        public IList<int> GetNewsFeed(int userId)
        {
            var allTweets = new SortedList<DateTime, Tweet>(MaxNewsFeed, new DescComparer<DateTime>());

            if (Tweets.ContainsKey(userId))
            {
                foreach (var tweet in Tweets[userId].Take(MaxNewsFeed))
                {
                    allTweets.Add(tweet.CreationDate, tweet);
                }
            } 

            if (Followers.ContainsKey(userId))
            {
                foreach (var follower in Followers[userId])
                {
                    if (Tweets.ContainsKey(follower))
                    {
                        foreach (var tweet in Tweets[follower].Take(MaxNewsFeed))
                        {
                            allTweets.Add(tweet.CreationDate, tweet);
                        }
                    }
                } 
            }

            return allTweets.Select(kvp => kvp.Value.Id).Take(MaxNewsFeed).ToList();
        }

        /** Follower follows a followee. If the operation is invalid, it should be a no-op. */
        public void Follow(int followerId, int followeeId)
        {
            if (followerId == followeeId) return;

            if (Followers.ContainsKey(followerId))
            {
                Followers[followerId].Add(followeeId);
            }
            else
            {
                Followers.Add(followerId, new HashSet<int> { followeeId });
            }
        }

        /** Follower unfollows a followee. If the operation is invalid, it should be a no-op. */
        public void Unfollow(int followerId, int followeeId)
        {
            if (Followers.ContainsKey(followerId))
            {
                Followers[followerId].Remove(followeeId);
            }
        }
    }
}

        
