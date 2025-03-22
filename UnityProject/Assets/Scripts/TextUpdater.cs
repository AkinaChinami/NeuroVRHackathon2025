using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class TextUpdater : MonoBehaviour
{
    public TextMeshProUGUI txt;
    // Start is called before the first frame update
    void Start()
    {
        txt.text = "Hello World";
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            txt.text = "Space key pressed!";
        }
    }
}
