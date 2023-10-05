using System.Collections.Generic;
using UnityEngine;

public class AchievementObserver : MonoBehaviour
{
    [SerializeField] private List<AchievementScriptableObject> achievementScriptableObjects = new();

    private void Start()
    {
        // Reset Achievements - For testing only as achievements should be persistent.
        for (int i = 0; i < achievementScriptableObjects.Count; i++)
            achievementScriptableObjects[i].isUnlocked = false;

        AchievementSystem.Instance.OnBulletFired += HandleBulletFired;
        AchievementSystem.Instance.OnEnemyBulletFired += HandleEnemyBulletFired;
        AchievementSystem.Instance.OnEnemyKilled += HandleEnemyKilled;
    }

    private void OnDestroy()
    {
        AchievementSystem.Instance.OnBulletFired -= HandleBulletFired;
        AchievementSystem.Instance.OnEnemyBulletFired -= HandleEnemyBulletFired;
        AchievementSystem.Instance.OnEnemyKilled -= HandleEnemyKilled;
    }

    private void HandleBulletFired(int bulletsFired)
    {
        HandleAchievement(bulletsFired, AchievementScriptableObject.Type.BulletsFired);
    }

    private void HandleEnemyBulletFired(int enemyBulletsFired)
    {
        HandleAchievement(enemyBulletsFired, AchievementScriptableObject.Type.EnemyBulletsFired);
    }

    private void HandleEnemyKilled(int enemyKilled)
    {
        HandleAchievement(enemyKilled, AchievementScriptableObject.Type.EnemiesKilled);
    }

    private void HandleAchievement(int count, AchievementScriptableObject.Type type)
    {
        for (int i = 0; i < achievementScriptableObjects.Count; i++)
        {
            AchievementScriptableObject achievement = achievementScriptableObjects[i];

            if (achievement.type == type)
                if (achievement.CheckIfUnlocked(count))
                    AchievementViewer.Instance.ShowAchievementPanel(achievement);
        }
    }
}
