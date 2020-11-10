using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputManager : MonoBehaviour
{

    public GameObject NPC;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown("space"))
        {
            NPC.GetComponent<NPC>().TakeDamage(10);
        }
    }
}
