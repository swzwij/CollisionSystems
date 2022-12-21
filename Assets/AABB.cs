using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class AABB : MonoBehaviour
{
    [SerializeField] private Vector2 size;

    private float xMinPos;
    private float xMaxPos;
    private float yMinPos;
    private float yMaxPos;

    public AABB otherBox;

    private Color defaultColor = Color.green;

    private void Update()
    {
        UpdateSize();
        if (AABBIntersection(this, otherBox))
        {
            print("Collide");
            defaultColor = Color.red;
        }
        else
        {
            defaultColor = Color.green;
        }
    }

    private bool AABBIntersection(AABB a, AABB b)
    {
        if (a.xMinPos > b.xMaxPos) return false;
        if (a.xMaxPos < b.xMinPos) return false;

        if (a.yMinPos > b.yMaxPos) return false;
        if (a.yMaxPos < b.yMinPos) return false;

        return true;
    }

    private void UpdateSize()
    {
        yMinPos = transform.position.y;
        xMinPos = transform.position.x;

        xMaxPos = transform.position.x + size.x;
        yMaxPos = transform.position.y + size.y;
    }

    private void OnDrawGizmos()
    {
        Vector2 pos = transform.position;

        Gizmos.color = defaultColor;

        // Main lines
        Gizmos.DrawLine(pos, pos + new Vector2(0, size.y));
        Gizmos.DrawLine(pos, pos + new Vector2(size.x, 0));

        // Fill Lines
        Gizmos.DrawLine(pos + new Vector2(0, size.y), pos + new Vector2(size.x, size.y));
        Gizmos.DrawLine(pos + new Vector2(size.x, 0), pos + new Vector2(size.x, size.y));
    }
}
