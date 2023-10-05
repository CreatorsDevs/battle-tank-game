using System.Collections;
using TMPro;
using UnityEngine;

public class AchievementViewer : SingletonGeneric<AchievementViewer> 
{
    [SerializeField] private float timeToHide = 2f;

    private TextMeshProUGUI m_NameText, m_DescriptionText;

    private void Start()
    {
        SetNameAndDescription();
    }

    private void SetNameAndDescription()
    {
        GameObject achievementCanvas = AssetManager.Instance.AchievementCanvas;
        if (!achievementCanvas) return;

        m_NameText = achievementCanvas.transform.GetChild(0).GetChild(0).GetComponent<TextMeshProUGUI>();
        m_DescriptionText = achievementCanvas.transform.GetChild(0).GetChild(1).GetComponent<TextMeshProUGUI>();
    }

    public void ShowAchievementPanel(AchievementScriptableObject achievement)
    {
        AssetManager.Instance.AchievementCanvas.SetActive(true);

        if(m_NameText == null || m_DescriptionText == null)
            SetNameAndDescription();

        m_NameText.text = achievement.name;
        m_DescriptionText.text = achievement.description;

        StartCoroutine(DisableAchievementPanel());
    }

    private IEnumerator DisableAchievementPanel()
    {
        yield return new WaitForSeconds(timeToHide);
        AssetManager.Instance.AchievementCanvas.SetActive(false);
        StopCoroutine(DisableAchievementPanel());
    }
}
