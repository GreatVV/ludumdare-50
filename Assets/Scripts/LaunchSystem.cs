using System;
using Leopotam.Ecs;
using UnityEngine;
using UnityEngine.InputSystem;

namespace Client
{
    internal class LaunchSystem : IEcsRunSystem
    {
        private EcsFilter<CharacterRef, Launchable> _filter;
        private StaticData _staticData;
        private SceneData _sceneData;

        public void Run()
        {
            if (_filter.IsEmpty())
            {
                return;
            }

            if (Mouse.current.leftButton.wasPressedThisFrame)
            {
                foreach (var i in _filter)
                {
                    var character = _filter.Get1(i);
                    

                    character.view.Animator.enabled = false;
                    character.view.Ragdoll.TurnOnRagdoll(true);
                    foreach (var rigidbody in character.view.Ragdoll.Rigidbodies)
                    {
                        if (rigidbody)
                            rigidbody.AddForce(Vector3.left * _staticData.PushPower);
                    }

                    _sceneData.FallCamera.enabled = true;

                    _filter.GetEntity(i).Del<Launchable>();
                }
            }
        }
    }
}