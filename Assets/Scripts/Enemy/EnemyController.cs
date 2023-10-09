using UnityEngine;

public class EnemyController
{
    public EnemyModel EnemyModel { get; }
    public EnemyView EnemyView { get; }

    public Vector3 GetRandomSpawnPosition()
    {
        float randomX = Random.Range(-25,25);
        float randomZ = Random.Range(-25,25);
        return new Vector3(randomX, 0f, randomZ);
    }
    public EnemyController(EnemyModel enemyModel, EnemyView enemyView)
    {
        EnemyModel = enemyModel;
        EnemyView = GameObject.Instantiate<EnemyView>(enemyView, GetRandomSpawnPosition(), Quaternion.identity);
        EnemyView.SetEnemyController(this);
    }
    public EnemyModel GetEnemyModel()
    {
        return EnemyModel;
    }

    public void ResetHealth()
    {
        EnemyModel.Health = EnemyModel.MaxHealth;
    }

    public bool TakeDamage(float damage)
    {
        if (EnemyModel.Health <= 0) return false;

        EnemyModel.Health = (int)Mathf.Clamp(EnemyModel.Health - damage, 0, EnemyModel.MaxHealth);

        if (EnemyModel.Health == 0)
            DestroyEnemy();

        return true;
    }

    public bool GiveDamage(IDamagable damagable)
    {
        return damagable.TakeDamage(EnemyModel.Damage);
    }

    public void DestroyEnemy()
    {
        EnemyWave.Instance.EnemiesAlive--;
        AchievementSystem.Instance.NotifyEnemyKilled(++AssetManager.Instance.EnemiesKilled);
        GameObject explosion = GameObject.Instantiate(EnemyModel.Explosion, EnemyView.transform.position, Quaternion.identity);
        GameObject.Destroy(explosion, 1.5f);
        AssetManager.Instance.RemoveEnemyView(EnemyView);
        EnemyObjectPool.Instance.ReturnObject(EnemyView.gameObject);
    }
}
