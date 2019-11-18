using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Algorithms
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

    public class MinStack
    {
        /**
     * Your MinStack object will be instantiated and called as such:
     * MinStack obj = new MinStack();
     * obj.Push(x);
     * obj.Pop();
     * int param_3 = obj.Top();
     * int param_4 = obj.GetMin();
     */
        private Stack<int[]> _stack;
        private int _min;

        /** initialize your data structure here. */
        public MinStack()
        {
            _stack = new Stack<int[]>();
            _min = int.MaxValue;
        }

        public void Push(int x)
        {
            if (x < _min)
            {
                _min = x;
            }

            _stack.Push(new int[] { x, _min}); 
        }

        public void Pop()
        {
            if (_stack.Count > 0)
            {
                _stack.Pop();
            }

            if (_stack.Count > 0)
            {
                _min = _stack.Peek()[1];
            }
            else
            {
                _min = int.MaxValue;
            }
                
        }

        public int Top()
        {
            return _stack.Peek()[0];
        }

        public int GetMin()
        {
            return _min;
        }
    }

    /**
     * Your RandomizedSet object will be instantiated and called as such:
     * RandomizedSet obj = new RandomizedSet();
     * bool param_1 = obj.Insert(val);
     * bool param_2 = obj.Remove(val);
     * int param_3 = obj.GetRandom();
     */

    public class RandomizedSet
    {
        private List<int> set;
        private Dictionary<int, int> _valuesToIndex;


        /** Initialize your data structure here. */
        public RandomizedSet()
        {
            set = new List<int>();
            _valuesToIndex = new Dictionary<int, int>();
        }

        /** Inserts a value to the set. Returns true if the set did not already contain the specified element. */
        public bool Insert(int val)
        {
            if (_valuesToIndex.ContainsKey(val))
            {
                return false;
            }

            set.Add(val);
            _valuesToIndex.Add(val, set.Count - 1);
            return true;
        }

        /** Removes a value from the set. Returns true if the set contained the specified element. */
        public bool Remove(int val)
        {
            if (!_valuesToIndex.ContainsKey(val))
            {
                return false;
            }

            if (set.Count == 1)
            {
                _valuesToIndex.Clear();
                set.Clear();
                return true;
            }

            var indexToSwap = _valuesToIndex[val];

            if (indexToSwap == set.Count - 1)
            {
                set.RemoveAt(set.Count - 1);
            }
            else
            {
                set[indexToSwap] = set[set.Count - 1];
                set.RemoveAt(set.Count - 1);
                _valuesToIndex[set[indexToSwap]] = indexToSwap;
            }

            _valuesToIndex.Remove(val);
            return true;
        }

        /** Get a random element from the set. */
        public int GetRandom()
        {
            var rand = new Random();
            return set[rand.Next(0, set.Count - 1)];
        }
    }
}


