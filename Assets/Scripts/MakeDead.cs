using Leopotam.Ecs;
using UnityEngine;

namespace Client
{
    public class MakeDead : MonoBehaviour
    {
        public EcsEntity Entity;
        private void OnCollisionEnter(Collision other)
        {
            var character = other.collider.GetComponentInParent<CharacterView>();
            if (character)
            {
                Entity = character.Entity.GetInternalWorld().NewEntity();
                Entity.Get<CollisionTime>().time = Time.time;
            }
        }

        private void OnCollisionExit(Collision other)
        {
            if (other.collider.GetComponentInParent<CharacterView>())
            {
                if (Entity.IsAlive())
                {
                    Entity.Del<CollisionTime>();
                }
            }
        }
    }
}