using DevDuck;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;


namespace DevDuck
{
    public enum TYPE
    {
        LEFT, RIGHT, TOP, BOTTOM
    }
    public class TrafficLight : MonoBehaviour
    {
        public TYPE type;

        [SerializeField] float timer;
        [SerializeField] GameObject redLight, greenLight, yellowLight;
        [SerializeField] TextMeshPro timeText;
        [SerializeField] tagObject tagObject;
        [SerializeField] bool isRedLight = true;
        [SerializeField] GameObject triggerObject;


        private void Start()
        {
            SetUpRedLight();
        }
        private void Update()
        {
            timer -= Duck.TimeMod;
            timeText.text = "0" + Mathf.Round(timer).ToString();

            if (isRedLight)
            {
                triggerObject.gameObject.SetActive(true);

                if (timer <= 0)
                {
                    timer = 5;
                    triggerObject.GetComponent<tagObject>().tagObj = "Red";
                    isRedLight = false;
                }
                else if (timer <= 2.1f)
                {
                    timeText.color = Color.yellow;
                    triggerObject.GetComponent<tagObject>().tagObj = "Yellow";
                    CurrentYellowLight();
                }
                else
                {
                    CurrentRedLight();
                    timeText.color = Color.red;
                }
            }
            else
            {
                triggerObject.gameObject.SetActive(false);
                CurrentGreenLight();
                timeText.color = Color.green;
                if (timer <= 0)
                {
                    timer = 5;
                    isRedLight = true;
                }

            }
        }
        void CurrentRedLight()
        {
            greenLight.gameObject.SetActive(false);
            yellowLight.gameObject.SetActive(false);
            redLight.gameObject.SetActive(true);
        }
        void CurrentGreenLight()
        {
            redLight.gameObject.SetActive(false);
            yellowLight.gameObject.SetActive(false);
            greenLight.gameObject.SetActive(true);
        }
        void CurrentYellowLight()
        {
            redLight.gameObject.SetActive(false);
            greenLight.gameObject.SetActive(false);
            yellowLight.gameObject.SetActive(true);

        }

        public void SetUpRedLight()
        {
            switch (type)
            {
                case TYPE.LEFT:
                    triggerObject.transform.localPosition = new Vector3(-1.6f, 0.5f, 0);
                    break;
                case TYPE.RIGHT:
                    triggerObject.transform.localPosition = new Vector3(1.6f, 0.5f, 0);
                    break;
                case TYPE.BOTTOM:
                    triggerObject.transform.localPosition = new Vector3(0, 0.5f, -2);
                    break;
                case TYPE.TOP:
                    triggerObject.transform.localPosition = new Vector3(0, 0.5f, 2);
                    break;
            }
        }

    }
}

