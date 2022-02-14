using UnityEngine;

public class FolowCamera : MonoBehaviour
{
    public Transform PlayerTransform;

    private float _deltaPosition;

    private void Start()
    {
        _deltaPosition = transform.position.z - PlayerTransform.position.z;
    }

    private void Update()
    {
        transform.position = new Vector3(transform.position.x, transform.position.y, PlayerTransform.position.z + _deltaPosition);
    }
}
