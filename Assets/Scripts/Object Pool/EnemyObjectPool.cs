using UnityEngine;

public class EnemyObjectPool : GenericObjectPool<EnemyObjectPool>
{
    private EnemyWave m_EnemyWave;
    private void Start()
    {
        m_EnemyWave = GetComponent<EnemyWave>();
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
            AddToPool(EnemyService.Instance.CreateEnemy());

        return objects.Dequeue();
    }

    protected override void InitializePool()
    {
        for (int i = 0; i < m_EnemyWave.EnemiesPerWave; i++)
        {
            AddToPool(EnemyService.Instance.CreateEnemy());
        }
    }
}
