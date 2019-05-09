using UnityEngine;

public class ScaleLimitVisualizer : MonoBehaviour {

    public Vector3 scaleLimit = new Vector3(4, 5, 3);

    public bool isWireFrame = true;

    void OnDrawGizmos()
    {
        var pos = transform.position + new Vector3(0, (float)(scaleLimit.y / 2.0), 0);

        if (isWireFrame)
        {
            Gizmos.color = Color.yellow;
            Gizmos.DrawWireCube(pos, scaleLimit);
        }

        else
        {
            Gizmos.color = new Color(1, 1, 0, 0.8f);
            Gizmos.DrawCube(pos, scaleLimit);
        }     
    }
}
