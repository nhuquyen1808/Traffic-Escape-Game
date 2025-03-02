using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DevDuck
{
    public class Player : MonoBehaviour
    {
        public GameObject o;
        public GameObject des;

        bool isPress;
        private void Update()
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                Debug.Log("???");
                isPress = true;
            }

            if (isPress)
            {
              transform.Translate(des.transform.position);

            }
        }
    }
}
    