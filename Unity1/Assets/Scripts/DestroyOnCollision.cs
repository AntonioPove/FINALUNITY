using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyOnCollision : MonoBehaviour
{
    [SerializeField]
    int money;
    [SerializeField]
    GameObject particles;
    [SerializeField]
    float particleDuration;
    [SerializeField]
    int audioOnDestruction;
    MeshRenderer mesh;
    Rigidbody rb;


    bool canBeDestroy = false;

    private void Awake()
    {
        mesh = GetComponent<MeshRenderer>();
        rb = GetComponent<Rigidbody>();
    }

    private void Start()
    {
        MoneyManager.instance.AddObject(money);
    }

    private void FixedUpdate()
    {
        if (canBeDestroy && rb.velocity.magnitude < 0.2f)
        {
            if (particles == null)
                Destroy(gameObject, 0);
            else
            {
                mesh.enabled = false;
                particles.SetActive(true);
                Destroy(gameObject, particleDuration);
            }

            MoneyManager.instance.AddMoney(money);
        }

    }
    public void DestroyPerHit()
    {
        if (particles == null)
        {
            if (audioOnDestruction != -1)
                AudioManager.instance.Destruction(audioOnDestruction);
            Destroy(gameObject, 0);
        }

        else
        {
            if (audioOnDestruction != -1)
                AudioManager.instance.Destruction(audioOnDestruction);

            mesh.enabled = false;
            particles.SetActive(true);
            Destroy(gameObject, particleDuration);
        }

        MoneyManager.instance.AddMoney(money);
    }

    public void LaunchPerHit(Vector3 dir, float force)
    {
        Invoke("ActivateDestroy", 1f);
        AudioManager.instance.Destruction(audioOnDestruction);
        rb.AddForce(dir.normalized * force);
    }

    void ActivateDestroy()
    {
        canBeDestroy = true;
    }
}
