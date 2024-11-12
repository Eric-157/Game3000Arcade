using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Button : MonoBehaviour
{
    public GameObject objectToInteract;
    public bool isOpen = false;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (isOpen == true)
        {
            objectToInteract.SetActive(false);
        }
        else
        {
            objectToInteract.SetActive(true);
        }
    }

    private void OnCollisionEnter(Collision other)
    {
        isOpen = true;
    }

    private void OnCollisionExit(Collision other)
    {
        isOpen = false;
    }
}
