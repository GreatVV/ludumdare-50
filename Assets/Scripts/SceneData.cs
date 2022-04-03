using Cinemachine;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Client
{
    internal class SceneData : MonoBehaviour
    {
        public Transform SpawnPosition;
        public CinemachineVirtualCamera LaunchCamera;
        public CinemachineVirtualCamera FallCamera;

        public TMP_Text MaxLifeTime;
        public TMP_Text CurrentLifeTime;
        public BoxCollider DragArea;

        
        public Transform ItemSpawnRoot;
        public Vector3 ItemOffset;
        public TMP_Text MoneyLabel;
        public TMP_Text FlapsAmountLabel;
        public TMP_Text BuyFlapLabel;
        public Button BuyFlapButton;
        public GameObject BuildingZone;
        public GameObject BuyFlapsRoot;
    }
}