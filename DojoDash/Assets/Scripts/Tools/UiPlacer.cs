using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
/// <summary>
/// UI objects have to be a child of a canvas with a RenderMode set to World Space
/// </summary>
public class UiPlacer : MonoBehaviour {

    public Transform target;
    public Vector2 Offset;
    public RectTransform rectTransoform;

    private Vector3 offset;

    private void Awake()
    {
        rectTransoform = GetComponent<RectTransform>();
        SetOffset();
    }

	void LateUpdate() {
        SetOffset();
        SetPos();
    }

    // Converts the offset vector to a vector3
    public void SetOffset()
    {
        offset = new Vector3(Offset.x, Offset.y, 0);
    }

    // Places the UI object at the right position
    public void SetPos()
    {
        Vector3 newPos = (target.position) + offset;
        rectTransoform.SetPositionAndRotation(newPos, rectTransoform.rotation);
    }
}
