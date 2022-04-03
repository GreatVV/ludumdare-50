using System;
using Leopotam.Ecs;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.InputSystem;

namespace Client
{
    internal class LaunchSystem : IEcsRunSystem
    {
        private EcsFilter<CharacterRef, Launchable> _filter;
        private EcsFilter<CharacterRef, Flying> _filterFlying;
        private StaticData _staticData;
        private SceneData _sceneData;
        private RuntimeData _runtimeData;

        public void Run()
        {
            if (EventSystem.current.IsPointerOverGameObject())
            {
                return;
            }

            if (_runtimeData.IsDragging)
            {
                return;
            }

            if (Mouse.current.leftButton.wasPressedThisFrame)
            {
                foreach (var i in _filter)
                {
                    _runtimeData.StartFallTime = Time.time;
                    _sceneData.FallCamera.enabled = true;

                    var ecsEntity = _filter.GetEntity(i);
                    ecsEntity.Get<Flying>();
                    ecsEntity.Del<Launchable>();
                }

                foreach (var i in _filterFlying)
                {
                    var character = _filterFlying.Get1(i);
                    
                    if (_runtimeData.FlapsLeft > 0)
                    {
                        _runtimeData.FlapsLeft--;
                        character.view.Flap();
                        character.view.Rigidbody.AddForce(_staticData.ForceDirection.normalized * _staticData.ForcePower,
                            ForceMode.Impulse);
                    }
                    else
                    {
                        character.view.Ragdoll.TurnOnRagdoll(true);
                        _filterFlying.GetEntity(i).Del<Flying>();
                    }

                    _filterFlying.GetEntity(i).Get<UpdateUIEvent>();
                }
            }
        }
    }
}