using Leopotam.Ecs;

namespace Client
{
    internal class UpdateFlapsSystem : IEcsRunSystem
    {
        private EcsFilter<UpdateUIEvent> _filter;
        private RuntimeData _runtimeData;
        private SceneData _sceneData;
        public void Run()
        {
            if (!_filter.IsEmpty())
            {
                _sceneData.FlapsAmountLabel.text = $"Flaps left: {_runtimeData.FlapsLeft}";
                _sceneData.BuyFlapLabel.text = $"Buy flaps\n{_runtimeData.FlapPrice}$";
            }
        }
    }
}