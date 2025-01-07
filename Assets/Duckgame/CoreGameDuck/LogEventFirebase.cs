using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DevDuck
{
    public class LogEventFirebase : MonoBehaviour
    {
        // public static void LogEvent(string name)
        // {
        //     if (FirebaseReady) FirebaseAnalytics.LogEvent(name);
        // }
        // public static void LogEvent(string name, string param = "", int value = 0)
        // {
        //     if (FirebaseReady)
        //     {
        //         Firebase.Analytics.Parameter[] para = new Firebase.Analytics.Parameter[1];
        //         para[0] = new Firebase.Analytics.Parameter(param, value.ToString(5));
        //         FirebaseAnalytics.LogEvent(name, para);
        //     }
        // }
        // public static void LogEvent(string name, string param = "", string value = "")
        // {
        //     if (FirebaseReady)
        //     {
        //         Firebase.Analytics.Parameter[] para = new Firebase.Analytics.Parameter[1];
        //         para[0] = new Firebase.Analytics.Parameter(param, value == "" ? "null" : value);
        //         FirebaseAnalytics.LogEvent(name, para);
        //     }
        // }
        // public static void LogEvent(string name, Parameter[] arrPara)
        // {
        //     if (FirebaseReady) FirebaseAnalytics.LogEvent(name, arrPara);
        // }



        //EXAPLE
        //LogEvent("status_level_1_start");
        //LogEvent("status_level_1_end");
        //LogEvent("time_level_1_"+ (54/20));
        //LogEvent("daily_reward_6");
    }
}
