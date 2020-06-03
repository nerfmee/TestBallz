using UnityEngine;

public class LaunchPreview : MonoBehaviour
{
    private LineRenderer lineRenderer;
    private Vector3 dragStartPoint;

    private void Awake()
    {
        lineRenderer = GetComponent<LineRenderer>();
    }

    public void SetStartPoint(Vector3 worldPoint)
    {
        dragStartPoint = worldPoint;
        lineRenderer.SetPosition(0, dragStartPoint);
    }

    public void SetEndPoint(Vector3 worldPoint)
    {
        Vector3 limit = Vector3.zero;
        
        Vector3 pointOffset = worldPoint - dragStartPoint;
       // Debug.Log(pointOffset);
        Vector3 endPoint = transform.position + pointOffset;
        if (pointOffset.y >= -0.1f)
        {
            pointOffset.y = -0.1f;
        //    Debug.Log(pointOffset);
            lineRenderer.SetPosition(1, endPoint);
        }
        
        
        
    }
}
