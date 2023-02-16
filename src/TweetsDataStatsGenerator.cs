using System;
using System.Linq;

/**
 * Generates various statistics about the tweets data set returned by the given TweetsApiService instance.
 */
namespace CodeScreen.Assessments.TweetsApi
{
    class TweetDataStatsGenerator
    {
        private readonly TweetsApiService TweetsApiService;

        public TweetDataStatsGenerator(TweetsApiService tweetsApiService)
        {
            TweetsApiService = tweetsApiService;
        }

        /**
         * Retrieves the highest number of tweets that were created on any given day by the given user.
         *
         * A day's time period here is defined from 00:00:00 to 23:59:59
         * If there are no tweets for the given user, this method should return 0.
         *
         * @param userName the name of the user
         * @return the highest number of tweets that were created on a any given day by the given user
        */
        public int GetMostTweetsForAnyDay(string userName)
        {
            //TODO Implement
            var tweets = TweetsApiService.GetTweets(userName);
            if (tweets != null)
            {
                return tweets.GroupBy(
                    t => t.CreatedAt.ToShortDateString(), 
                    t => t.Id, 
                    (key, g) => new { Day = key, Count = g.Count() }
                    ).Max(d => d.Count);
            }

            return 0;
        }

        /**
         * Finds the ID of longest tweet for the given user.
         *
         * You can assume there will only be one tweet that is the longest.
         * If there are no tweets for the given user, this method should return null.
         *
         * @param userName the name of the user
         * @return the ID of longest tweet for the given user
        */
        public string GetLongestTweet(string userName)
        {
            //TODO Implement
            var tweets = TweetsApiService.GetTweets(userName);

            return tweets?.OrderByDescending(t => t.Text.Length)?.First()?.Id;
        }

        /**
         * Retrieves the most number of days between tweets by the given user, wrapped as an OptionalInt.
         *
         * This should always be rounded down to the complete number of days, i.e. if the time is 12 days & 3 hours, this
         * method should return 12.
         * If there are no tweets for the given user, this method should return 0.
         *
         * @param userName the name of the user
         * @return the most number of days between tweets by the given user
        */
        public int FindMostDaysBetweenTweets(string userName)
        {
            //TODO Implement
            var tweets = TweetsApiService.GetTweets(userName);
            tweets = tweets.OrderBy(t => t.CreatedAt).ToList();
            var mostDays = 0;

            for (int i = 1; i < tweets.Count(); i++)
            {
                var preTweet = tweets[i - 1];
                var tweet = tweets[i];
                var days = (tweet.CreatedAt - preTweet.CreatedAt).Days;
                if (days > mostDays)
                {
                    mostDays = days;
                }
            }

            return mostDays;
        }

        /**
         * Retrieves the most popular hash tag tweeted by the given user.
         *
         * Note that the string returned by this method should include the hashtag itself.
         * For example, if the most popular hash tag is "#Java", this method should return "#Java".
         * If there are no tweets for the given user, this method should return null.
         *
         * @param userName the name of the user
         * @return the most popular hash tag tweeted by the given user.
        */
        public string GetMostPopularHashTag(string userName)
        {
            //TODO Implement
            var tweets = TweetsApiService.GetTweets(userName);

            return tweets.Select(t => t.Text.Split(' ').Last())
                        .Where(w => w[0] == '#')
                        .GroupBy(h => h, h => h, (key, g) => new { HashTag = key, Count = g.Count() })
                        .OrderByDescending(g => g.Count)
                        .First().HashTag;
        }

    }
}
