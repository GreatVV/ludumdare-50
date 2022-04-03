using Leopotam.Ecs;
using UnityEngine;

namespace Client
{
    internal class SpawnCharacterSystem : IEcsRunSystem
    {
        private EcsFilter<SpawnCharacterEvent> _filter;
        private StaticData _staticData;
        private SceneData _sceneData;
        private EcsWorld _world;

        public void Run()
        {
            foreach (var i in _filter)
            {
                var character = Object.Instantiate(_staticData.CharacterViews[0], _sceneData.SpawnPosition.position,
                    _sceneData.SpawnPosition.rotation);

                var entity = _world.NewEntity();
                entity.Get<CharacterRef>().view = character;
                entity.Get<Launchable>();
                character.Ragdoll.TurnOnRagdoll(false);
                character.Entity = entity;

                _sceneData.FallCamera.Follow = character.Ragdoll.Rigidbodies[0].transform;
                _sceneData.FallCamera.LookAt = character.Ragdoll.Rigidbodies[0].transform;

                _filter.GetEntity(i).Del<SpawnCharacterEvent>();
            }
        }
    }
}