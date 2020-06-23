using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JKey : MonoBehaviour
{
    // Start is called before the first frame update
    GameObject cubcreate;

    public float presstimej;
    public bool keeppressj = true;
    void Start()
    {
        cubcreate = GameObject.Find("cubecreat");
    }

    // Update is called once per frame
    void Update()
    {

        if (Input.GetKeyDown("j"))
        {
            this.GetComponent<SpriteRenderer>().material.color = new Color((0 / 225), (0 / 225), (0 / 225), (225 / 225));
            presstimej = cubcreate.GetComponent<cubcreat>().songPosition;
            keeppressj = true;

        }
        if (Input.GetKeyUp("j"))
        {
            this.GetComponent<SpriteRenderer>().material.color = new Color((225 / 225), (225 / 225), (225 / 225), (225 / 225));
            keeppressj = false;
        }
    }
}
