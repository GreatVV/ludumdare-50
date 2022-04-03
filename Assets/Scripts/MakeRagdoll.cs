using System;
using UnityEngine;

namespace Client
{
    public class MakeRagdoll : MonoBehaviour
    {
        private void OnCollisionEnter(Collision other)
        {
            if (other.collider.TryGetComponent<CharacterView>(out var character))
            {
                character.Ragdoll.TurnOnRagdoll(true);
            }
        }
    }
}