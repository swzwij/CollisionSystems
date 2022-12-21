using UnityEngine;
using UnityEngine.Events;

public class AABBCollider : MonoBehaviour
{
    public Vector2 colliderSize = Vector2.one;

    [HideInInspector] public Vector2 _minPos;
    [HideInInspector] public Vector2 _maxPos;
    [HideInInspector] public bool isColliding;

    private Vector2 pos;
    private Color color = Color.green;

    [Header("Collision Events")]
    public bool updateEvents = true;
    [SerializeField] private UnityEvent onAABBEnter = new UnityEvent();
    [SerializeField] private UnityEvent onAABBExit = new UnityEvent();
    [SerializeField] private UnityEvent onAABBStay = new UnityEvent();

    private void Awake()
    {
        pos = transform.position;
        pos -= colliderSize / 2;
    }

    private void Update()
    {
        // X position
        _minPos.x = pos.x;
        _maxPos.x = pos.x + colliderSize.x;

        // Y position
        _minPos.y = pos.y;
        _maxPos.y = pos.y + colliderSize.y;
    }

    public void OnAABBCollisionEnter()
    {
        isColliding = true;
        onAABBEnter?.Invoke();
        print("OnCollisionEnter");
    }

    public void OnAABBCollisionExit()
    {
        onAABBExit?.Invoke();
        print("OnCollisionExit");
    }

    public void OnAABBCollisionStay()
    {
        onAABBStay?.Invoke();
        print("OnCollisionStay");
    }

    private void OnDrawGizmos()
    {
        pos = transform.position;
        pos -= colliderSize / 2;

        Gizmos.color = color;

        // Main lines
        Gizmos.DrawLine(pos, pos + new Vector2(0, colliderSize.y));
        Gizmos.DrawLine(pos, pos + new Vector2(colliderSize.x, 0));

        // Fill Lines
        Vector2 toPos = pos + new Vector2(colliderSize.x, colliderSize.y);
        Gizmos.DrawLine(pos + new Vector2(0, colliderSize.y), toPos);
        Gizmos.DrawLine(pos + new Vector2(colliderSize.x, 0), toPos);
    }
}
