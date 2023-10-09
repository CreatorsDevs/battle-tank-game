using UnityEngine;

public class EnemyService : SingletonGeneric<EnemyService>
{
    [SerializeField] private EnemyScriptableObjectList enemyScriptableObjectList;

    public GameObject CreateEnemy()
    {
        int randomNumber = (int)Random.Range(0, enemyScriptableObjectList.enemies.Length);
        EnemyScriptableObject enemyObject = enemyScriptableObjectList.enemies[randomNumber];
        Debug.Log("Created enemy of type: " + enemyObject.name);
        EnemyModel model = new(enemyObject);
        EnemyController enemy = new(model, enemyObject.enemyView);
        return enemy.EnemyView.gameObject;
    }
}

