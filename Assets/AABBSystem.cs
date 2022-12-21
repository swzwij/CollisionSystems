using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AABBSystem : MonoBehaviour
{
    private List<AABBCollider> _AABBColliders = new List<AABBCollider>();

    private void Awake()
    {
        AABBCollider[] AABBColliders = FindObjectsOfType<AABBCollider>();

        foreach (var collider in AABBColliders)
        {
            _AABBColliders.Add(collider);
        }
    }

    private void Update()
    {
        int l = _AABBColliders.Count;
        for (int i = 0; i < l; i++)
        {
            AABBCollider currentCollider = _AABBColliders[i];

            for (int j = 0; j < l; j++)
            {
                AABBCollider comparedCollider = _AABBColliders[j];

                if (currentCollider == comparedCollider) continue;
                if (!AABBIntersection(currentCollider, comparedCollider))
                {
                    if (currentCollider.isColliding && currentCollider.updateEvents) currentCollider.OnAABBCollisionExit();
                    currentCollider.isColliding = false;
                    continue;
                }

                if (!currentCollider.updateEvents) continue;

                if(currentCollider.isColliding)
                {
                    currentCollider.OnAABBCollisionStay();
                }
                else
                {
                    currentCollider.OnAABBCollisionEnter();
                }

            }
        }
    }

    private bool AABBIntersection(AABBCollider a, AABBCollider b)
    {
        // X axis
        if (a._minPos.x > b._maxPos.x) return false;
        if (a._maxPos.x < b._minPos.x) return false;

        // Y axis
        if (a._minPos.y > b._maxPos.y) return false;
        if (a._maxPos.y < b._minPos.y) return false;

        return true;
    }
}
