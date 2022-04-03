using Leopotam.Ecs;
using UnityEngine;

namespace Client
{
    internal class StuckSystem : IEcsRunSystem
    {
        private EcsFilter<CollisionTime> _filter;
        private StaticData _staticData;
        private EcsFilter<CharacterRef>.Exclude<DeathHasCome> _nonDead;
        public void Run()
        {
            foreach (var i in _filter)
            {
                var collisionTime = _filter.Get1(i);
                if (Time.time - collisionTime.time > _staticData.StuckTime)
                {
                    foreach (var i1 in _nonDead)
                    {
                        _nonDead.GetEntity(i1).Get<Dead>();
                    }
                }
            }
        }
    }
}