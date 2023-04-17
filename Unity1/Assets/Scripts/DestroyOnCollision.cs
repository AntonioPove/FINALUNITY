using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyOnCollision : MonoBehaviour
{

    [SerializeField]
    GameObject particles;
    [SerializeField]
    float particleDuration;
    MeshRenderer mesh;
    Rigidbody rb;


    bool canBeDestroy = false;

    private void Awake()
    {
        mesh = GetComponent<MeshRenderer>();
        rb = GetComponent<Rigidbody>();
    }

    private void FixedUpdate()
    {
        if(canBeDestroy && rb.velocity.magnitude < 0.2f)
        {
            if (particles == null)
                Destroy(gameObject, 0);
            else
            {
                mesh.enabled = false;
                particles.SetActive(true);
                Destroy(gameObject, particleDuration);
            }
        }
            
    }
    public void DestroyPerHit()
    {
        if (particles == null)
            Destroy(gameObject, 0);
        else
        {
            mesh.enabled = false;
            particles.SetActive(true);
            Destroy(gameObject, particleDuration);
        }
    }

    public void LaunchPerHit( Vector3 dir, float force)
    {
        Invoke("ActivateDestroy", 1f);
        rb.AddForce(dir.normalized * force);
    }

    void ActivateDestroy()
    {
        canBeDestroy = true;
    }
}
