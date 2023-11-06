using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wings : MonoBehaviour
{
    public bool FlyingWings = false;
    GameObject[] wings;
    // Start is called before the first frame update
    void Start()
    {
        GameObject[] obj = GameObject.FindGameObjectsWithTag("Wing");
        wings = obj;
    }

    // Update is called once per frame
    void Update()
    {
        if (FlyingWings)
        {
            foreach (var wing in wings)
            {
                wing.SetActive(true);
            }
        } else
        {
            foreach (var wing in wings)
            {
                wing.SetActive(false);
            }
        }
    }
}
