using Leopotam.Ecs;
using UnityEngine;

namespace Client
{
    internal class StuckSystem : IEcsRunSystem
    {
        private EcsFilter<CollisionTime> _filter;
        private StaticData _staticData;
        private EcsFilter<CharacterRef>.Exclude<DeathHasCome, Launchable> _nonDead;
        public void Run()
        {
            var killAll = false;
            foreach (var i in _filter)
            {
                var collisionTime = _filter.Get1(i);
                if (Time.time - collisionTime.time > _staticData.StuckTime)
                {
                    foreach (var i1 in _nonDead)
                    {
                        _nonDead.GetEntity(i1).Get<Dead>();
                    }

                    Debug.Log("Add dead death stuck");
                    killAll = true;
                    _filter.GetEntity(i).Del<CollisionTime>();
                }
            }

            if (killAll)
            {
                foreach (var i in _filter)
                {
                    _filter.GetEntity(i).Del<CollisionTime>();
                }
            }
        }
    }
}