using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Teleportation : MonoBehaviour
{
    public Transform player;
    public Transform stage1;
    public Transform stage2;
    public Transform stage3;

    public void TeleportationStage1()
    {
        player.transform.position = stage1.transform.position;
        Debug.Log("Stage 1");
    }

    public void TeleportationStage2()
    {
        player.transform.position = stage2.transform.position;
        Debug.Log("Stage 2");
    }

    public void TeleportationStage3()
    {
        player.transform.position = stage3.transform.position;
        Debug.Log("Stage 3");
        
    }

}
