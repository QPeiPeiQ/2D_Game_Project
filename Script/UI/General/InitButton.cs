using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class InitButton : MonoBehaviour
{
    GameObject lastButton;
    // Start is called before the first frame update
    void Start()
    {
        if(lastButton == null)
        lastButton = new GameObject();
    }

    // Update is called once per frame
    void Update()
    {
        if (EventSystem.current.currentSelectedGameObject == null)
            EventSystem.current.SetSelectedGameObject(lastButton);
        else
            lastButton = EventSystem.current.currentSelectedGameObject;
    }
}
