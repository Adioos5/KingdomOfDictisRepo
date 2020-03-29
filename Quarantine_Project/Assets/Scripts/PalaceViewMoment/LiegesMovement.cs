using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LiegesMovement : MonoBehaviour
{
    private GameObject liege;
    public GameObject king;
    public GameObject lieges;
    private List<GameObject> lieges_list;
    public GameObject dialogueScene;
    public GameObject palaceScene;

    public GameObject cam1;
    public GameObject cam2;

    public GameObject onLiegeView;
    public GameObject onKingView;

    public GameObject incomingCharacter;

    public GameObject dialogueBox;


    private bool play = false;
    public bool pause = true;
    public bool isReady = false;
    private bool keyHit = false;
    private float speed = -300;
    private int counter = 0;
    
    

    void Start() {
        liege = transform.gameObject;
    }

    void Update() {
        
        if(isReady) HandleLiegeMovement();
        

    }

    private void HandleLiegeMovement() {

        if (Input.GetKeyDown(KeyCode.A)) {
            play = true;
            pause = false;
        }

        //Towards king
        if (counter == 0) { 

            if (play && !pause) {
                if (liege.transform.position.x > king.transform.position.x) {
                    liege.transform.position = new Vector2(liege.transform.position.x + speed * Time.smoothDeltaTime, liege.transform.position.y);
                } else {
                    pause = true;
                    lieges.GetComponent<Lieges>().MoveQueue();
                    counter = 1;

                    incomingCharacter.tag = transform.tag;

                    dialogueScene.SetActive(true);
                    palaceScene.SetActive(false);

                    cam1.SetActive(true);
                    cam2.SetActive(false);
                    onLiegeView.SetActive(true);
                    onKingView.SetActive(false);

                    dialogueBox.GetComponent<DialogueBox>().InitiateDialogue();
                }
            }
        } else if (counter == 1 && liege.transform.position.x <= king.transform.position.x) {
         
            if (play && !pause) {
                if (-30 <= liege.transform.position.x) {
                    liege.transform.position = new Vector2(liege.transform.position.x + speed * Time.smoothDeltaTime, liege.transform.position.y);
                } else {
                    pause = true;
                    counter = 2;
                    lieges.GetComponent<Lieges>().lieges_list[1].GetComponent<LiegesMovement>().isReady = true;
                    lieges.GetComponent<Lieges>().lieges_list[1].GetComponent<LiegesMovement>().play = true;
                    lieges.GetComponent<Lieges>().lieges_list[1].GetComponent<LiegesMovement>().pause = false;
                    lieges.GetComponent<Lieges>().Append_Liege(liege);
                    
                }
            }
        }
    }
}
