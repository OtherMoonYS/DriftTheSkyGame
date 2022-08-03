using UnityEngine;

public class FallingTrap : MonoBehaviour
{
    public Transform spawnPos;
    public GameObject trap;
    private Collider2D box;

    private void Start()
    {
        box = GetComponent<BoxCollider2D>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.GetComponent<Doodle>() != null)
        {
            Instantiate(trap, spawnPos.position, Quaternion.identity);
            box.enabled = false;
        }
    }
}
