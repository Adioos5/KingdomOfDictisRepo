using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Options : MonoBehaviour
{
    public TextAsset optionsText;
    public TextAsset requirementsText;
    public GameObject go;
    public GameObject parent;


    public Statistics statistics_r;

    private List<string> options_r = new List<string>();

    private List< List<int> > requirements_r = new List< List<int> >();

    private string createId(string n, string m) {
        return n + m;
    }

    private void MakeOptionsList() {
        string [] o = optionsText.text.Split('\n');
        foreach (string line in o){
            options_r.Add(line);
        }

        string[] r = requirementsText.text.Split('\n');
        for(int i = 0;i<r.Length;i++) {

            requirements_r.Add(new List<int>());
            string[] nums = r[i].Split(' ');
            

            for (int j = 0; j < nums.Length; j++) {
         
                int n;
                if(Int32.TryParse(nums[j],out n))requirements_r[i].Add(Convert.ToInt32(nums[j]));
            }
        }

        for (int k = 0; k < options_r.Count; k++) {
            GameObject opt = Instantiate(go) as GameObject;

            opt.transform.SetParent(transform, false);
            opt.AddComponent<Option>();
            opt.GetComponent<Option>().text = options_r[k];
            opt.GetComponent<Option>().requirements_list = requirements_r[k];
            opt.GetComponent<Option>().statistics = statistics_r;
            opt.GetComponent<Option>().id = createId(transform.parent.tag , (k+1).ToString());
            opt.GetComponent<Option>().dialogueScene = GameObject.FindGameObjectWithTag("ITK").GetComponent<ImportantThingsKeeper>().dialogueScene;
            opt.GetComponent<Option>().palaceScene = GameObject.FindGameObjectWithTag("ITK").GetComponent<ImportantThingsKeeper>().palaceScene;
            opt.GetComponent<Option>().queue = GameObject.FindGameObjectWithTag("ITK").GetComponent<ImportantThingsKeeper>().queue;
            opt.GetComponent<Option>().dialogueBox = GameObject.FindGameObjectWithTag("ITK").GetComponent<ImportantThingsKeeper>().dialogueBox;

            opt.GetComponent<Option>().knightDialogue = GameObject.FindGameObjectWithTag("ITK").GetComponent<ImportantThingsKeeper>().knightDialogue;
            opt.GetComponent<Option>().bishopDialogue = GameObject.FindGameObjectWithTag("ITK").GetComponent<ImportantThingsKeeper>().bishopDialogue;
            opt.GetComponent<Option>().gentry1Dialogue = GameObject.FindGameObjectWithTag("ITK").GetComponent<ImportantThingsKeeper>().gentry1Dialogue;
            opt.GetComponent<Option>().gentry2Dialogue = GameObject.FindGameObjectWithTag("ITK").GetComponent<ImportantThingsKeeper>().gentry2Dialogue;
            opt.GetComponent<Option>().countryManDialogue = GameObject.FindGameObjectWithTag("ITK").GetComponent<ImportantThingsKeeper>().countryManDialogue;

            parent.GetComponent<Message>().options.Add(opt.GetComponent<Option>()); //!!!!!
        }

    }

    // Start is called before the first frame update
    void Start()
    {
        MakeOptionsList();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
