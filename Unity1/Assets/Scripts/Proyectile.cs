using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Proyectile : MonoBehaviour
{
    [SerializeField]
    float vel;
    [SerializeField]
    Rigidbody rb;

    private void Start()
    {
        //rb.velocity = (transform.position - Camera.main.transform.position) * vel * Time.fixedDeltaTime;
        //transform.rotation = Quaternion.LookRotation(transform.position - Camera.main.transform.position);

        rb.velocity = (transform.forward) * vel * Time.fixedDeltaTime;
    }

    private void OnCollisionEnter(Collision collision)
    {
        var c = collision.gameObject.GetComponent<DestroyOnCollision>();

        if (c != null)
            c.DestroyPerHit();

        Destroy(gameObject);
    }

}
