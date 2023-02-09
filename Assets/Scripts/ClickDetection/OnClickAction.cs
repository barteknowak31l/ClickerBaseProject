using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class OnClickAction : MonoBehaviour
{

    //functions to be called on click
    public UnityEvent onClickFunctions;
         
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
            callOncClick();
    }

    void callOncClick()
    {
        onClickFunctions.Invoke();
    }
}
