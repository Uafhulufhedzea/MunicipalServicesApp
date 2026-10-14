using System;
using System.Collections.Generic;
using System.Linq;

namespace MunicipalServicesApp
{
   
    public class EventAnnouncement
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Category { get; set; }
        public DateTime EventDate { get; set; }
        public string Description { get; set; }

        public EventAnnouncement(int id, string title, string category, DateTime date, string desc)
        {
            Id = id;
            Title = title;
            Category = category;
            EventDate = date.Date; 
            Description = desc;
        }
    }

  
    public static class EventDataStore
    {
        public static SortedDictionary<DateTime, List<EventAnnouncement>> EventsByDate { get; private set; }

       
        public static HashSet<string> UniqueCategories { get; private set; }

     
        public static Queue<string> UserSearchHistory { get; private set; }

        private static Dictionary<string, int> CategoryPreferenceWeights;
        private static Dictionary<string, int> KeywordPreferenceWeights;
        private static Dictionary<DateTime, int> DatePreferenceWeights;

        static EventDataStore()
        {
            EventsByDate = new SortedDictionary<DateTime, List<EventAnnouncement>>();
            UniqueCategories = new HashSet<string>(StringComparer.OrdinalIgnoreCase);
            UserSearchHistory = new Queue<string>();
            CategoryPreferenceWeights = new Dictionary<string, int>(StringComparer.OrdinalIgnoreCase);
            KeywordPreferenceWeights = new Dictionary<string, int>(StringComparer.OrdinalIgnoreCase);
            DatePreferenceWeights = new Dictionary<DateTime, int>();

            SeedSampleData();
        }

    
        private static void SeedSampleData()
        {
            var sampleEvents = new List<EventAnnouncement>
            {
                new EventAnnouncement(1, "Ward 42 Town Hall Meeting", "Governance", DateTime.Today.AddDays(2), "Discussing local infrastructure budgets and service delivery improvements."),
                new EventAnnouncement(2, "Substation Alpha Maintenance Downtime", "Utilities", DateTime.Today.AddDays(1), "Scheduled power grid maintenance. Expect temporary outages."),
                new EventAnnouncement(3, "Community Cleanup Campaign", "Sanitation", DateTime.Today.AddDays(5), "Volunteers gathering at Central Park to clean up illegal dumping sites."),
                new EventAnnouncement(4, "Water Pipe Infrastructure Upgrade", "Utilities", DateTime.Today.AddDays(3), "Replacing old municipal main lines to fix recurring pressure drops."),
                new EventAnnouncement(5, "Pretoria Cultural Arts Festival", "Culture", DateTime.Today.AddDays(7), "Celebrating local heritage, food stalls, and independent crafts."),
                new EventAnnouncement(6, "Public Health Emergency Briefing", "Governance", DateTime.Today, "Urgent safety briefing from health inspectors regarding municipal water safety compliance.")
            };

            foreach (var evt in sampleEvents)
            {
                AddEvent(evt);
            }
        }

        public static void AddEvent(EventAnnouncement newEvent)
        {
           
            if (!EventsByDate.ContainsKey(newEvent.EventDate))
            {
                EventsByDate[newEvent.EventDate] = new List<EventAnnouncement>();
            }
            EventsByDate[newEvent.EventDate].Add(newEvent);

       
            UniqueCategories.Add(newEvent.Category);
        }

        
        public static void RecordUserSearch(string searchKeyword, string categoryFilter, DateTime? dateFilter)
        {
            if (!string.IsNullOrWhiteSpace(searchKeyword))
            {
                string normalizedKeyword = searchKeyword.Trim();
                UserSearchHistory.Enqueue(normalizedKeyword);
                if (KeywordPreferenceWeights.ContainsKey(normalizedKeyword))
                    KeywordPreferenceWeights[normalizedKeyword]++;
                else
                    KeywordPreferenceWeights[normalizedKeyword] = 1;

                if (UserSearchHistory.Count > 5)
                {
                    UserSearchHistory.Dequeue();
                }
            }

            if (!string.IsNullOrWhiteSpace(categoryFilter) && !categoryFilter.Equals("All Categories", StringComparison.OrdinalIgnoreCase))
            {
                if (CategoryPreferenceWeights.ContainsKey(categoryFilter))
                    CategoryPreferenceWeights[categoryFilter]++;
                else
                    CategoryPreferenceWeights[categoryFilter] = 1;
            }

            if (dateFilter.HasValue)
            {
                DateTime date = dateFilter.Value.Date;
                if (DatePreferenceWeights.ContainsKey(date))
                    DatePreferenceWeights[date]++;
                else
                    DatePreferenceWeights[date] = 1;
            }
        }


        public static List<EventAnnouncement> GetAlgorithmicRecommendations()
        {
            List<EventAnnouncement> allEvents = EventsByDate.Values
                .SelectMany(list => list)
                .ToList();

            if (allEvents.Count == 0)
                return new List<EventAnnouncement>();

            if (CategoryPreferenceWeights.Count == 0 && KeywordPreferenceWeights.Count == 0 && DatePreferenceWeights.Count == 0)
                return allEvents.Take(3).ToList();

            return allEvents
                .Select(evt => new
                {
                    Event = evt,
                    Score = CalculateRecommendationScore(evt)
                })
                .OrderByDescending(item => item.Score)
                .ThenBy(item => item.Event.EventDate)
                .ThenBy(item => item.Event.Title)
                .Take(3)
                .Select(item => item.Event)
                .ToList();
        }

        private static int CalculateRecommendationScore(EventAnnouncement eventItem)
        {
            int score = 0;

            int categoryWeight;
            if (CategoryPreferenceWeights.TryGetValue(eventItem.Category, out categoryWeight))
                score += categoryWeight * 5;

            foreach (var keywordPreference in KeywordPreferenceWeights)
            {
                bool titleMatch = eventItem.Title.IndexOf(keywordPreference.Key, StringComparison.OrdinalIgnoreCase) >= 0;
                bool descriptionMatch = eventItem.Description.IndexOf(keywordPreference.Key, StringComparison.OrdinalIgnoreCase) >= 0;

                if (titleMatch)
                    score += keywordPreference.Value * 6;
                else if (descriptionMatch)
                    score += keywordPreference.Value * 3;
            }

            int dateWeight;
            if (DatePreferenceWeights.TryGetValue(eventItem.EventDate.Date, out dateWeight))
                score += dateWeight * 4;

            return score;
        }

       
        public static List<EventAnnouncement> QueryEvents(string category, DateTime? dateFilter, string keyword)
        {
            var results = new List<EventAnnouncement>();


            if (dateFilter.HasValue)
            {
                DateTime targetedKey = dateFilter.Value.Date;
                if (EventsByDate.ContainsKey(targetedKey))
                {
                    results.AddRange(EventsByDate[targetedKey]);
                }
            }
            else
            {
               
                results.AddRange(EventsByDate.Values.SelectMany(list => list));
            }

           
            return results.Where(e =>
                (string.IsNullOrWhiteSpace(category) || category.Equals("All Categories", StringComparison.OrdinalIgnoreCase) || e.Category.Equals(category, StringComparison.OrdinalIgnoreCase)) &&
                (string.IsNullOrWhiteSpace(keyword) || e.Title.IndexOf(keyword, StringComparison.OrdinalIgnoreCase) >= 0 || e.Description.IndexOf(keyword, StringComparison.OrdinalIgnoreCase) >= 0)
            ).ToList();
        }
    }
}
