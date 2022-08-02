using UnityEngine;

public class PatrolPlatform : MonoBehaviour
{
    private Transform _transform;
    public Transform[] points;
    private int moveIndex;
    public float patrolSpeed;
    void Start()
    {
        _transform = GetComponent<Transform>();
    }

    void Update()
    {
        _transform.position = Vector2.MoveTowards(_transform.position, points[moveIndex].position, patrolSpeed * Time.deltaTime);
        if (Vector2.Distance(_transform.position, points[moveIndex].position) < 0.2f && moveIndex == 0)       
            moveIndex = 1;

        if (Vector2.Distance(_transform.position, points[moveIndex].position) < 0.2f && moveIndex == 1)
            moveIndex = 0;
    }
}
