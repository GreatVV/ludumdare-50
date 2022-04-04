using Leopotam.Ecs;

namespace Client
{
    internal class TeleportToStartSystem : IEcsRunSystem
    {
        private EcsFilter<CharacterRef, Teleport> _filter;
        private SceneData _sceneData;
        private RuntimeData _runtimeData;
        private StaticData _staticData;

        private EcsFilter<CollisionTime> _collisionTime;

        public void Run()
        {
            foreach (var i in _filter)
            {
                var characterRef = _filter.Get1(i);
                var view = characterRef.view;
                view.Ragdoll.TurnOnRagdoll(false);
                view.transform.position = _sceneData.SpawnPosition.position;
                view.transform.rotation = _sceneData.SpawnPosition.rotation;

                _runtimeData.FlapsLeft = _runtimeData.FlapsLimit;

                var ecsEntity = _filter.GetEntity(i);
                ecsEntity.Get<Launchable>();
                ecsEntity.Del<DeathHasCome>();
                ecsEntity.Del<Teleport>();
                ecsEntity.Get<UpdateUIEvent>();

                foreach (var i1 in _collisionTime)
                {
                    _collisionTime.GetEntity(i1).Del<CollisionTime>();
                }
            }
        }
    }
}