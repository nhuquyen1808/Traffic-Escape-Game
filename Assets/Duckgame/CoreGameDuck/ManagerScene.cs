using DG.Tweening;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

namespace DevDuck
{
    public class ManagerScene : MonoBehaviour
    {
        public Image fadeImage; 
        public static ManagerScene ins;
        float timer = 0.5f;
        private void Awake()
        {
            if (ins == null)
            {
                ins = this;
                DontDestroyOnLoad(gameObject);
            }
            else
            {
                Destroy(gameObject); 
            }
        }
        public void LoadScene(string str)
        {
            fadeImage.gameObject.SetActive(true);
            fadeImage.color = new Color(0, 0, 0, 0); 
            fadeImage.DOFade(1, timer).SetEase(Ease.InOutQuad).OnComplete(() =>
            {
                SceneManager.LoadScene("SceneLoadScene");
                DOVirtual.DelayedCall(0.1f, () =>
                {
                    SceneManager.LoadScene(str);
                    fadeImage.DOFade(0, timer).SetEase(Ease.InOutQuad).OnComplete(() =>
                    {
                        fadeImage.gameObject.SetActive(false);
                    });
                });
            });
        }
    }
}


