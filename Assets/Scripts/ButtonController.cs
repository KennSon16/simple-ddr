using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonController : MonoBehaviour
{
    private SpriteRenderer theSR; // Accesses the image shown on screen so that we can change what it looks like on screen. 
    public Sprite defaultImage; //Image when button isn't pressed
    public Sprite pressedImage; //Image when button is pressed

    public KeyCode keytoPress; //The key to press 

    // Start is called before the first frame update
    void Start()
    {
        theSR = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(keytoPress))
        {
            theSR.sprite = pressedImage;
        }

        if(Input.GetKeyUp(keytoPress))
        {
            theSR.sprite = defaultImage;
        }
    }
}
