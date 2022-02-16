using UnityEngine;

public class Collector : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        Destroy(other.gameObject);
        if(other.tag == "FinishFloor")
        {
           Destroy(other.transform.parent.gameObject);
        }
    }
}
