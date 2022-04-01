using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Dreamteck.Splines;

public class PlayerUnitsReplace : MonoBehaviour
{
    [SerializeField] List<GameObject> childs;

    [SerializeField] List<GameObject> childsSpots;

    SplineComputer spline;
    private void Start()
    {
        for (int i = transform.childCount - 1; i >= 0; i--)
        {
            childs.Add(transform.GetChild(i).gameObject);
        }
    }
    public void CreateNewSpot(SplineComputer NewSpline)
    {
        foreach (GameObject item in childsSpots)
        {
            Destroy(item);
        }
        childsSpots.Clear();
        if(spline != null)
        {
            Destroy(spline.gameObject);
        }
        spline = Instantiate(NewSpline, Vector3.zero, Quaternion.identity, transform);
        spline.transform.localScale = new Vector3(0.007f, 0.007f, 0.007f);
        spline.transform.rotation = Quaternion.AngleAxis(90, Vector3.right);
        spline.transform.localPosition = Vector3.zero;

        double distanceBetweenChilds = 1d / childs.Count;

        for (int i = 0; i <= childs.Count - 1; i++)
        {
            childsSpots.Add(new GameObject());
            childsSpots[i].AddComponent<SplineFollower>();
            childsSpots[i].transform.SetParent(transform);
            childsSpots[i].transform.position = Vector3.zero;
        }

        for (int i = 0; i <= childs.Count - 1; i++)
        {
            childsSpots[i].GetComponent<SplineFollower>().spline = spline;
            childsSpots[i].GetComponent<SplineFollower>().enabled = true;
            childsSpots[i].GetComponent<SplineFollower>().SetClipRange(0, distanceBetweenChilds * i);
            childs[i].GetComponent<MoveUnitToSpot>().Spot = childsSpots[i].transform;
        }
    }
}
