using UnityEngine;

[CreateAssetMenu(fileName = "EnemyWaveScriptableObject", menuName = "ScriptableObjects/New Enemy Wave Scriptable Object")]
public class EnemyWaveScriptableObject : ScriptableObject
{
    public int numberOfWaves;
    public int enemiesInEachWave;
}
