using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class K : MonoBehaviour
{
    GameObject cubcreate;
    public float presstimek;
    public bool keeppressk = true;
    // Start is called before the first frame update
    void Start()
    {
        cubcreate = GameObject.Find("cubecreat");
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown("k"))
        {
            this.GetComponent<SpriteRenderer>().material.color = new Color((0 / 225), (0 / 225), (0 / 225), (225 / 225));
            presstimek = cubcreate.GetComponent<cubcreat>().songPosition;
            keeppressk = true;

        }
        if (Input.GetKeyUp("k"))
        {
            this.GetComponent<SpriteRenderer>().material.color = new Color((225 / 225), (225 / 225), (225 / 225), (225 / 225));
            keeppressk = false;
        }
    }
}
