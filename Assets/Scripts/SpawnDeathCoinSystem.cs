using Leopotam.Ecs;
using UnityEngine;

namespace Client
{
    public class SpawnDeathCoinSystem : IEcsRunSystem
    {
        private EcsFilter<SpawnDeathPosition> _filter;
        private StaticData _staticData;
        private RuntimeData _runtimeData;

        public void Run()
        {
            foreach (var i in _filter)
            {
                var pos = _filter.Get1(i).position;

                var instance = Object.Instantiate(_staticData.MoneyParticle, pos, Quaternion.identity);
                instance.SetAmount(_runtimeData.MoneyForDeath);

                _filter.GetEntity(i).Del<SpawnDeathPosition>();
            }
        }
    }
}