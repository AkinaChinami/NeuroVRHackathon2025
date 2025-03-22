using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomGen : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject obj;
    public int xmax = 15;
    public int zmax = 15;
    
    List<Vector3> pos = new List<Vector3>();
    void Start()
    {
        int n = Random.Range(1,15);
        for (int i = 0; i< n; i++){
            int xpos = Random.Range(-xmax,xmax);    
            int zpos = Random.Range(-zmax,zmax);
            Vector3 vector = new Vector3(xpos,0,zpos);
            if (!pos.Contains(vector)){
                pos.Add(new Vector3(xpos,0,zpos));
                Instantiate(obj,vector,Quaternion.identity);
            }
            else {
                i--;
            }
            

        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
