using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DevDuck
{
    public static class Duck
    {
        public static void Log(object o) { Debug.Log(o); }
        public static void LoggError(object o) { Debug.LogError(o); }
        public static float TimeMod => Time.deltaTime * ManagerGame.TIME_SCALE;
        public static float GetDistance(Vector2 pos1, Vector2 pos2)
        {
            return (pos2 - pos1).magnitude;
        }
        public static float GetDistance3D(Vector3 pos1, Vector3 pos2)
        {
            return (pos2 - pos1).magnitude;
        }

        public static void CountDown(int timer)
        {
            int hours = timer % 3600;
            int munites = timer % 60;
            int seconds = timer;
        }
    }
}
