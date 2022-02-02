using UnityEngine;

public class FolowCamera : MonoBehaviour
{
    public Transform player;

    private float _deltaPosition;

    private void Start()
    {
        _deltaPosition = transform.position.z - player.position.z;
    }

    private void Update()
    {
        transform.position = new Vector3(transform.position.x, transform.position.y, player.position.z + _deltaPosition);
    }
}
