using UnityEngine;

public class BulletObjectPool : GenericObjectPool<BulletObjectPool>
{
    [SerializeField] private int initialPoolSize = 60;
    private void Start()
    {
        InitializePool();
    }

    protected override void AddToPool(GameObject gameObject)
    {
        gameObject.SetActive(false);
        objects.Enqueue(gameObject);
    }

    public override GameObject GetObject()
    {
        if (objects.Count == 0)
            AddToPool(ShellService.Instance.SpawnShell());

        return objects.Dequeue();
    }

    protected override void InitializePool()
    {
        for (int i = 0; i < initialPoolSize; i++)
        {
            AddToPool(ShellService.Instance.SpawnShell());
        }
    }
}
