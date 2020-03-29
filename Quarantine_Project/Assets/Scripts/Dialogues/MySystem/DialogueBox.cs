using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DialogueBox : MonoBehaviour
{

    public Text title;
    public Text message;
    public Characters characters;
    public GameObject characterImg;
    public GameObject incomingCharacter;
    public int character_idx;
    private GameObject character;


    private GameObject ChooseCharacter() {

        return characters.characters_list[characters.characters_list.IndexOf(GameObject.FindGameObjectWithTag(incomingCharacter.tag))];
    }

    public void InitiateDialogue() {
        character = ChooseCharacter();
        characterImg.GetComponent<RawImage>().texture = character.GetComponent<RawImage>().texture;
        character_idx = characters.characters_list.IndexOf(GameObject.FindGameObjectWithTag(incomingCharacter.tag));

        title.text = character.GetComponent<Character>().name;
        message.text = character.GetComponent<Character>().dialogue.PrepareMessage().ReadMessage();
    }
    
    // Start is called before the first frame update
    void Start()
    {
        InitiateDialogue();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
