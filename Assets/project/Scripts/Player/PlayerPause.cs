using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class PlayerPause : MonoBehaviour
{
    // Start is called before the first frame update
    
    private PlayerStats stats;
    private bool isPaused = false;
    private bool isOver = false;

    public GameObject pause;
    void Start()
    {
        stats = GetComponent<PlayerStats>();
        pause.SetActive(false);
    }
    private void LateUpdate()
    {
        if (stats.HP==0)
        {
            isOver = true;
            pause.SetActive(true);
            Cursor.visible = true;
            Time.timeScale = 0;
        }
    }
    public void Pause()
    {

        isPaused = !isPaused;
        if (isPaused || isOver)
        {
            pause.SetActive(true);
            Cursor.visible = true;
            Time.timeScale = 0;
        }
        else
        {
            pause.SetActive(false);
            Cursor.visible = false;
            Time.timeScale = 1;
        }

    }
}
