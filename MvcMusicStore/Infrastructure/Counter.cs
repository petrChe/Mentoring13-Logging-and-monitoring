using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Web;

namespace MvcMusicStore.Infrastructure
{
    public class Counter
    {
        public static PerformanceCounter logInCounter;
        public static PerformanceCounter logOutCounter;
        public static PerformanceCounter homePageVisitCounter;

        static Counter()
        {
            CreateCategory();

            logInCounter = new PerformanceCounter("MentoringCategory", "LogInCounter", false);
            logOutCounter = new PerformanceCounter("MentoringCategory", "LogOutCounter", false);
            homePageVisitCounter = new PerformanceCounter("MentoringCategory", "HomePageVisitCounter", false);

            logInCounter.RawValue = 0;
            logOutCounter.RawValue = 0;
            homePageVisitCounter.RawValue = 0;
        }

        public static void CreateCategory()
        { 
            if(!PerformanceCounterCategory.Exists("MentoringCategory"))
            {
                var counterCollection = new CounterCreationDataCollection();

                //log in counter
                var logInCounter = new CounterCreationData();
                logInCounter.CounterType = PerformanceCounterType.NumberOfItems32;
                logInCounter.CounterName = "LogInCounter";
                counterCollection.Add(logInCounter);

                var logOutCounter = new CounterCreationData();
                logOutCounter.CounterType = PerformanceCounterType.NumberOfItems32;
                logOutCounter.CounterName = "LogOutCounter";
                counterCollection.Add(logOutCounter);

                var homePageVisitCounter = new CounterCreationData();
                homePageVisitCounter.CounterType = PerformanceCounterType.NumberOfItems32;
                homePageVisitCounter.CounterName = "HomePageVisitCounter";
                counterCollection.Add(homePageVisitCounter);

                PerformanceCounterCategory.Create("MentoringCategory", "MentoringCategory", PerformanceCounterCategoryType.SingleInstance, counterCollection);
                
            }
        }
    }
}