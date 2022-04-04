using Leopotam.Ecs;
using UnityEngine;

namespace Client
{
    internal class DeathSystem : IEcsRunSystem
    {
        private EcsFilter<CharacterRef, Dead>.Exclude<DeathHasCome, Launchable> _filter;
        private EcsWorld _world;
        private RuntimeData _runtimeData;

        private EcsFilter<CollisionTime> _stuck;

        public void Run()
        {
            foreach (var i in _filter)
            {
                var dead = _filter.Get2(i);

                foreach (var i1 in _stuck)
                {
                    _stuck.GetEntity(i1).Del<CollisionTime>();
                }

                _world.NewEntity().Get<SpawnDeathPosition>().position = dead.position;
                _runtimeData.MoneyForDeath++;

                var character = _filter.Get1(i);
                character.view.Ragdoll.TurnOnRagdoll(true);
                

                _runtimeData.Money += _runtimeData.MoneyForDeath;
                _runtimeData.MaxLifeTime = Time.time - _runtimeData.StartFallTime;

                character.view.Dissolve();

                var ecsEntity = _filter.GetEntity(i);
                ecsEntity.Del<Flying>();
                ecsEntity.Del<Dead>();
                ecsEntity.Get<DeathHasCome>().time = Time.realtimeSinceStartup;  
                
            }

            
        }
    }
}