using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TextureChooser : MonoBehaviour
{
    public List<Texture> textures;
    [HideInInspector]
    public int counter = 0;



    public Texture chooseTexture() {
        Texture t;
     
        t = textures[counter];

        if (counter < textures.Count-1) {
            counter++;
        } else {
            counter = 0;
        }

        return t;
    }
    void Start()
    {
        
    }

    void Update()
    {
        
    }
}
