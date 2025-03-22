using System.Collections;
using UnityEngine.UI;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Timer : MonoBehaviour
{
    public float initialTime = 15f;
    public float timeLeft;
    public Transform player;
    public GameObject panel;
    public bool isTimeFinished = false;
    public int stageNumber = 3;

    void Start()
    {
        timeLeft = initialTime;
    }

    // Update is called once per frame
    void Update()
    {
        timeLeft -= Time.deltaTime;
        //startText.text = (timeLeft).ToString("0");
        if (timeLeft < 0)
        {
            panel.SetActive(true);
            isTimeFinished = true;
        }
    }

    public void playerLocation()
    {
        getStage();
        string levelName = "stage" + stageNumber.ToString();
        GameObject level = GameObject.Find(levelName);
        player.transform.position = level.transform.position;
        panel.SetActive(false);
        panel.transform.position = player.transform.position + Vector3.forward;
        resetTime();
    }

    public void getStage()
    {
        if (isTimeFinished)
        {
            if (stageNumber <= 1)
            {
                stageNumber = 1;
            }
            else if (stageNumber >= 2)
            {
                stageNumber -= 1;
            }
        }
        else if (!isTimeFinished)
        {
            stageNumber += 1;
        }
    }
    
    public void resetTime()
    {
        if (isTimeFinished)
        {
            timeLeft = initialTime - 5f;
            isTimeFinished = false;
        }
        else if (!isTimeFinished)
        {
            timeLeft = initialTime + 5f;
        }

    }
}
