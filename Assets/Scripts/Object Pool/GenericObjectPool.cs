using UnityEngine;
using System.Collections.Generic;
public class GenericObjectPool<T> : MonoBehaviour where T : Component
{
    [System.Serializable]
    struct PrefabPool
    {
        public GameObject prefab;
        public int prefabPoolSize;
    }

    [SerializeField] private List<PrefabPool> prefabPools;

    protected Queue<GameObject> objects = new();

    public static GenericObjectPool<T> Instance { get; private set; }

    private void Awake()
    {
        Instance = this;
    }

    protected virtual void InitializePool()
    {
        for (int i = 0; i < prefabPools.Count; i++)
        {
            for (int j = 0; j < prefabPools[i].prefabPoolSize; j++)
            {
                AddToPool(prefabPools[i].prefab);
            }
        }
    }

    protected virtual void AddToPool(GameObject gameObject)
    {
        GameObject obj = Instantiate(gameObject);
        obj.SetActive(false);
        objects.Enqueue(obj);
    }

    public virtual GameObject GetObject()
    {
        if (objects.Count == 0)
            AddToPool(prefabPools[0].prefab);

        return objects.Dequeue();
    }

    public void ReturnObject(GameObject obj)
    {
        obj.SetActive(false);
        objects.Enqueue(obj);
    }
}
