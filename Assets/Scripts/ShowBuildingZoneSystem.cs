using Leopotam.Ecs;

namespace Client
{
    public class ShowBuildingZoneSystem : IEcsRunSystem
    {
        private SceneData _sceneData;
        private EcsFilter<Launchable> _filter;
        private RuntimeData _runtimeData;

        public void Run()
        {
            _sceneData.BuildingZone.SetActive(!_filter.IsEmpty() && _runtimeData.Money > 0);
            _sceneData.BuyFlapsRoot.SetActive(!_filter.IsEmpty() && _runtimeData.Money > 0);
        }
    }
}