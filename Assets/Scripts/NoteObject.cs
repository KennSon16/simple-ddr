using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NoteObject : MonoBehaviour
{
    public bool canBePressed;
    public KeyCode keyToPress;
    public GameObject hitEffect, goodEffect, perfectEffect, missEffect;
    public Vector3 effectPosition;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(keyToPress))
        {
            if(canBePressed)
            {
                effectPosition = transform.position;
                effectPosition.x = 0;
                gameObject.SetActive(false);
                //GameManager.instance.noteHit();

                if(Mathf.Abs(transform.position.y) > 0.25) {
                    Debug.Log("Hit");
                    effectPosition.y = 3;
                    GameManager.instance.NormalHit();
                    Instantiate(hitEffect, effectPosition, hitEffect.transform.rotation);
                } else if (Mathf.Abs(transform.position.y) > 0.05f) {
                    Debug.Log("Good");
                    effectPosition.y = 4;
                    GameManager.instance.GoodHit();
                    Instantiate(goodEffect, effectPosition, goodEffect.transform.rotation);
                } else {
                    Debug.Log("Perfect");
                    effectPosition.y = 5;
                    GameManager.instance.PerfectHit();
                    Instantiate(perfectEffect, effectPosition, perfectEffect.transform.rotation);
                }

            }
        }
    }

   void OnTriggerEnter2D(Collider2D other)
    {
        if(other.tag == "Activator")
        {
            canBePressed = true;
        }
    }
    void OnTriggerExit2D(Collider2D other)
    {
        if (gameObject.active) 
        { 
            if (other.tag == "Activator")
            {
                canBePressed = false;
                GameManager.instance.noteMiss();
                Instantiate(missEffect, effectPosition, missEffect.transform.rotation);
            }
        }
    }

}
