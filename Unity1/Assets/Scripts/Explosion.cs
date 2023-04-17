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
        Debug.Log(Camera.main.name);
        GetComponent<Rigidbody>().AddForce((transform.position - Camera.main.transform.position).normalized * force/10);

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
        if(explosionEffect != null)
        explosionEffect.SetActive(true);

        transform.GetChild(0).gameObject.SetActive(false);

        Destroy(gameObject, deleteAfterSeconds);
    }
}
