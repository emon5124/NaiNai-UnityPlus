using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Score : MonoBehaviour
{
    public GameObject note;
    public int Combo=0;
    void Start()
    {
        this.gameObject.GetComponent<Text>().text = "0";

    }

    // Update is called once per frame
    void Update()
    {
        this.gameObject.GetComponent<Text>().text = Combo.ToString();
    }
}
