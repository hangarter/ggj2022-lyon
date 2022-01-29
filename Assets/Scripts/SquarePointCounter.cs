using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class SquarePointCounter : MonoBehaviour
{
    public delegate void NotifyPointScored(FloorType floorType);

    public enum FloorType
    {
        Ice,
        Lava
    }
    public FloorType floorType;

    public event NotifyPointScored OnPointScored;

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.tag.Equals("Ball"))
        {
            if(OnPointScored != null)
            {
                OnPointScored(floorType);
            }
        }
    }

}
