using Leopotam.Ecs;
using UnityEngine;

namespace Client
{
    internal class DeathSystem : IEcsRunSystem
    {
        private EcsFilter<CharacterRef, Dead>.Exclude<DeathHasCome> _filter;
        private EcsWorld _world;
        private RuntimeData _runtimeData;

        public void Run()
        {
            foreach (var i in _filter)
            {
                var dead = _filter.Get2(i);

                _world.NewEntity().Get<SpawnDeathPosition>().position = dead.position;
                _runtimeData.MoneyForDeath++;

                _runtimeData.Money += _runtimeData.MoneyForDeath;

                var ecsEntity = _filter.GetEntity(i);
                ecsEntity.Del<Dead>();
                ecsEntity.Get<DeathHasCome>().time = Time.realtimeSinceStartup;
            }

            
        }
    }
}