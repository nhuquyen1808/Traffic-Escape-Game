using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DevDuck
{
    public class CameraController : MonoBehaviour
    {
        Transform target;
        Vector3 velocity = Vector3.zero;

        [Range(0f, 1f)]
        public float smooth;
        public Vector3 offset;
        private void Awake()
        {
            target = GameObject.FindGameObjectWithTag("Player").transform;

        }

/*        private void LateUpdate()
        {
            Vector3 targetPos = target.position  + offset;
            transform.position = Vector3.SmoothDamp(transform.position, targetPos,ref velocity, smooth);
        }*/
        private void LateUpdate()
        {
            transform.position = new Vector3(transform.position.x, target.position.y, transform.position.z);

            transform.position = Vector3.Lerp(transform.position, new Vector3(transform.position.x, target.position.y, transform.position.z), Time.deltaTime * 2);
        }
    }
}
