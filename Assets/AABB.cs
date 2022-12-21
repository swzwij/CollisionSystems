using UnityEngine;
using UnityEngine.Events;
using UnityEngine.Profiling;

public class AABB : MonoBehaviour
{
    private Vector2 _size => _AABBCollider.colliderSize;
    public Vector2 _minPos;
    public Vector2 _maxPos;
    
    [SerializeField] private AABB otherBox;
    private AABBCollider _AABBCollider;

    [SerializeField] private UnityEvent onStay = new UnityEvent();

    private void Awake()
    {
        _AABBCollider= GetComponent<AABBCollider>();
    }

    private void Update()
    {
        Profiler.BeginSample("AHAHAHA");
        UpdateSize();

        if (AABBIntersection(this, otherBox))
        {
            print("COlliding");
            onStay?.Invoke();
        }

        Profiler.EndSample();
    }

    private bool AABBIntersection(AABB a, AABB b)
    {
        // X axis
        if (a._minPos.x > b._maxPos.x) return false;
        if (a._maxPos.x < b._minPos.x) return false;

        // Y axis
        if (a._minPos.y > b._maxPos.y) return false;
        if (a._maxPos.y < b._minPos.y) return false;

        return true;
    }

    private void UpdateSize()
    {
        // X position
        _minPos.x = transform.position.x;
        _maxPos.x = transform.position.x + _size.x;

        // Y position
        _minPos.y = transform.position.y;
        _maxPos.y = transform.position.y + _size.y;
    }
}
