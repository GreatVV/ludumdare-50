using Leopotam.Ecs;
using UnityEngine;

namespace Client {
    sealed class Game : MonoBehaviour {
        EcsWorld _world;
        EcsSystems _systems;
        public SceneData SceneData;
        public RuntimeData RuntimeData;
        public StaticData StaticData;


        void Start () {
            // void can be switched to IEnumerator for support coroutines.
            
            _world = new EcsWorld ();
            _systems = new EcsSystems (_world);

            RuntimeData = new RuntimeData();

#if UNITY_EDITOR
            Leopotam.Ecs.UnityIntegration.EcsWorldObserver.Create (_world);
            Leopotam.Ecs.UnityIntegration.EcsSystemsObserver.Create (_systems);
#endif
            _systems
                .Add(new InitSystem())
                .Add(new SpawnCharacterSystem())
                .Add(new LaunchSystem())
                .Add(new DeathSystem())
                .Add(new SpawnDeathCoinSystem())
                .Add(new TeleportToStartSystem())
                .Add(new AutoTeleportOnDeathSystem())
                .OneFrame<Dead>()
                .Inject(StaticData)
                .Inject(SceneData)
                .Inject(RuntimeData)
                .Init ();
        }

        void Update () {
            _systems?.Run ();
        }

        void OnDestroy () {
            if (_systems != null) {
                _systems.Destroy ();
                _systems = null;
                _world.Destroy ();
                _world = null;
            }
        }
    }
}