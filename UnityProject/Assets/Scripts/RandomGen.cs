using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class RandomGen : MonoBehaviour
{
    // Start is called before the first frame update
    private XRGrabInteractable grabInteractable;
    public GameObject obj;
    public int xmax = 15; // x range of objects
    public int zmax = 15; // z range of objects
    int n = 10;
    int score = 0;
    List<Vector3> pos = new List<Vector3>(); // list of all obj positions
    List<GameObject> buttons = new List<GameObject>(); // list of all obj
    void Start()
    {
        n = Random.Range(1,15); // number of obj
        for (int i = 0; i< n; i++){
            int xpos = Random.Range(-xmax,xmax);    
            int zpos = Random.Range(-zmax,zmax);
            Vector3 vector = new Vector3(xpos,0,zpos);
            if (!pos.Contains(vector)){
                pos.Add(new Vector3(xpos,0,zpos));
                buttons.Add(Instantiate(obj,vector,Quaternion.identity));
            }
            else {
                i--;
            }

            

        }
        //grabInteractable = GetComponent<XRGrabInteractable>();

        // Add listeners for grab and release events
        //grabInteractable.selectEntered.AddListener(OnGrabbed);  // Correct event
        //grabInteractable.selectExited.AddListener(OnReleased);
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
       
    
    }
    
}