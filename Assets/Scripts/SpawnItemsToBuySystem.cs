using Leopotam.Ecs;
using UnityEngine;

namespace Client
{
    internal class SpawnItemsToBuySystem : IEcsInitSystem
    {
        private SceneData _sceneData;
        private EcsWorld _world;
        private StaticData _staticData;

        public void Init()
        {
            for (var index = 0; index < _staticData.ItemsToBuy.Length; index++)
            {
                var draggableView = _staticData.ItemsToBuy[index];
                var entity = _world.NewEntity();
                var instance = Object.Instantiate(draggableView, _sceneData.ItemSpawnRoot.position + index * _sceneData.ItemOffset, Quaternion.identity, _sceneData.ItemSpawnRoot);
                entity.Get<Draggable>().view = instance;
                entity.Get<Price>().value = instance.Price;
                draggableView.SetPrice(instance.Price);
                draggableView.PriceLabel.enabled = true;
                instance.Entity = entity;
            }
        }
    }
}