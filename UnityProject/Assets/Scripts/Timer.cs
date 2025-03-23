using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;
using UnityEngine.SceneManagement;
using System.IO;

public class Timer : MonoBehaviour
{
    public float initialTime = 15f;
    public float timeLeft;
    public Transform player;
    public GameObject panel;
    public bool isTimeFinished = false;
    public int stageNumber = 0;
    GameObject level;

    public int iterations =5 ;
    public List<Dictionary<string,int>> scores = new List<Dictionary<string, int>>();

    public Dictionary<string,int> score = new Dictionary<string, int>();
    // level, time, w (win/lose) 
    public string path = "data.csv";
    void Start()
    {
        timeLeft = initialTime;
        playerLocation();
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
        if (level != null){ // clear elements from last stage
        LevelGen lvlclear = level.GetComponent<LevelGen>();
        int count = lvlclear.buttons.Count;
        for (int i = 0; i < count;i++){
            Destroy(lvlclear.buttons[i]);
            lvlclear.buttons.Remove(lvlclear.buttons[i]);
            i--;
            count --;
        }
    }
        score["level"] = stageNumber;
        score["time"]  = (int) timeLeft;
        score["win"] = isTimeFinished?0:1;
        scores.Add(score);
        iterations -=1;
        if (iterations <= 0 ){
            leaveGame();
        }
        getStage();
        Debug.Log("Stage");
        string levelName = "stage" + stageNumber.ToString();
        level = GameObject.Find(levelName);
        LevelGen lvlinit = level.GetComponent<LevelGen>();
        lvlinit.Initialize();
        player.transform.position = level.transform.position;
        panel.SetActive(false);
        panel.transform.position = player.transform.position + new Vector3(0,5,20);
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
            if (stageNumber >=3){
                stageNumber = 3;
            }
            else {
                stageNumber += 1;
            }
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

    public void leaveGame(){
        int mean = 0;
        int max = 0;
        int bestTime = 100;
        for (int i = 0; i< scores.Count; i++){
            mean += scores[i]["level"];
            if (scores[i]["level"] > max){
                max  = scores[i]["level"];
            }
            if (scores[i]["time"] < bestTime){
                bestTime = scores[i]["time"];
            }
        }
        mean /= scores.Count;

        ExportToCsv(scores,path);
        Debug.Log(scores);
        //teleport to exit place, show some stats
    }
     static void ExportToCsv(List<Dictionary<string, int>> data, string filePath)
    {
        using (StreamWriter writer = new StreamWriter(filePath))
        {
            // Write the header row (keys of the dictionary)
            var headers = data[0].Keys;
            writer.WriteLine(string.Join(",", headers));

            // Write each data row
            foreach (var row in data)
            {
                var values = row.Values;
                writer.WriteLine(string.Join(",", values));
            }
        }
    }
}
