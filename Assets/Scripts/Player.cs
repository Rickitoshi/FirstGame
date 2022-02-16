using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{
    public float JumpForce = 1f;
    public Animator PlayerAnimator;
    public Text TextCoins;

    private Rigidbody _rigidBody;
    private int _coins;

    private void Start()
    {
        _rigidBody = GetComponent<Rigidbody>();
    }
    private void Update()
    {
        if (Input.touchCount > 0) Swipe();

        if (Input.GetAxis("Jump") > 0 && !PlayerAnimator.GetBool("isJumped"))
        {
            Jump();
        }
    }
    private void FixedUpdate()
    {
        if (transform.parent && transform.position.z - transform.parent.position.z != 0)
        {
            transform.position = Vector3.MoveTowards(transform.position, new Vector3(0, transform.position.y, transform.parent.position.z), 0.03f);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Obstacle")
        {
            SceneManager.LoadScene(0);
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
        PlayerAnimator.SetBool("isJumped", true);
        _rigidBody.AddForce(Vector3.up * JumpForce, ForceMode.Impulse);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Transport")
        {
            print("enter");
            if (transform.rotation.x < 0.06) transform.parent = collision.transform;
        }
        if(collision.gameObject.tag == "Floor")
        {
            SceneManager.LoadScene(0);
        }
    }
    private void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.tag == "Transport")
        {
            print("exit");
            transform.parent = null;
        }
    }

    private void Swipe()
    {
        Vector2 deltaSwipe = Input.GetTouch(0).deltaPosition;
        if(Mathf.Abs(deltaSwipe.x) < Mathf.Abs(deltaSwipe.y))
        {
            if (deltaSwipe.y > 5f && !PlayerAnimator.GetBool("isJumped"))
            {
                Jump();
            }
        }
    }
    public void AddCoins(int coins)
    {
        this._coins += coins;
        TextCoins.text= this._coins.ToString();
    }

}
