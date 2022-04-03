using UnityEngine;

namespace Client
{
    [CreateAssetMenu]
    internal class StaticData : ScriptableObject
    {
        public CharacterView[] CharacterViews;
        public float PushPower = 10;
        public MoneyParticle MoneyParticle;
        public float SpawnTime = 5;
    }
}