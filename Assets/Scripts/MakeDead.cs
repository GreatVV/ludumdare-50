using System;
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
                if (!Entity.IsAlive())
                {
                    Entity = character.Entity.GetInternalWorld().NewEntity();
                }

                ref var collisionTime = ref Entity.Get<CollisionTime>();
                collisionTime.time = Time.time;
                collisionTime.Other = other;
                collisionTime.ThisGO = gameObject;
            }
        }

        private void OnCollisionStay(Collision other)
        {
            var character = other.collider.GetComponentInParent<CharacterView>();
            if (character)
            {
                if (!Entity.IsAlive())
                {
                    Entity = character.Entity.GetInternalWorld().NewEntity();
                    ref var collisionTime = ref Entity.Get<CollisionTime>();
                    collisionTime.time = Time.time;
                    collisionTime.Other = other;
                    collisionTime.ThisGO = gameObject;
                }
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