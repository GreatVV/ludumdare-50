using Leopotam.Ecs;
using UnityEngine;

namespace Client
{
    public class AutoTeleportOnDeathSystem : IEcsRunSystem
    {
        private EcsFilter<CharacterRef, DeathHasCome> _filter;
        private StaticData _staticData;
        private SceneData _sceneData;
        private EcsWorld _world;

        public void Run()
        {
            foreach (var i in _filter)
            {
                var characterRef = _filter.Get1(i);
                var death = _filter.Get2(i);

                if (Time.realtimeSinceStartup > death.time + _staticData.SpawnTime)
                {
                    var ecsEntity = _filter.GetEntity(i);
                    _sceneData.FallCamera.enabled = false;

                    _world.NewEntity().Get<UpdateUIEvent>();
                   
                    ecsEntity.Get<Teleport>();
                }
            }
        }
    }
}