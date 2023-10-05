public class AchievementSystem : SingletonGeneric<AchievementSystem>
{
    public delegate void AchievementAction(int count);
    public event AchievementAction OnBulletFired;
    public event AchievementAction OnEnemyBulletFired;
    public event AchievementAction OnEnemyKilled;

    public void NotifyBulletFired(int bulletsFired)
    {
        OnBulletFired?.Invoke(bulletsFired);
    }

    public void NotifyEnemyBulletFired(int enemyBulletsFired)
    {
        OnEnemyBulletFired?.Invoke(enemyBulletsFired);
    }

    public void NotifyEnemyKilled(int enemiesKilled)
    {
        OnEnemyKilled?.Invoke(enemiesKilled);
    }

}
