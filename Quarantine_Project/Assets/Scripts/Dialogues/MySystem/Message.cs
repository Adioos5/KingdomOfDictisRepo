using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Message : MonoBehaviour
{

    public TextAsset message;

    public List<Option> options;

    public string ReadMessage() {
        string m = message.text;
        return m;
    }


    // Update is called once per frame
    void Update()
    {
        
    }
}
