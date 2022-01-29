using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeMaterial : MonoBehaviour
{
    public MovePlayer movePlayer;
    public Material InitialMaterial;
    public Material SwitchedMaterial;
    Renderer rend;
    public bool isCorrupt = false;

    // Start is called before the first frame update
    void Start()
    {
        rend = GetComponent<Renderer>();
        rend.enabled = true;
        rend.sharedMaterial = InitialMaterial;

    }

    private void OnCollisionEnter(Collision col)
    {
        if (!isCorrupt && col.gameObject.tag == "Ball")
        {
            StartCoroutine(colorObjectOverTime(10));
            isCorrupt = true;
        }   
    }

    IEnumerator colorObjectOverTime(float duration)
    {
         //set color
         rend.sharedMaterial = SwitchedMaterial;
         yield return new WaitForSeconds(duration);
         //reset color
         rend.sharedMaterial = InitialMaterial;
         isCorrupt = false;
    }

}