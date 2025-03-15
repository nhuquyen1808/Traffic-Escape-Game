using System;
using System.Collections.Generic;
using UnityEngine;

namespace DevDuck
{

    public enum EventAction
    {
        /* EVENT_POPUP_SHOW,
         EVENT_HITTARGET_MINIGAMEHITLIPSTICK,
         EVENT_POPUP_SHOW_WIN_DONE,
         EVENT_POPUP_SHOW_LOSE_DONE,
         // Game6
         EVENT_GET_GREEN,
         EVENT_GET_RED,
         // Game 4
         EVENT_CAMERA_MOVE,
         EVENT_GET_SCORE,
         EVENT_BOT_YELLOW_GET_SCORE,
         EVENT_BOT_RED_GET_SCORE,
         // Game 1
         EVENT_DROPBUTTON_CLICKED,
         EVENT_PLAYER_MOVE_DONE,
         //Game 20
         EVENT_PLAYER_BEGINSELECT,
         EVENT_PLAYER_ENDSELECT,*/
         EVENT_CAR_DONE_ACTION
    }

    public class Observer
    {
        public static Dictionary<string, List<Action<object>>> Listeners = new Dictionary<string, List<Action<object>>> { };

        public static void AddObserver(EventAction act, Action<object> callback)
        {
            if (!Listeners.ContainsKey(act.ToString()))
            {
                Listeners.Add(act.ToString(), new List<Action<object>>());
            }
            Listeners[act.ToString()].Add(callback);
        }

        public static void RemoveObserver(EventAction act, Action<object> callback)
        {
            if (!Listeners.ContainsKey(act.ToString()))
                return;
            Listeners[act.ToString()].Remove(callback);
        }

        public static void Notify(EventAction act, object datas)
        {
            if (!Listeners.ContainsKey(act.ToString()))
                return;

            foreach (var listener in Listeners[act.ToString()])
            {
                try
                {
                    listener?.Invoke(datas);
                }
                catch (Exception e)
                {
                    Debug.LogError("Error on invoke " + e);
                }
            }
        }
    }
}
