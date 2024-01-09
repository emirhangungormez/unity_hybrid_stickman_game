using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyBar : MonoBehaviour
{
    [SerializeField] Image barImage;
    [SerializeField] EnemyManager enemyManager;

    private void Update()
    {
        UpdateHealthBar();
        barImage.transform.parent.transform.LookAt(EnemyBarManager.Instance.GetCamera().transform);
    }

    void UpdateHealthBar()
    {
        float targetFillAmount = (float)enemyManager.GetEnemyHealth() / (float)EnemyFightManager.Instance.GetEnemyHealth(enemyManager.GetEnemyCount());
        barImage.fillAmount = Mathf.Lerp(barImage.fillAmount, targetFillAmount, Time.deltaTime * EnemyBarManager.Instance.GetBarFloat());
    }
}
