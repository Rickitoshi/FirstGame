using UnityEngine;

public class Floor : MonoBehaviour
{
    public float MoveSpeed = 0.2f;

    void FixedUpdate()
    {
        transform.position += new Vector3(MoveSpeed, 0, 0);
    }
}
