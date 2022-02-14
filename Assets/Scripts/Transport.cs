using UnityEngine;

public class Transport : MonoBehaviour
{
    public float StraveSpeed = 5f;
    public float StraveDistance = 3f;
    private Vector3 _targetLinePosition;

    void Start()
    {
        _targetLinePosition = new Vector3(0, 0, 0);
    }

    void Update()
    {
        if (_targetLinePosition.z == transform.position.z)
        {
            if (Input.touchCount > 0) Swipe();

            if (Input.GetKeyDown(KeyCode.D) && _targetLinePosition.z < 3)
            {
                Strave(1, StraveDistance);
            }
            if (Input.GetKeyDown(KeyCode.A) && _targetLinePosition.z > -3)
            {
                Strave(-1, -StraveDistance);
            }
        }
    }
    private void FixedUpdate()
    {
        if (_targetLinePosition.z != transform.position.z)
        {
            transform.position = Vector3.MoveTowards(transform.position, new Vector3(0, transform.position.y, _targetLinePosition.z), StraveSpeed);
        }
    }

    private void Strave(int straveDirection, float straveDistance)
    {
        _targetLinePosition += new Vector3(0, 0, straveDistance);
    }

    private void Swipe()
    {
        Vector2 deltaSwipe = Input.GetTouch(0).deltaPosition;

        if (Mathf.Abs(deltaSwipe.x) > Mathf.Abs(deltaSwipe.y))
        {
            if (deltaSwipe.x > 0 && _targetLinePosition.z < 3)
            {
                Strave(1, StraveDistance);
            }
            if (deltaSwipe.x < 0 && _targetLinePosition.z > -3)
            {
                Strave(-1, -StraveDistance);
            }
        }
    }

}
