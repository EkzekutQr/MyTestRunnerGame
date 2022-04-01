using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Dreamteck.Splines;
using UnityEngine.UI;

public class Drawing : MonoBehaviour
{
    [SerializeField] SplineComputer brushPrefab;

    [SerializeField] float brushSize = 0.01f;

    [SerializeField] Camera uICamera;

    private SplineComputer brush;

    [SerializeField] PlayerUnitsReplace playerUnits;

    public void CreateBrush()
    {
        if (brush != null)
        {
            Destroy(brush.gameObject);
        }
        SplineComputer newBrush = Instantiate(brushPrefab, Vector3.zero, Quaternion.identity, transform);
        newBrush.transform.localPosition = Vector3.zero;
        brush = newBrush;
    }
    public void Draw()
    {
        Vector2 localPosition;
        RectTransformUtility.ScreenPointToLocalPointInRectangle(gameObject.GetComponent<RectTransform>(), Input.GetTouch(0).position, uICamera, out localPosition);
        brush.SetPoint(brush.pointCount, new SplinePoint(new Vector3(localPosition.x, localPosition.y, 0), new Vector3(localPosition.x, localPosition.y, 0),
            new Vector3(0, 1, 0), brushSize, Color.black), SplineComputer.Space.Local);
    }
    public void EndDraw()
    {
        playerUnits.CreateNewSpot(brush);
    }
}
