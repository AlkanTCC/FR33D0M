using NUnit.Framework;
using UnityEngine;
using System.Collections.Generic;

// Gemaakt door Jin aljumaili
public class BulletPool : MonoBehaviour
{
    public static BulletPool instance;
    private List<GameObject> pooledObjects = new List<GameObject>();
    private int amountToPool = 40;
    [SerializeField] private GameObject BulletPreFab;

    private void Awake()
    {
        if (instance == null)
        {
        instance = this;
        }
    }
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        for(int i = 0; i < amountToPool; i++)
        {
            GameObject obj = Instantiate(BulletPreFab);
            obj.SetActive(false);
            pooledObjects.Add(obj);
        }
    }
    public GameObject GetGameObject()
    {
        for(int i = 0;i < pooledObjects.Count;i++)
        {
            if(!pooledObjects[i].activeInHierarchy)
            {
                pooledObjects[i].GetComponent<Bullet>().Rotation();
                return pooledObjects[i];
            }
        }
        return null;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
