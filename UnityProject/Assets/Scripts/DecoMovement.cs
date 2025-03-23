using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DecoMovement : MonoBehaviour
{
    public int speed;
    public Vector3 pos;
    public int distance;
    private int disbis;

    public Vector3 move;
    // Start is called before the first frame update
    void Start()
    {
        transform.position = pos;
        distance = distance * 100;
        disbis = distance;
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(move * Time.deltaTime * speed);
        distance -= speed;
        if (distance <= 0){
            transform.position = pos;
            distance = disbis;
        }
    }
}
