using UnityEngine;

public class Shield : MonoBehaviour
{
    public GameObject shieldEnd;
    private Transform _transform;

    private void Start()
    {
        _transform = GetComponent<Transform>();
    }

    public void ShieldEnd()
    {
        Instantiate(shieldEnd, _transform.position, Quaternion.identity);
    }
}
