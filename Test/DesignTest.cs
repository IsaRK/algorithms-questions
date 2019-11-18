using Algorithms;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace Test
{
    public class DesignTest
    {
        [Fact]
        public void TwitterTest()
        {
            Twitter twitter = new Twitter();

            // User 1 posts a new tweet (id = 5).
            twitter.PostTweet(1, 5);

            // User 1's news feed should return a list with 1 tweet id -> [5].
            Assert.Equal(new List<int> { 5 }, twitter.GetNewsFeed(1));

            // User 1 follows user 2.
            twitter.Follow(1, 2);

            // User 2 posts a new tweet (id = 6).
            twitter.PostTweet(2, 6);

            // User 1's news feed should return a list with 2 tweet ids -> [6, 5].
            // Tweet id 6 should precede tweet id 5 because it is posted after tweet id 5.
            Assert.Equal(new List<int> { 6, 5 }, twitter.GetNewsFeed(1));

            // User 1 unfollows user 2.
            twitter.Unfollow(1, 2);

            // User 1's news feed should return a list with 1 tweet id -> [5],
            // since user 1 is no longer following user 2.
            Assert.Equal(new List<int> { 5 }, twitter.GetNewsFeed(1));
        }

        [Fact]
        public void TwitterTest2()
        {
            Twitter twitter = new Twitter();
            twitter.PostTweet(1, 1);
            Assert.Equal(new List<int> { 1 }, twitter.GetNewsFeed(1));
            twitter.Follow(2, 1);
            Assert.Equal(new List<int> { 1 }, twitter.GetNewsFeed(2));
            twitter.Unfollow(2, 1);
            Assert.Equal(new List<int>(), twitter.GetNewsFeed(2));
        }

        [Fact]
        public void TwitterTest3()
        {
            Twitter twitter = new Twitter();
            twitter.PostTweet(1, 5);
            twitter.Follow(1, 1);
            Assert.Equal(new List<int> { 5 }, twitter.GetNewsFeed(1));
        }

        [Fact]
        public void TwitterTest4()
        {
            Twitter twitter = new Twitter();
            twitter.PostTweet(2, 5);
            twitter.Follow(1, 2);
            twitter.Follow(1, 2);
            Assert.Equal(new List<int> { 5 }, twitter.GetNewsFeed(1));
        }

        [Fact]
        public void TwitterTest5()
        {
            Twitter twitter = new Twitter();
            twitter.PostTweet(1, 5);
            twitter.PostTweet(2, 3);
            twitter.PostTweet(1, 101);
            twitter.PostTweet(2, 13);
            twitter.PostTweet(2, 10);
            twitter.PostTweet(1, 2);
            twitter.PostTweet(1, 94);
            twitter.PostTweet(2, 505);
            twitter.PostTweet(1, 333);
            twitter.PostTweet(2, 22);
            twitter.PostTweet(1, 11);
            twitter.PostTweet(1, 205);
            twitter.PostTweet(2, 203);
            twitter.PostTweet(1, 201);
            twitter.PostTweet(2, 213);
            twitter.PostTweet(1, 200);
            twitter.PostTweet(2, 202);
            twitter.PostTweet(1, 204);
            twitter.PostTweet(2, 208);
            twitter.PostTweet(2, 233);
            twitter.PostTweet(1, 222);
            twitter.PostTweet(2, 211);
            Assert.Equal(new List<int> { 222, 204, 200, 201, 205, 11, 333, 94, 2, 101 }, twitter.GetNewsFeed(1));
            twitter.Follow(1, 2);
            Assert.Equal(new List<int> { 211, 222, 233, 208, 204, 202, 200, 213, 201, 203 }, twitter.GetNewsFeed(1));
            twitter.Unfollow(1, 2);
            Assert.Equal(new List<int> { 222, 204, 200, 201, 205, 11, 333, 94, 2, 101 }, twitter.GetNewsFeed(1));
        }

        [Fact]
        public void MinStackTest()
        {
            MinStack minStack = new MinStack();
            minStack.Push(-2);
            minStack.Push(0);
            minStack.Push(-3);
            Assert.Equal(-3, minStack.GetMin());
            minStack.Pop();
            Assert.Equal(0, minStack.Top());
            Assert.Equal(-2, minStack.GetMin());
        }

        [Fact]
        public void RandomizedSetTest()
        {
            RandomizedSet randomSet = new RandomizedSet();
            Assert.True(randomSet.Insert(1));
            Assert.False(randomSet.Remove(2));
            Assert.True(randomSet.Insert(2));
            randomSet.GetRandom();
            Assert.True(randomSet.Remove(1));
            Assert.False(randomSet.Insert(2));
            Assert.Equal(2, randomSet.GetRandom());
        }

        [Fact]
        public void RandomizedSetTest2()
        {
            RandomizedSet randomSet = new RandomizedSet();
            Assert.True(randomSet.Insert(0));
            Assert.True(randomSet.Insert(1));
            Assert.True(randomSet.Remove(0));
            Assert.True(randomSet.Insert(2));
            Assert.True(randomSet.Remove(1));
            Assert.Equal(2, randomSet.GetRandom());
        }

        [Fact]
        public void RandomizedSetTest3()
        {
            RandomizedSet randomSet = new RandomizedSet();
            Assert.False(randomSet.Remove(0));
            Assert.False(randomSet.Remove(0));
            Assert.True(randomSet.Insert(0));
            Assert.Equal(0, randomSet.GetRandom());
            Assert.True(randomSet.Remove(0));
            Assert.True(randomSet.Insert(0));
        }

        [Fact]
        public void RandomizedSetTest4()
        {
            RandomizedSet randomSet = new RandomizedSet();
            Assert.True(randomSet.Insert(3));
            Assert.False(randomSet.Insert(3));
            Assert.Equal(3, randomSet.GetRandom());
            Assert.Equal(3, randomSet.GetRandom());
            Assert.True(randomSet.Insert(1));
            Assert.True(randomSet.Remove(3));
            Assert.Equal(1, randomSet.GetRandom());
            Assert.Equal(1, randomSet.GetRandom());
            Assert.True(randomSet.Insert(0));
            Assert.True(randomSet.Remove(0));
        }
    }
}
