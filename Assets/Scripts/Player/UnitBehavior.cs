using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnitBehavior : MonoBehaviour
{
    
    public void KillUnit()
    {
        transform.parent.GetComponent<ParticleSystem>().Play();
        gameObject.GetComponent<SkinnedMeshRenderer>().enabled = false;
        transform.parent.SetParent(null);
        transform.parent.GetComponent<MoveUnitToSpot>().enabled = false;
        transform.parent.GetComponent<MoveUnitToSpot>().IsAlive = false;
        Invoke(null, 3);
        Destroy(transform.gameObject);
    }
}
