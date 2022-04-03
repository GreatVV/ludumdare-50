using Leopotam.Ecs;
using UnityEditor;

namespace Client
{
    internal class InitSystem : IEcsInitSystem
    {
        private EcsWorld _world;
        private RuntimeData _runtimeData;

        public void Init()
        {
            _world.NewEntity().Get<SpawnCharacterEvent>();
        }
    }
}