using Leopotam.Ecs;
using UnityEngine;
using UnityEngine.InputSystem;

namespace Client
{
    internal class DragSystem : IEcsRunSystem
    {
        private EcsFilter<Launchable> _launchable;
        private RuntimeData _runtimeData;
        private SceneData _sceneData;

        public void Run()
        {
            if (_launchable.IsEmpty())
            {
                return;
            }

            if (Mouse.current.leftButton.wasPressedThisFrame)
            {
                var ray = Camera.main.ScreenPointToRay(Mouse.current.position.ReadValue());
                if (Physics.Raycast(ray, out var hitInfo))
                {
                    var draggableView = hitInfo.collider.GetComponentInParent<DraggableView>();
                    if (draggableView)
                    {

                        _runtimeData.IsDragging = true;

                        if (draggableView.Entity.Has<CanBeDragged>())
                        {
                            _runtimeData.DragTarget = draggableView;
                        }
                        else
                        {
                            draggableView.Entity.Get<TryBuy>();
                        }
                    }
                }
            }
            else
            {
                if (Mouse.current.leftButton.isPressed && _runtimeData.DragTarget && _runtimeData.IsDragging)
                {
                    var ray = Camera.main.ScreenPointToRay(Mouse.current.position.ReadValue());
                    var plane = new Plane(Vector3.forward, _sceneData.SpawnPosition.position);
                    if (plane.Raycast(ray, out var distance))
                    {
                        var point = ray.GetPoint(distance);      
                        var dragAreaBounds = _sceneData.DragArea.bounds;
                        var bounds2d = new Bounds(dragAreaBounds.center,
                            new Vector3(dragAreaBounds.size.x, dragAreaBounds.size.y, 10000f));
                        if (bounds2d.Contains(point))
                        {
                            _runtimeData.DragTarget.transform.position = point;
                        }
                    }
                }
                else
                {
                    _runtimeData.IsDragging = false;
                    _runtimeData.DragTarget = default;
                }
            }

        }
    }
}