using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class D : MonoBehaviour
{
    GameObject cubcreate;
    public float presstimed;
    public bool keeppressd = true;
    // Start is called before the first frame update
    void Start()
    {
        cubcreate = GameObject.Find("cubecreat");
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown("d"))
        {
            this.GetComponent<SpriteRenderer>().material.color = new Color((0 / 225), (0 / 225), (0 / 225), (225 / 225));
            presstimed = cubcreate.GetComponent<cubcreat>().songPosition;
            keeppressd = true;

        }
        if (Input.GetKeyUp("d"))
        {
            this.GetComponent<SpriteRenderer>().material.color = new Color((225 / 225), (225 / 225), (225 / 225), (225 / 225));
            keeppressd = false;
        }
    }
}
