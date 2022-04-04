using Leopotam.Ecs;

namespace Client
{
    public class TryBuyItemSystem : IEcsRunSystem
    {
        private EcsFilter<Draggable, Price, TryBuy> _filter;
        private RuntimeData _runtimeData;
        private SceneData _sceneData;
        public void Run()
        {
            foreach (var i in _filter)
            {
                var price = _filter.Get2(i);
                var ecsEntity = _filter.GetEntity(i);
                if (_runtimeData.Money >= price.value)
                {
                    _runtimeData.Money -= price.value;

                    var draggable = _filter.Get1(i).view;
                    var dragAreaCenter = _sceneData.DragArea.bounds.center;
                    dragAreaCenter.z = _sceneData.SpawnPosition.position.z;
                    draggable.transform.position = dragAreaCenter;
                    draggable.transform.SetParent(null, true);
                    draggable.PriceLabel.enabled = false;

                    draggable.Buy();

                    ecsEntity.Get<UpdateUIEvent>();
                    ecsEntity.Get<ReorderItems>();
                    ecsEntity.Get<CanBeDragged>();
                    ecsEntity.Del<Price>();
                }
                ecsEntity.Del<TryBuy>();
            }
        }
    }
}