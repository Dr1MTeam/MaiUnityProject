using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class Scores : MonoBehaviour
{
    private PlayerStats stats;
    [Header("Stats")]
    public GameObject player;
    [Header("Kills")]
    public TMP_Text kills;
    [Header("Time")]
    public TMP_Text time;
    [Header("Heals")]
    public TMP_Text heals;
    private void Start()
    {
        stats = player.GetComponent<PlayerStats>();
    }
    void Update()
    {
        kills.text = stats.killScores.ToString();
        time.text = (stats.time).ToString();
        heals.text = stats.healScores.ToString();
    }
}
