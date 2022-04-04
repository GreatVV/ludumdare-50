using Leopotam.Ecs;

namespace Client
{
    public class ShowBuildingZoneSystem : IEcsRunSystem
    {
        private SceneData _sceneData;
        private EcsFilter<Launchable> _filter;
        private RuntimeData _runtimeData;

        private EcsFilter<Draggable> _draggable;

        public void Run()
        {
            _sceneData.BuildingZone.SetActive(!_filter.IsEmpty() && !_draggable.IsEmpty());
            _sceneData.ItemSpawnRoot.gameObject.SetActive(!_filter.IsEmpty());
            _sceneData.BuyFlapsRoot.SetActive(!_filter.IsEmpty());
            _sceneData.BuyFlapButton.interactable = _runtimeData.FlapPrice <= _runtimeData.Money;
        }
    }
}