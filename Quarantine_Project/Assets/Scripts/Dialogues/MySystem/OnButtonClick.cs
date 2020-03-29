using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class OnButtonClick : MonoBehaviour
{
    public GameObject cam1;
    public GameObject cam2;
    public GameObject onLiegeView;
    public GameObject onKingView;
    public GameObject go;

    private List<Option> options;
    private List<GameObject> textOptions = new List<GameObject>();

    public void OpenOptionsWindow() {
        cam1.SetActive(false);
        onLiegeView.SetActive(false);

        cam2.SetActive(true);
        onKingView.SetActive(true);

        AddOptions(); 
        
    }

    public void DestroyOptions() {
        
        for(int i = 0; i < textOptions.Count; i++) {
            Destroy(textOptions[i]);
        }
    }

    private void AddOptions() {


        //Stworzenie listy opcji z danej wiadomosci...
        //TUTAJ ZMIANA VV!
        options =
        transform.GetComponent<DialogueBox>().characters.characters_list[transform.GetComponent<DialogueBox>().character_idx].GetComponent<Character>()
            .dialogue.PrepareOptions(transform.GetComponent<DialogueBox>().characters.characters_list[transform.GetComponent<DialogueBox>().character_idx].GetComponent<Character>()
            .dialogue.PrepareMessage());

        float startY = go.transform.position.y;
        float actualY = startY;
        float dist = 40f;

        for (int i = 0; i < options.Count; i++) {
            GameObject option = Instantiate(go) as GameObject;
            

            option.transform.SetParent(go.transform.parent, false);
            option.AddComponent<Option>();

            option.GetComponent<Text>().text = options[i].text;
            option.GetComponent<Option>().requirements_list = options[i].requirements_list;
            option.GetComponent<Option>().id = options[i].id;
            option.GetComponent<Option>().dialogueScene = options[i].dialogueScene;
            option.GetComponent<Option>().palaceScene = options[i].palaceScene;
            option.GetComponent<Option>().queue = options[i].queue;
            option.GetComponent<Option>().dialogueBox = options[i].dialogueBox;

            option.GetComponent<Option>().knightDialogue = options[i].knightDialogue;
            option.GetComponent<Option>().bishopDialogue = options[i].bishopDialogue;
            option.GetComponent<Option>().countryManDialogue = options[i].countryManDialogue;
            option.GetComponent<Option>().gentry2Dialogue = options[i].gentry2Dialogue;
            option.GetComponent<Option>().gentry1Dialogue = options[i].gentry1Dialogue;

            option.transform.position = new Vector2(option.transform.position.x,actualY);

            textOptions.Add(option);

            actualY -= dist;
        }


    }

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
