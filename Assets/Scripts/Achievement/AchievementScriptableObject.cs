using UnityEngine;

[CreateAssetMenu(fileName = "AchievementScriptableObject", menuName = "ScriptableObjects/NewAchievementScriptableObject")]
public class AchievementScriptableObject : ScriptableObject
{
    public string achievementName;
    public string description;
    public bool isUnlocked;

    public enum Type
    {
        BulletsFired,
        EnemyBulletsFired,
        EnemiesKilled
    }

    public Type type;

    public int valueToUnlock;

    public enum UnlockCondition
    {
        Less,
        LEqual,
        Equal,
        Greater,
        GEqual
    }

    public UnlockCondition unlockCondition;
    
    public bool CheckIfUnlocked(int count)
    {
        bool prevIsUnlocked = isUnlocked;
        switch (unlockCondition)
        {
            case UnlockCondition.Less: isUnlocked = count < valueToUnlock; break;
            case UnlockCondition.LEqual: isUnlocked = count <= valueToUnlock; break;
            case UnlockCondition.Equal: isUnlocked = count == valueToUnlock; break;
            case UnlockCondition.Greater: isUnlocked = count > valueToUnlock; break;
            case UnlockCondition.GEqual: isUnlocked = count >= valueToUnlock; break;
            default: break;
        }

        return !prevIsUnlocked && isUnlocked;
    }
}