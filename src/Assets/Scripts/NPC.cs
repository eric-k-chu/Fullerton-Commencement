using System.Collections;
using UnityEngine;

public class NPC : MonoBehaviour
{
    public Rigidbody rbCap;
    private Rigidbody rb;    

    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
    }

    private void Start()
    {
        EventManager.instance.onPlayerGraduates += Jump;

        float height = GetRandomFloat(1f, 1.3f, 0.01f);
        transform.localScale = new Vector3(1f, height, 1f);
        transform.position = new Vector3(transform.position.x, transform.position.y + (height - Mathf.Floor(height)), transform.position.z);
        rb.useGravity = true;
        rbCap.useGravity = false;
    }

    public void Jump()
    {
        float seconds = GetRandomFloat(0.1f, 2f, 0.1f);
        StartCoroutine(Wait(seconds));
    }

    private IEnumerator Wait(float seconds)
    {
        yield return new WaitForSeconds(seconds);
        float jumpPower = GetRandomFloat(1.5f, 1.8f, 0.1f);
        rb.AddForce(Vector3.up * jumpPower, ForceMode.Impulse);

        rbCap.useGravity = true;
        float throwPower = GetRandomFloat(10f, 15f, 1f);
        rbCap.AddForce(Vector3.up * throwPower, ForceMode.Impulse);
    }

    private float GetRandomFloat(float min, float max, float increment)
    {
        float rand = Random.Range(min, max);
        float steps = Mathf.Floor(rand / increment);
        return steps * increment;
    }

    private void OnDestroy()
    {
        EventManager.instance.onPlayerGraduates -= Jump;    
    }


}
