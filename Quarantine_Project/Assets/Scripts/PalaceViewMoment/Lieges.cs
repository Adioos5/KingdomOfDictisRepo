using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Lieges : MonoBehaviour
{
    public List<GameObject> lieges_list;
    public TextureChooser textureChooser;
    private float firstPosX;
    private float secondPosX;
    private float distance;

 
    // Start is called before the first frame update
    void Start()
    {
        firstPosX = lieges_list[0].GetComponent<LiegesMovement>().transform.position.x;
        secondPosX = lieges_list[1].GetComponent<LiegesMovement>().transform.position.x;

        distance = secondPosX - firstPosX;
        lieges_list[0].GetComponent<LiegesMovement>().isReady = true;
    }

    // Update is called once per frame
    void Update() {
        
    }
    public void MoveQueue() {
        for(int i = 1; i < lieges_list.Count; i++) {
            lieges_list[i].transform.Translate(-distance, 0, 0);
        }
    }

    public void Append_Liege(GameObject g) {
        Destroy(g);
        lieges_list.RemoveAt(0);
        GameObject n = InstantiateGameObject();
        lieges_list.Add(n);
    }

    private GameObject InstantiateGameObject() {
        GameObject x = lieges_list[lieges_list.Count - 1];

        GameObject n = Instantiate(x) as GameObject;

        switch (textureChooser.counter) {
            case 0:
                n.tag = "Bishop";
                break;
            case 1:
                n.tag = "Knight";
                break;
            case 2:
                n.tag = "Gentry1";
                break;
            case 3:
                n.tag = "CountryMan";
                break;
            case 4:
                n.tag = "Gentry2";
                break;
            default:
                break;
        }

        n.GetComponent<RawImage>().texture = textureChooser.chooseTexture();
        n.transform.SetParent(transform, false);

        n.transform.localPosition = x.transform.localPosition;
        n.transform.Translate(distance, 0, 0);
        
      

        return n;
    }
}
