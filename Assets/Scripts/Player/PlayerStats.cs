using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class PlayerStats : MonoBehaviour
{

    private float lerpTimer;
    private float hp;
    private float mp;
    private float durationTimer;
    public float chipSpeed = 2f;
    [Header("HP bar")]
    public float maxHP = 100;
    public Image fHPbar;
    public Image bHPbar;
    [Header("MP bar")]
    public float maxMP = 100;
    public Image fMPbar;
    public Image bMPbar;
    [Header("Overlay")]
    public Image overlay;
    public float duration;
    public float fadeSpeed;


    // Start is called before the first frame update
    void Start()
    {
        hp = maxHP;
        mp = maxMP;
        overlay.color = new Color(overlay.color.r, overlay.color.g, overlay.color.b, 0f);
    }

    // Update is called once per frame
    void Update()
    {
        hp = Mathf.Clamp(hp, 0, maxHP);
        mp = Mathf.Clamp(mp, 0, maxMP);

        UpdateHPUI();
        UpdateMPUI();
        DamageOverlay();

        
    }
    public void UpdateHPUI()
    {
        
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
            bMPbar.fillAmount = Mathf.Lerp(fillB, hFraction, percentComplete);
        }
        if (fillF < hFraction)
        {
            bMPbar.color = Color.green;
            bMPbar.fillAmount = hFraction;
            lerpTimer += Time.deltaTime;
            float percentComplete = lerpTimer / chipSpeed;
            fMPbar.fillAmount = Mathf.Lerp(fillF, bMPbar.fillAmount, percentComplete);

        }
    }
    public void TakeDamage(float damage)
    {
        ChangeStat(ref hp, -damage);
        lerpTimer = 0f;
        durationTimer = 0f;
        overlay.color = new Color(overlay.color.r, overlay.color.g, overlay.color.b, 0.15f);
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
    public void DamageOverlay()
    {
        if (overlay.color.a > 0)
        {
            durationTimer += Time.deltaTime;
            if (durationTimer > duration)
            {
                float tempAlpha = overlay.color.a;
                tempAlpha -= Time.deltaTime * fadeSpeed;
                overlay.color = new Color(overlay.color.r, overlay.color.g, overlay.color.b, tempAlpha);
            }
        }
    }
}
