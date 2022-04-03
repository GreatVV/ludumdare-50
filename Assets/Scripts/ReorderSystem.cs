using Leopotam.Ecs;
using UnityEngine;

namespace Client
{
    public class ReorderSystem : IEcsRunSystem
    {
        private EcsFilter<ReorderItems> _filter;
        private SceneData _sceneData;

        public void Run()
        {
            foreach (var i in _filter)
            {
                foreach (Transform o in _sceneData.ItemSpawnRoot)
                {
                    o.localPosition = _sceneData.ItemOffset * o.GetSiblingIndex();
                }

                _filter.GetEntity(i).Del<ReorderItems>();
            }
        }
    }
}