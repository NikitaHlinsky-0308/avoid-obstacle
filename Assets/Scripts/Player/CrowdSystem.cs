using System;
using EventBusSystem;
using NaughtyAttributes;
using Systems;
using UnityEngine;

namespace Player
{
    public class CrowdSystem : MonoBehaviour
    {
        private const int UNITS_PRELOAD_COUNT = 20;
        
        
        [Header("Elements")]
        // [SerializeField] private GameObject[] units;
        [SerializeField] private GameObject unitPrefab;
        [SerializeField] private Transform poolParent;
        
        [Header("Settings")] 
        [SerializeField] private float angle;
        [SerializeField] private float raduis;

        private ObjectPool<GameObject> unitsPool;

        private void Awake()
        {
            unitsPool = new ObjectPool<GameObject>(Preload, GetAction, ReturnAction, UNITS_PRELOAD_COUNT);
        }
        
        [Button]
        private void HandleUI()
        {
            EventBus.RaiseEvent<ICrowdCounter>(h => h.UpdateUI());
        }

        private void Update()
        {
            PlaceRunners();
       
        }

        private void PlaceRunners()
        {
            for (int i = 0; i < poolParent.childCount; i++)
            {
                Vector3 unitLocalPosition = GetUnitLocalPosition(i);
                poolParent.GetChild(i).localPosition = unitLocalPosition;
            }
        }

        private Vector3 GetUnitLocalPosition(int index)
        {
            float x = raduis * Mathf.Sqrt(index) * Mathf.Cos(Mathf.Deg2Rad * index * angle);
            float z = raduis * Mathf.Sqrt(index) * Mathf.Sin(Mathf.Deg2Rad * index * angle);

            return new Vector3(x, 0, z);
        }

        
        [Button]
        private void AddToPool()
        {
            unitsPool.Get();
        }
        
        [Button]
        private void RemoveFromPool()
        {
            unitsPool.ReturnLastActive();
        }
        
        
        public GameObject Preload() => Instantiate(unitPrefab, poolParent);

        public void GetAction(GameObject obj) => obj.SetActive(true);
        
        public void ReturnAction(GameObject obj) => obj.SetActive(false);
        
        

        #region false attempt
        
        // [Button("Add unit")]
        // private void ShowRunners()
        // {
        //     int lastActiveUnit = 0;
        //     
        //     for (int i = 0; i < units.Length; i++)
        //     {
        //         if (units[i].activeInHierarchy)
        //         {
        //             lastActiveUnit = i + 1;
        //             Debug.Log(lastActiveUnit);
        //         }
        //     }
        //     
        //     
        //     // for (int i = 0; i < 6; i++)
        //     for (int i = 0; i < lastActiveUnit; i++)
        //     {
        //         if (!units[i].activeInHierarchy)
        //         {
        //             units[i].SetActive(true);
        //         }
        //     }
        // }
        //
        // [Button("Remove unit")]
        // private void HideRunners()
        // {
        //     int lastActiveUnit = 0;
        //     
        //     for (int i = 0; i < units.Length; i++)
        //     {
        //         if (units[i].activeInHierarchy)
        //         {
        //             lastActiveUnit = i;
        //             Debug.Log(lastActiveUnit);
        //         }
        //     }
        //
        //     for (int i = lastActiveUnit; i >= 3; i--)
        //     {
        //         if (units[i].activeInHierarchy)
        //         {
        //             units[i].SetActive(false);
        //         }
        //     }
        // }
        //
        //
        //
        // private void ShowRunners(int amount)
        // {
        //     for (int i = 0; i < amount; i++)
        //     {
        //         if (!units[i].activeInHierarchy)
        //         {
        //             units[i].SetActive(true);
        //         }
        //     }
        // }
        //
        // private void HideRunners(int amount)
        // {
        //     for (int i = 0; i < units.Length; i++)
        //     {
        //         if (units[i].activeInHierarchy && i == (amount - 1))
        //         {
        //             units[i].SetActive(true);
        //         }
        //     }
        // }
    
        #endregion
    }
}
