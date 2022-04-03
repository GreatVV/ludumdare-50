using Leopotam.Ecs;
using TMPro;
using UnityEngine;

namespace Client
{
    public class DraggableView : MonoBehaviour
    {
        public EcsEntity Entity;
        public int Price = 1;
        public TMP_Text PriceLabel;

        public void SetPrice(int price)
        {
            PriceLabel.text = $"{price}$";
        }
    }
}