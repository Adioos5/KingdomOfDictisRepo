using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class TextHover : MonoBehaviour, IPointerDownHandler,IPointerEnterHandler, IPointerExitHandler {

    private Text theText;
    

    public void OnPointerDown(PointerEventData eventData) {
         transform.GetComponent<Option>().PerformAction(transform.GetComponent<Option>().id);
         
    }

    public void OnPointerEnter(PointerEventData eventData) {
        theText.color = Color.red; 
    }

    public void OnPointerExit(PointerEventData eventData) {
        theText.color = Color.white; 
    }
    // Start is called before the first frame update
    void Start()
    {
        theText = transform.GetComponent<Text>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
