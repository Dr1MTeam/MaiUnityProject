using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyStats : MonoBehaviour
{

    private float hp;
    [Header("HP")]
    public float maxHP = 100;
    public float Hp { get => hp; }


    // Start is called before the first frame update
    void Start()
    {
        hp = maxHP;
    }

    // Update is called once per frame
    void Update()
    {
        hp = Mathf.Clamp(hp, 0, maxHP);

    }
   
    public void TakeDamage(float damage)
    {
        ChangeStat(ref hp, -damage);
    }
    public void RestoreHP(float restore)
    {
        ChangeStat(ref hp, restore);
    }
    public void ChangeStat(ref float stat, float delta)
    {
        stat += delta;
    }
}
