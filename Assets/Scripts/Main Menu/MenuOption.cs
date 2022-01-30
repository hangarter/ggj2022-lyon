using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuOption : MonoBehaviour
{
    public GameObject fireIcon;
    public GameObject iceIcon;

    public void Select()
    {
        fireIcon.SetActive(true);
        iceIcon.SetActive(true);
    }

    public void Deselect()
    {

        fireIcon.SetActive(false);
        iceIcon.SetActive(false);
    }
}
