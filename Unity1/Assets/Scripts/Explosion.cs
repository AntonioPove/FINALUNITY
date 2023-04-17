using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Explosion : MonoBehaviour
{
    [SerializeField]
    float force, area, explodeAfterSeconds, deleteAfterSeconds;
    [SerializeField]
    GameObject explosionEffect;
    [SerializeField]
    LayerMask destroyableLayer;

    bool countDown = false;
    public void LaunchObject()
    {
        GetComponent<Rigidbody>().AddForce((Camera.main.transform.position - transform.position).normalized * force);

        Invoke("Bum", explodeAfterSeconds);
        countDown = true;
    }

    void Bum()
    {
        Collider[] cols = Physics.OverlapSphere(transform.position, area, destroyableLayer);

        DestroyOnCollision d;
        foreach (var item in cols)
        {
            d = item.GetComponent<DestroyOnCollision>();

            if(d != null)
                d.DestroyPerHit();
            
        }
        explosionEffect.SetActive(true);

        GetComponent<MeshRenderer>().enabled = false;

        Destroy(gameObject, deleteAfterSeconds);
    }
}
