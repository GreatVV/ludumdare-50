using System;
using UnityEngine;

namespace Client
{
    [Serializable]
    public class RuntimeData
    {
        public int MoneyForDeath;
        public int Money;
        public float StartFallTime;
        public bool IsDragging;
        public DraggableView DragTarget;
        public int FlapsLeft;
        public int FlapsLimit;
        public int FlapPrice;

        public float MaxLifeTime
        {
            get => PlayerPrefs.GetFloat("MaxLife");
            set
            {
                if (value > MaxLifeTime)
                {
                    PlayerPrefs.SetFloat("MaxLife", value);
                }
            }
        }
    }
}