using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveUnitToSpot : MonoBehaviour
{
    Transform spot;
    [SerializeField] float speed = 1;

    public Transform Spot { get => spot; set => spot = value; }

    private bool isLive = true;
    public bool IsAlive { get => isLive; set => isLive = value; }

    void FixedUpdate()
    {
        if(spot != null)
        {
            transform.position = Vector3.MoveTowards(transform.position, spot.position, speed * Time.deltaTime);
        }
    }
}
