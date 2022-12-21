using UnityEngine;

public class AABBCollider : MonoBehaviour
{
    public Vector2 colliderSize;

    [HideInInspector] public Vector2 _minPos;
    [HideInInspector] public Vector2 _maxPos;

    private void Update()
    {
        // X position
        _minPos.x = transform.position.x;
        _maxPos.x = transform.position.x + colliderSize.x;

        // Y position
        _minPos.y = transform.position.y;
        _maxPos.y = transform.position.y + colliderSize.y;
    }

    private void OnDrawGizmos()
    {
        Vector2 pos = transform.position;

        Gizmos.color = Color.green;

        // Main lines
        Gizmos.DrawLine(pos, pos + new Vector2(0, colliderSize.y));
        Gizmos.DrawLine(pos, pos + new Vector2(colliderSize.x, 0));

        // Fill Lines
        Vector2 toPos = pos + new Vector2(colliderSize.x, colliderSize.y);
        Gizmos.DrawLine(pos + new Vector2(0, colliderSize.y), toPos);
        Gizmos.DrawLine(pos + new Vector2(colliderSize.x, 0), toPos);
    }
}
