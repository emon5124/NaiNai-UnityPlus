using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class F : MonoBehaviour
{
    // Start is called before the first frame update
    GameObject cubcreate;
    public float presstimef;
    public bool keeppressf = true;
    void Start()
    {
        cubcreate = GameObject.Find("cubecreat");
    }

    // Update is called once per frame
    void Update()
    {
        
        if (Input.GetKeyDown("f"))
        {
            this.GetComponent<SpriteRenderer>().material.color = new Color((0 / 225), (0 / 225), (0 / 225), (225 / 225));
            presstimef = cubcreate.GetComponent<cubcreat>().songPosition;
            keeppressf = true;

        }
        if (Input.GetKeyUp("f"))
        {
            this.GetComponent<SpriteRenderer>().material.color = new Color((225 / 225), (225 / 225), (225 / 225), (225 / 225));
            keeppressf = false;
        }
    }
}
