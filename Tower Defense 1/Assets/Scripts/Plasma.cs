using UnityEngine;

public class Plasma : MonoBehaviour
{
    private Transform target;
    public float speed = 70f;
    public GameObject impactEffect;
    public void Pursue(Transform _target)
    {
        target = _target;
    }

    // Update is called once per frame
    void Update()
    {
        if (target == null)
        {
            Destroy(gameObject);
            return;
        }

        Vector3 direction = target.position - transform.position;
        float disthisFrame = speed * Time.deltaTime;

        if (direction.magnitude <= disthisFrame)
        {
            TargetHit();
            return;
        }
        transform.Translate(direction.normalized * disthisFrame, Space.World);
    }
    void TargetHit()
    {
        GameObject plasmaEffect = (GameObject) Instantiate(impactEffect, transform.position, transform.rotation);
        Destroy(plasmaEffect, 2f);
        Destroy(gameObject);
    }
}
