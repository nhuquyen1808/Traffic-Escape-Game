using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace DevDuck
{
    public static class Duck
    {
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
        public static int RandomIdHasExclusions(List<int> _list)
        {
            int o = _list[Random.Range(0, _list.Count)];
            _list.Remove(o);
            return o;
        }

        public static int GetRandom(int min, int max)
        {
            return Random.Range(min, max);
        }

        public static void PlayParticle(ParticleSystem particleSystem)
        {
            if(particleSystem == null) return;
            if (!particleSystem.isPlaying)
            {
                particleSystem.Stop();
                particleSystem.Play();
            }
            else
            {
                particleSystem.Play();
            }
        }
        public static bool isListAContainListB(List<object> list1, List<object> list2)
        {
                return list1.All(item => list2.Contains(item));
        }
        
        public static List<int> GenerateDerangement(List<int> list)
        {
            int count = list.Count;
            List<int> result = new List<int>(list);
            List<int> available = new List<int>(list);

            System.Random rand = new System.Random();

            for (int i = 0; i < count; i++)
            {
                // Lọc ra các phần tử khác vị trí ban đầu
                List<int> choices = available.FindAll(x => x != list[i]);
                // Nếu chỉ còn 1 phần tử và nó trùng vị trí ban đầu, cần hoán đổi
                if (choices.Count == 0)
                {
                    // Hoán đổi với phần tử cuối cùng
                    int lastIndex = i - 1;
                    (result[lastIndex], result[i]) = (result[i], result[lastIndex]);
                    break;
                }
                // Chọn ngẫu nhiên từ các lựa chọn hợp lệ
                int choice = choices[rand.Next(choices.Count)];
                result[i] = choice;
                available.Remove(choice);
            }
            return result;
        }
        
        
    }
}
