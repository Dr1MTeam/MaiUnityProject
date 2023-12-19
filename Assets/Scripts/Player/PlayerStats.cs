using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class PlayerStats : MonoBehaviour
{
    private float lerpTimer;
    private float hp;
    public float maxHP = 100;
    private float mp;
    public float maxMP = 100;
    public float chipSpeed = 2f;
    public Image fHPbar;
    public Image bHPbar;
    public Image fMPbar;
    public Image bMPbar;
    // Start is called before the first frame update
    void Start()
    {
        hp = maxHP;
        mp = maxMP;
    }

    // Update is called once per frame
    void Update()
    {
        hp = Mathf.Clamp(hp, 0, maxHP);
        mp = Mathf.Clamp(mp, 0, maxMP);

        UpdateHPUI();
        UpdateMPUI();

    }
    public void UpdateHPUI()
    {
        Debug.Log(hp);
        float fillF = fHPbar.fillAmount;
        float fillB = bHPbar.fillAmount;
        float hFraction = hp / maxHP;
        if (fillB > hFraction)
        {
            fHPbar.fillAmount = hFraction;
            bHPbar.color = Color.red;
            lerpTimer += Time.deltaTime;
            float percentComplete = lerpTimer / chipSpeed;
            bHPbar.fillAmount = Mathf.Lerp(fillB, hFraction, percentComplete);
        }
        if (fillF < hFraction)
        {
            bHPbar.color = Color.green;
            bHPbar.fillAmount = hFraction;
            lerpTimer += Time.deltaTime;
            float percentComplete = lerpTimer / chipSpeed;
            percentComplete = percentComplete * percentComplete;
            fHPbar.fillAmount = Mathf.Lerp(fillF, bHPbar.fillAmount, percentComplete);

        }
    }
    public void UpdateMPUI()
    {
        float fillF = fMPbar.fillAmount;
        float fillB = bMPbar.fillAmount;
        float hFraction = hp / maxMP;
        if (fillB < hFraction)
        {
            fMPbar.fillAmount = hFraction;
            bMPbar.color = Color.red;
            lerpTimer += Time.deltaTime;
            float percentComplete = lerpTimer / chipSpeed;
            percentComplete = percentComplete * percentComplete;
            bMPbar.fillAmount = Mathf.Lerp(fillB, hFraction, percentComplete);
        }
        if (fillF < hFraction)
        {
            bMPbar.color = Color.green;
            bMPbar.fillAmount = hFraction;
            lerpTimer += Time.deltaTime;
            float percentComplete = lerpTimer / chipSpeed;
            percentComplete = percentComplete * percentComplete;
            fMPbar.fillAmount = Mathf.Lerp(fillF, bMPbar.fillAmount, percentComplete);

        }
    }
    public void TakeDamage(float damage)
    {
        ChangeStat(ref hp, -damage);
        lerpTimer = 0f;
    }
    public void RestoreHP(float restore)
    {
        ChangeStat(ref hp, restore);
        lerpTimer = 0f;
    }
    public void ChangeStat(ref float stat, float delta)
    {
        stat += delta;
    }
}
