using TMPro;
using UnityEngine;

public class EnemyWave : SingletonGeneric<EnemyWave>
{
    [SerializeField] private EnemyWaveScriptableObject m_EnemyWave;
    [SerializeField] private TextMeshProUGUI m_EnemyWavesRemainingText, m_EnemiesRemainingText;
    public int WavesRemaining { get; private set; }
    public int EnemiesPerWave { get; private set; }
    public int EnemiesAlive { get; set; }

    private bool m_NewWave = true;

    protected override void Awake()
    {
        base.Awake();
        if (m_EnemyWave == null) return;
        WavesRemaining = m_EnemyWave.numberOfWaves;
        EnemiesAlive = EnemiesPerWave = m_EnemyWave.enemiesInEachWave;
    }

    private void Update()
    {
        if (WavesRemaining < 0) return;

        if(m_EnemyWavesRemainingText == null || m_EnemiesRemainingText == null)
        {
            m_EnemyWavesRemainingText = AssetManager.Instance.EnemyWaveCanvas.transform.GetChild(0).GetChild(1).GetComponent<TextMeshProUGUI>();
            m_EnemiesRemainingText = AssetManager.Instance.EnemyWaveCanvas.transform.GetChild(0).GetChild(3).GetComponent<TextMeshProUGUI>();
        }

        if (EnemiesAlive <= 0)
        {
            EnemiesAlive = EnemiesPerWave;
            if (WavesRemaining > 0)
            { 
                WavesRemaining--;
                m_NewWave = true;
            }
        }

        if (EnemiesAlive == EnemiesPerWave && m_NewWave)
        {
            // Get all the enemies from the pool.
            for (int i = 0; i < EnemiesAlive; i++)
            {
                GameObject enemyViewGameObject = EnemyObjectPool.Instance.GetObject();
                enemyViewGameObject.SetActive(true);
                EnemyView enemyView = enemyViewGameObject.GetComponent<EnemyView>();
                enemyView.ResetHealth();
                enemyViewGameObject.transform.position = enemyView.GetRandomPosition();
            }

            m_NewWave = false;
        }
        m_EnemyWavesRemainingText.text = WavesRemaining.ToString();
        m_EnemiesRemainingText.text = EnemiesAlive.ToString();
    }
}
