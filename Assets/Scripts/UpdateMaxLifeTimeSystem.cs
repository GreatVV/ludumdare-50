using System;
using Leopotam.Ecs;
using UnityEngine;

namespace Client
{
    internal class UpdateMaxLifeTimeSystem : IEcsRunSystem
    {
        private EcsFilter<UpdateUIEvent> _filter;
        private SceneData _sceneData;
        private RuntimeData _runtimeData;
        private EcsFilter<Launchable> _launchable;
        private EcsFilter<DeathHasCome> _dead;

        public void Run()
        {
            if (!_filter.IsEmpty())
            {
                _sceneData.MaxLifeTime.text = $"Best Fly Time: {_runtimeData.MaxLifeTime:F1}s";
            }
            _sceneData.CurrentLifeTime.enabled = _launchable.IsEmpty();
            if (_launchable.IsEmpty() && _dead.IsEmpty())
            {
                _sceneData.CurrentLifeTime.text = $"Fly Time: {Time.time - _runtimeData.StartFallTime:F1}s";
            }
        }
    }
}