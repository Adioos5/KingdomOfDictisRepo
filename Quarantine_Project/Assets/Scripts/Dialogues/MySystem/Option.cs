using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Option : MonoBehaviour
{
    public string text;
    public string id;
    public List<int> requirements_list;
    public Statistics statistics;

    public GameObject dialogueScene;
    public GameObject palaceScene;
    public GameObject queue;
    public GameObject dialogueBox;

    public GameObject knightDialogue;
    public GameObject bishopDialogue;
    public GameObject gentry1Dialogue;
    public GameObject gentry2Dialogue;
    public GameObject countryManDialogue;


    public bool Requirements() {
        for (int i = 0; i < statistics.statistics_list.Count; i++) {
            if (requirements_list[i] > statistics.statistics_list[i]) {
                return false;
            }
        }
        return true;
    }

    public void PerformAction(string id) {
        switch (id) {
            case "B11":
            
                break;

            case "B12":
                GameObject.FindGameObjectWithTag("Bishop").GetComponent<Character>().relations -= 2;
               

                break;

            case "K11":
                knightDialogue.GetComponent<Dialogue>().messageIdx += 1;
                break;

            case "K21":
             
                break;

            default:
  
                break;
        }

        dialogueBox.GetComponent<OnButtonClick>().DestroyOptions();
        dialogueScene.SetActive(false);
        palaceScene.SetActive(true);
        queue.GetComponent<Lieges>().lieges_list[0].GetComponent<LiegesMovement>().pause = false;
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
