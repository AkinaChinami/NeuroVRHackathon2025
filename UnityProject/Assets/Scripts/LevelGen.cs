using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class LevelGen : MonoBehaviour
{
    
    private XRGrabInteractable grabInteractable;
    public GameObject obj;
    public List<int> xmax = new List<int>(); // x range of objects

    public List<int> ymax = new List<int>(); // y range of obj
    public List<int> zmax = new List<int>(); // z range of objects
    public int n ;
    public int score = 0;
    public int max = 15;
    public int min = 2;
    private List<Vector3> pos = new List<Vector3>(); // list of all obj positions
    public List<GameObject> buttons = new List<GameObject>(); // list of all obj

    public GameObject timerObject;
    public Timer timerClass;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    public void Initialize(){
        timerClass = timerObject.GetComponent<Timer>();
        if (timerClass == null){
            Debug.Log("aaaaaaa");
        }
        n = Random.Range(min,max); // number of obj
        int surfnb = xmax.Count;
        for (int i = 0; i< 2*n; i+=2){
            int surf = Random.Range(0,surfnb -1);
            int xpos = Random.Range(xmax[surf],xmax[surf+1]);    
            int zpos = Random.Range(zmax[surf],zmax[surf+1]);
            int ypos = Random.Range(ymax[surf],ymax[surf+1]);
            Vector3 vector = new Vector3(xpos,ypos,zpos);
            if (!pos.Contains(vector)){
                pos.Add(new Vector3(xpos,ypos,zpos));
                buttons.Add(Instantiate(obj,vector,Quaternion.identity));
            }
            else {
                i-=2;
            }

            

        }
    }

    // Update is called once per frame
    void Update()
    {
        int count = buttons.Count;
        for (int i = 0; i < count;i++){
            ButtonBehavior s = buttons[i].GetComponent<ButtonBehavior>();
            if (s.isGrabbed == true){
                score ++;
                Destroy(buttons[i]);
                buttons.Remove(buttons[i]);
                i--;
                count--;
                Debug.Log(score);
            }
        }
        if (score == n && n != 0){
            score = 0;
            Debug.Log("WIN");
            timerClass.playerLocation();
        }
    }
}
