using Leopotam.Ecs;
using UnityEditor;

namespace Client
{
    internal class InitSystem : IEcsInitSystem
    {
        private EcsWorld _world;
        private RuntimeData _runtimeData;
        private StaticData _staticData;
        private SceneData _sceneData;

        private EcsFilter<Launchable> _filter;
        public void Init()
        {
            _runtimeData.FlapsLimit = _runtimeData.FlapsLeft = _staticData.StartFlaps;
            _runtimeData.FlapPrice = _staticData.StartFlapPrice;
            _world.NewEntity().Get<UpdateUIEvent>();
            _world.NewEntity().Get<SpawnCharacterEvent>();

            _sceneData.BuyFlapButton.onClick.AddListener(OnBuyClick);
        }

        private void OnBuyClick()
        {
            if (_filter.IsEmpty())
            {
                return;
            }

            if (_runtimeData.Money >= _runtimeData.FlapPrice)
            {
                _runtimeData.Money -= _runtimeData.FlapPrice;
                _runtimeData.FlapsLimit++;
                _runtimeData.FlapsLeft++;
                _runtimeData.FlapPrice++;
            }

            _world.NewEntity().Get<UpdateUIEvent>();
        }
    }
}