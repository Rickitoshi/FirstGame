using UnityEngine;

public class Floor : MonoBehaviour
{
    public float moveSpeed = 1f;

    void FixedUpdate()
    {
        transform.position += new Vector3(moveSpeed, 0, 0);
    }
}
