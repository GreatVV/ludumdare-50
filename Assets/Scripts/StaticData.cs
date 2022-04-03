using UnityEngine;

namespace Client
{
    [CreateAssetMenu]
    internal class StaticData : ScriptableObject
    {
        public CharacterView[] CharacterViews;
        public MoneyParticle MoneyParticle;
        public float SpawnTime = 5;
        public float StuckTime = 5;

        public DraggableView[] ItemsToBuy;
        
        [Header("Launch")]
        public int StartFlaps = 1;
        public float ForcePower = 5;
        public Vector3 ForceDirection = new Vector3(-1, 1, 0);
        public int StartFlapPrice = 1;
    }
}