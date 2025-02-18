using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public class MapPoint : MonoBehaviour
{
    public MapPoint up;
    public MapPoint down;
    public MapPoint right;
    public MapPoint left;
    public LayerMask point;


    private void Start()
    {
        Find();
    }

    public void Find()
    {
        up = null;
        down = null;
        left = null;
        right = null;
        RaycastHit hit;
        if (Physics.Raycast(transform.position, Vector3.forward, out hit, Mathf.Infinity, point)) up = hit.collider.GetComponent<MapPoint>();
        if (Physics.Raycast(transform.position, -Vector3.forward, out hit, Mathf.Infinity, point)) down = hit.collider.GetComponent<MapPoint>();
        if (Physics.Raycast(transform.position, Vector3.right, out hit, Mathf.Infinity, point)) right = hit.collider.GetComponent<MapPoint>();
        if (Physics.Raycast(transform.position, Vector3.left, out hit, Mathf.Infinity, point)) left = hit.collider.GetComponent<MapPoint>();

    }

}

#if UNITY_EDITOR
[CustomEditor(typeof(MapPoint)), CanEditMultipleObjects]
public class Map_LineEditor : Editor
{
    public override void OnInspectorGUI()
    {
        base.OnInspectorGUI();
        MapPoint myScript = (MapPoint)target;
        if (GUILayout.Button("Find Path"))
        {
            myScript.Find();
        }
    }
}
#endif
