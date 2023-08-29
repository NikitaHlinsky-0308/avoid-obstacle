using System;
using EventBusSystem;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace CodeBase.Level
{
    public interface IDoorEvent : IGlobalSubscriber
    {
        public void HandleDoorInteraction(string hashId);

    }
    
    public class DoorEventHandler : MonoBehaviour, IDoorEvent
    {
        [Header("Elements")]
        [SerializeField] private PlayerDetection playerDetection;

        [Header("Settings")]
        [SerializeField] private DoorType doorType;
        [SerializeField] private string nameSceneToFinish;
        
        private bool isInteracted;
        private string doorId;

        [Serializable] public enum DoorType
        {
            StartDoor,
            MiddleDoor,
            FinishDoor
        }
        
        public string DoorId
        {
            get => doorId;
        }

        
        private void Awake()
        {
            doorId = Guid.NewGuid().ToString();
        }

        private void OnEnable()
        {
            EventBus.Subscribe(this);
        }

        private void OnDisable()    
        {
            EventBus.Unsubscribe(this);
        }

        private bool IsOwner(string hashId) => this.doorId == hashId;
        private bool IsInteracted() => isInteracted;
        private bool IsNotInteracted() => !isInteracted;


        private void SetInteractableState()
        {
            isInteracted = true;
        }
        
        public void HandleDoorInteraction(string hashId)
        {

            if (IsOwner(hashId))
            {
                switch (doorType)
                {
                    case DoorType.StartDoor:
                        StartHandle();
                        break;
                    
                    case DoorType.MiddleDoor:
                        MiddleHandle();
                        break;
                    
                    case DoorType.FinishDoor:
                        FinishHandle();
                        break;
                }
            }
        }

        private void StartHandle()
        {
            if (IsInteracted()) 
                return;
            
            // Do smt
            Debug.Log("Start Message");
            SetInteractableState();
        }

        private void MiddleHandle()
        {
            if (IsInteracted()) 
                return;
            
            // Add score or/and amount of units
            Debug.Log("Middle Message");
            SetInteractableState();
        }

        private void FinishHandle()
        {
            if (IsInteracted()) 
                return;
            
            LoadSceneOnFinish(nameSceneToFinish);
            SetInteractableState();
        }

        private void LoadSceneOnFinish(string nameScene)
        {
            SceneManager.LoadSceneAsync(nameScene);
        }
        
    }
    
    

    
}