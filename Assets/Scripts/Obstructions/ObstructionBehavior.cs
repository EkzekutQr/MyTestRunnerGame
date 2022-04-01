using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstructionBehavior : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        other.gameObject.GetComponent<UnitBehavior>().KillUnit();
    }
}
