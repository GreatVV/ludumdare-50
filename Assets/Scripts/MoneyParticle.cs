using System;
using TMPro;
using UnityEngine;

namespace Client
{
    internal class MoneyParticle : MonoBehaviour
    {
        public TMP_Text Amount;
        public float SelfDestroyTime = 2f;
        public float Speed = 2;

        public void SetAmount(int amount)
        {
            Amount.text = amount.ToString();
            Destroy(gameObject,  SelfDestroyTime);
        }

        public void Update()
        {
            transform.position += transform.up * Time.deltaTime * Speed;
        }
    }
}