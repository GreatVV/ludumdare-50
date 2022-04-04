using Leopotam.Ecs;
using TMPro;
using UnityEngine;
using UnityEngine.Events;

namespace Client
{
    public class DraggableView : MonoBehaviour
    {
        public EcsEntity Entity;
        public int Price = 1;
        public TMP_Text PriceLabel;

        public UnityEvent OnBuyEvent;

        public void SetPrice(int price)
        {
            PriceLabel.text = $"{price}$";
        }

        public void Buy()
        {
            OnBuyEvent?.Invoke();
        }
    }
}