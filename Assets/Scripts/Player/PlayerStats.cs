using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class PlayerStats : MonoBehaviour
{
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
    }
    public void UpdateHPUI()
    {
        Debug.Log(hp);
    }
    public void UpdateMPUI()
    {
        Debug.Log(mp);
    }
}
