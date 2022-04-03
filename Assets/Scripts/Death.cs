using Leopotam.Ecs;
using UnityEngine;

namespace Client
{
    public class Death : MonoBehaviour
    {
        private void OnCollisionEnter(Collision other)
        {
            var character = other.collider.GetComponentInParent<CharacterView>();
            if (character)
            {
                character.Entity.Get<Dead>().position = other.GetContact(0).point;
            }
        }
    }
}