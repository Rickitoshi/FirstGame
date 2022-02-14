using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuControl : MonoBehaviour
{
    public float Delay = 1f;
    private Animator _playerAnimator;
    private Rigidbody _playerRigidbody;

    private void Start()
    {
        _playerAnimator = GameObject.Find("PlayerSkin").GetComponent<Animator>();
        _playerRigidbody = GameObject.Find("Player").GetComponent<Rigidbody>();
    }

    public void OnClickPlay()
    {
        _playerAnimator.SetBool("isJumped", true);
        _playerRigidbody.AddForce(Vector3.up * 12f, ForceMode.Impulse);
        StartCoroutine(CorountineStart(Delay));
    }

    public void OnClickExit()
    {
        Application.Quit();
    }

    IEnumerator CorountineStart(float wait)
    {
        yield return new WaitForSeconds(wait);
        SceneManager.LoadScene(1);
    }
}
