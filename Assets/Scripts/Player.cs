using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{
    public float jumpForce = 1f;
    public float straveSpeed = 5f;
    public float straveDistance = 3f;
    public Animator playerAnimator;
    public Text textCoins;

    private Rigidbody _rb;
    private Vector3 _seterLinePosition;
    private int coins;

    private void Start()
    {
        _rb = GetComponent<Rigidbody>();
        _seterLinePosition = new Vector3(0, 0, 0);
    }
    private void Update()
    {
        if (playerAnimator.GetInteger("StraveDirection") == 0)
        {
            if (Input.touchCount > 0) Swipe();

            if (Input.GetKeyDown(KeyCode.D) & transform.position.z < straveDistance)
            {
                Strave(1, straveDistance);
            }
            if (Input.GetKeyDown(KeyCode.A) & transform.position.z > -straveDistance)
            {
                Strave(-1, -straveDistance);
            }
            if (Input.GetAxis("Jump") > 0 & !playerAnimator.GetBool("Jumped"))
            {
                Jump();
            }
        }
    }
    private void FixedUpdate()
    {
        if (_seterLinePosition.z != transform.position.z)
        {
            transform.position = Vector3.MoveTowards(transform.position, new Vector3(0, transform.position.y, _seterLinePosition.z), straveSpeed);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Obstacle")
        {
            SceneManager.LoadScene(1);
        }
        if (other.tag == "Coin")
        {
            Destroy(other.gameObject);
            AddCoins(1);
        }
        if (other.tag == "DoubleCoin")
        {
            Destroy(other.gameObject);
            AddCoins(2);
        }
    }
    private void Jump()
    {
        playerAnimator.SetBool("Jumped", true);
        _rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
    }
    private void Strave(int straveDirection, float straveDistance)
    {
        playerAnimator.SetInteger("StraveDirection", straveDirection);
        _seterLinePosition += new Vector3(0, 0, straveDistance);
    }
    private void Swipe()
    {
        Vector2 deltaSwipe = Input.GetTouch(0).deltaPosition;
        if(Mathf.Abs(deltaSwipe.x) > Mathf.Abs(deltaSwipe.y))
        {
            if( deltaSwipe.x > 0 & transform.position.z < straveDistance)
            {
                Strave(1, straveDistance);
            }
            if (deltaSwipe.x < 0 & transform.position.z > -straveDistance)
            {
                Strave(-1, -straveDistance);
            }
        }
        else
        {
            if (deltaSwipe.y > 0 & !playerAnimator.GetBool("Jumped"))
            {
                Jump();
            }
        }
    }
    public void AddCoins(int coins)
    {
        this.coins += coins;
        textCoins.text= this.coins.ToString();
    }
}
