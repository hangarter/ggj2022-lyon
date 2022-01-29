using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeMaterial : MonoBehaviour
{

    public Material InitialMaterial;
    public Material SwitchedMaterial;
    Renderer rend;
    private float currentTime = 0f;
    private float startingTime = 3f;
    bool neverDone = false;

    // Start is called before the first frame update
    void Start()
    {
        rend = GetComponent<Renderer>();
        rend.enabled = true;
        rend.sharedMaterial = InitialMaterial;
        currentTime = startingTime;
    }


    private void OnCollisionEnter(Collision col)
    {
        if (col.gameObject.tag == "Ball")
        {
            StartCoroutine(colorObjectOverTime(10));
            neverDone = true;
        }

    }

    IEnumerator colorObjectOverTime(float duration)
    {
        //set color
        rend.sharedMaterial = SwitchedMaterial;
        yield return new WaitForSeconds(duration);
        //reset color
        rend.sharedMaterial = InitialMaterial;
        neverDone = false;
    }
}


