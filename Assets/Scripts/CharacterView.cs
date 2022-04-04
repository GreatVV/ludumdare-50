using System.Collections;
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
        public Material DissolveMaterial;
        public Material NormalMaterial;
        public Renderer Renderer;
        public float DissolveTime = 1f;

        public void Flap()
        {
            Animator.SetTrigger("Flap");
        }

        public void Dissolve()
        {
            //StartCoroutine(DissolveCoroutine());
        }

        private IEnumerator DissolveCoroutine()
        {
            Renderer.sharedMaterial = DissolveMaterial;
            DissolveMaterial.SetFloat("_Cutoff", 0);
            var t = 0f;
            while (t < 1f)
            {
                t += 1f / DissolveTime;
                DissolveMaterial.SetFloat("_Cutoff", 1);
                yield return default;
            }

            yield return default;
            Renderer.sharedMaterial = NormalMaterial;
        }
    }
}