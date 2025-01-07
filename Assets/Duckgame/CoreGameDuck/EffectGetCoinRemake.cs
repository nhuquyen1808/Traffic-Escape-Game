using DG.Tweening;
using System;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

namespace DevDuck
{
    public class EffectGetCoin : MonoBehaviour
    {
        [SerializeField] GameObject coinParent;
        public Vector3[] initialPos;
        public Quaternion[] initialRotation;
        public GameObject startPosition, destination;
        int coinNum = 10;
        public Vector3 des, originPos;
        public Text coinText;

        // Start is called before the first frame update
        void Start()
        {
            SetStartPosition();
        }
        private void Update()
        {
            if (Input.GetKeyUp(KeyCode.Space))
            {
                RewardParentCoin(10, 10,LoadScene); 
            }
        }
        private void SetStartPosition()
        {
            initialPos = new Vector3[coinNum];
            initialRotation = new Quaternion[coinNum];
            originPos = startPosition.transform.position;
            des = destination.transform.position;
            coinParent.transform.position = originPos;
            for (int i = 0; i < coinParent.transform.childCount; i++)
            {
                initialPos[i] = coinParent.transform.GetChild(i).position;
                initialRotation[i] = coinParent.transform.GetChild(i).rotation;
            }
        }

        private void Reset()
        {
            for (int i = 0; i < coinParent.transform.childCount; i++)
            {
                coinParent.transform.GetChild(i).position = initialPos[i];
                coinParent.transform.GetChild(i).rotation = initialRotation[i];
            }
        }

        public void RewardParentCoin(float coinGet, int amountImageShow ,Action action)
        {
            Reset();
            var delay = 0f;
          //  coinParent.SetActive(true);
            des = destination.transform.position;
            int count = 0;
            for (int i = 0; i < coinParent.transform.childCount; i++)
            {
                if (amountImageShow >= 10)
                {

                    coinParent.transform.GetChild(i).DOScale(1, 0.3f).SetDelay(delay).SetEase(Ease.OutBack);
                    coinParent.transform.GetChild(i).GetComponent<RectTransform>().DOMove(des, 0.5f)
                        .SetDelay(delay + 0.5f).SetEase(Ease.InBack);
                    coinParent.transform.GetChild(i).DOScale(0, 0.1f).SetDelay(delay + 1.8f).SetEase(Ease.OutBack).OnComplete(() =>
                    {
                        count++;
                        if (count == coinNum)
                        {
                            Debug.Log("Done");
                            action.Invoke();
                        }
                    });
                    delay += 0.1f;
                }
                else
                {
                    if (i < amountImageShow)
                    {
                        coinParent.transform.GetChild(i).DOScale(1, 0.3f).SetDelay(delay).SetEase(Ease.OutBack);
                        coinParent.transform.GetChild(i).GetComponent<RectTransform>().DOMove(des, 0.5f).SetDelay(delay + 0.5f).SetEase(Ease.InBack);
                        coinParent.transform.GetChild(i).DOScale(0, 0.1f).SetDelay(delay + 1.8f).SetEase(Ease.OutBack).OnComplete(() =>
                        {
                            count++;
                            if (count == coinNum)
                            {
                                Debug.Log("Done");
                                action.Invoke();
                            }
                        });
                        delay += 0.1f;
                    }
                }
                coinParent.transform.GetChild(i).DORotate(Vector3.zero, .5f).SetDelay(delay + 0.5f).SetEase(Ease.Flash).OnComplete(() =>
                {
                    PlayerPrefs.SetFloat("COIN", PlayerPrefs.GetFloat("COIN") + coinGet);
                    coinText.text = Mathf.Round(PlayerPrefs.GetFloat("COIN")).ToString();
                });

            }
        }
        private void LoadScene()
        {
            SceneManager.LoadScene("BrickRacer");
        }
    }
}
