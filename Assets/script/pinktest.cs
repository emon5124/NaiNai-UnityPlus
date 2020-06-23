using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pinktest : MonoBehaviour
{
    public Material[] materials;
    Renderer rend;
    // Start is called before the first frame update
    void Start()
    {
        rend = GetComponent<Renderer>();
        rend.enabled = true;
        rend.sharedMaterial = materials[1];
    }

    // Update is called once per frame
    void Update()
    {
        rend.sharedMaterial = materials[1];
    }
}
