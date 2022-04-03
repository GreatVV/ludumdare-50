using Leopotam.Ecs;

namespace Client
{
    internal class UpdateTotalMoneySystem : IEcsRunSystem
    {
        private EcsFilter<UpdateUIEvent> _filter;
        private SceneData _sceneData;
        private RuntimeData _runtimeData;
        public void Run()
        {
            if (!_filter.IsEmpty())
            {
                _sceneData.MoneyLabel.text = $"{_runtimeData.Money}$";
            }
        }
    }
}