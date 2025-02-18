using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq.Expressions;
using UnityEngine;

namespace DevDuck
{

    public enum EventAction
    {
        EVENT_POPUP_SHOW,
        EVENT_POPUP_CLOSE,

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
