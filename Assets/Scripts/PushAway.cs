using System;
using UnityEngine;

namespace Client
{
    public class PushAway : MonoBehaviour
    {
        public float Power = 10;
        public void OnCollisionEnter(Collision other)
        {
            var character = other.collider.GetComponentInParent<CharacterView>();
            if (character)
            {
                if (other.rigidbody)
                {
                    other.rigidbody.AddForce((other.collider.transform.position - transform.position).normalized * Power, ForceMode.Impulse);
                }
            }
        }
    }
}