using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Dialogue : MonoBehaviour
{

    public List<Message> messages;
    public int messageIdx;

    public Message PrepareMessage() {
        Message message = messages[messageIdx]; //!!!
        return message;
    }

    public List<Option> PrepareOptions(Message msg) {
        List<Option> options = msg.options;
        //Upload(options);
        return options;
    }

    //Czy można kliknąć
    public void Upload(List<Option>options) {
        for (int i = 0; i < options.Count; i++) {
            if (options[i].Requirements()) {
                //tu łączymy to z grafiką
            }
        }
    }

    public void SelectOption(int option) {
        switch (option) {


            default:
                break;
        }
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
