using EventBusSystem;
using TMPro;
using UnityEngine;
using System.Linq;


namespace Player
{
    public interface ICrowdCounter : IGlobalSubscriber
    {
        public void UpdateUI();

    }

    public class CrowdCounter : MonoBehaviour, ICrowdCounter
    {
    
        [Header("Elements")] 
        [SerializeField] private TMP_Text unitsCounter;
        [SerializeField] private GameObject unitsParent;

        private void OnEnable()
        {
            EventBus.Subscribe(this);
        }

        private void OnDisable()
        {
            EventBus.Unsubscribe(this);
        }

        public void UpdateUI()
        {
            int unitsCount = 0;
            
            for (int i = 0; i < unitsParent.transform.childCount; i++)
            {
                if (unitsParent.transform.GetChild(i).gameObject.activeInHierarchy)
                {
                    unitsCount++;
                }
            }
            unitsCounter.text = unitsCount.ToString();
        }
    
    }
}