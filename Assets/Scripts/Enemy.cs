using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public enum EnemyType { Golem, Bat , Slime}
    public EnemyType enemy;

    private Animator anim;

    [Header("Bat")]
    public Transform[] points;
    private Transform _transform;
    private int pointIndex;
    public float batSpeed;

    private void Start()
    {
        _transform = GetComponent<Transform>();
    }

    void Update()
    {
        anim = GetComponent<Animator>();
        if (enemy == EnemyType.Golem)
        {
            anim.Play("GolemIdle");
        }
        else if (enemy == EnemyType.Bat)
        {
            anim.Play("BatFly");
            _transform.position = Vector2.MoveTowards(_transform.position, points[pointIndex].position, batSpeed * Time.deltaTime);
            if (Vector2.Distance(_transform.position, points[pointIndex].position) < 0.2f && pointIndex == 0)
            {
                pointIndex = 1;                
            }
            else if (Vector2.Distance(_transform.position, points[pointIndex].position) < 0.2f && pointIndex == 1)
            {
                pointIndex = 0;
            }

            if (_transform.position.x > points[pointIndex].position.x)
            {
                _transform.eulerAngles = new Vector3(0, 180, 0);
            }
            else
            {
                _transform.eulerAngles = new Vector3(0, 0, 0);
            }
        }
        else if (enemy == EnemyType.Slime)
        {
            anim.Play("SlimeJump");
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.name == "DeadZone")
        {
            Destroy(gameObject);
        }
    }
}
