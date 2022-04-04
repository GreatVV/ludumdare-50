using System;
using UnityEngine;

namespace Client
{
    public class Teleportator : MonoBehaviour
    {
        public GameObject TeleportExit;
        public Vector3 Offset;

        private void OnValidate()
        {
            if (!Application.isPlaying)
            {
                if (TeleportExit && TeleportExit.transform.parent == transform)
                {
                    TeleportExit.transform.localPosition = Offset;
                }
            }
        }

        private void Start()
        {
            TeleportExit.transform.localPosition = Vector3.zero;
        }

        public void OnBuy()
        {
            TeleportExit.transform.localPosition = Offset;
        }

        private void OnDrawGizmos()
        {
            Gizmos.DrawLine(transform.position, transform.position + Offset);
        }

        private void OnTriggerEnter(Collider other)
        {
            var character = other.GetComponentInParent<CharacterView>();
            if (character)
            {
                character.transform.position = transform.position + Offset;
            }
        }
    }
}