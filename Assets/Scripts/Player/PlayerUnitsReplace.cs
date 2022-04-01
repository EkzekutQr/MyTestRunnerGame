using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Dreamteck.Splines;

public class PlayerUnitsReplace : MonoBehaviour
{
    [SerializeField] List<GameObject> childs;

    [SerializeField] List<GameObject> childsSpots;

    [SerializeField] GameObject spot;

    SplineComputer spline;
    private void Start()
    {
        for (int i = transform.childCount - 1; i >= 0; i--)
        {
            childs.Add(transform.GetChild(i).gameObject);
        }
    }
    void DestroyOldGameObjects()
    {
        foreach (GameObject item in childsSpots)
        {
            Destroy(item);
        }
        childsSpots.Clear();

        for (int i = 0; i <= childs.Count - 1; i++)
        {
            if (childs[i].GetComponent<MoveUnitToSpot>().IsAlive == false)
            {
                childs[i] = null;
            }
            if (childs[i] == null)
            {
                childs.Remove(childs[i]);
            }
        }

        if (spline != null)
        {
            Destroy(spline.gameObject);
        }
    }
    public void CreateNewSpot(SplineComputer NewSpline)
    {
        DestroyOldGameObjects();

        spline = Instantiate(NewSpline, Vector3.zero, Quaternion.identity, transform);
        spline.transform.localScale = new Vector3(0.007f, 0.007f, 0.007f);
        spline.transform.rotation = Quaternion.AngleAxis(90, Vector3.right);
        spline.transform.localPosition = Vector3.zero;

        double distanceBetweenChilds = 1d / childs.Count;

        for (int i = 0; i <= childs.Count - 1; i++)
        {
            GameObject newSpot = Instantiate(spot, Vector3.zero, Quaternion.identity, transform);
            newSpot.GetComponent<SplineFollower>().spline = spline;
            newSpot.GetComponent<SplineFollower>().SetClipRange(0, distanceBetweenChilds * i);
            childs[i].GetComponent<MoveUnitToSpot>().Spot = newSpot.transform;
            childsSpots.Add(newSpot);
        }
    }
}
