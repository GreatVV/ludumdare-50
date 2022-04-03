using Leopotam.Ecs;
using UnityEngine;

namespace Client
{
    internal class CharacterView : MonoBehaviour
    {
        public Animator Animator;
        public Ragdoll Ragdoll;
        public Rigidbody Rigidbody;
        public EcsEntity Entity;

        public void Flap()
        {
            Animator.SetTrigger("Flap");
        }
    }
}