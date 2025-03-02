using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.TextCore.Text;

namespace DevDuck
{
    public class TestRocket : MonoBehaviour
    {
        public int size = 5; // Kích thước ma trận (VD: 5x5)
        public GameObject o;
        void Start()
        {
            List<Vector2> spiralPath = GenerateSpiralPath(size);

            // In kết quả ra Console
            for (int i = 0; i < spiralPath.Count; i++)
            {
                {
                    GameObject go = Instantiate(o, new Vector3(0, 20, 0), Quaternion.identity);
                    go.transform.DOMove(spiralPath[i], 0.5f).SetDelay(i * 0.2f);
                }
            }

            List<Vector2> GenerateSpiralPath(int n)
            {
                List<Vector2> path = new List<Vector2>();

                int x = 0, y = 0; // Bắt đầu từ tâm
                int dx = 1, dy = 0; // Hướng đi ban đầu: phải
                int steps = 1; // Số bước cần đi trong mỗi hướng
                int stepCounter = 0, turnCounter = 0;

                for (int i = 0; i < n * 7; i++)
                {
                    path.Add(new Vector2(x, y)); // Lưu tọa độ

                    x += dx; // Di chuyển
                    y += dy;
                    stepCounter++;

                    if (stepCounter == steps) // Nếu đã đi hết bước trong 1 hướng
                    {
                        stepCounter = 0; // Reset bước
                        turnCounter++; // Tăng số lần đổi hướng

                        // Đổi hướng theo quy luật (x, y) → (-y, x)
                        int temp = dx;
                        dx = -dy;
                        dy = temp;

                        if (turnCounter % 2 == 0) steps++; // Tăng số bước sau mỗi 2 lần xoay
                    }
                }
                return path;
            }
        }
    }
}
