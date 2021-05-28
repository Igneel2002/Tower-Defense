using UnityEngine;

public class Plasma : MonoBehaviour
{
    private Transform target;
    public float speed = 70f;
    public float blastEffect = 0f;
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
        transform.LookAt(target);
    }
    void TargetHit()
    {
        GameObject plasmaEffect = (GameObject) Instantiate(impactEffect, transform.position, transform.rotation);
        Destroy(plasmaEffect, 3.5f);
        if (blastEffect> 0f)
        {
            Explode();
        }
        else
        {
            Damage(target);
        }
        Destroy(gameObject);
    }
    void Damage(Transform _robot)
    {
        Destroy(_robot.gameObject);
    }
    void Explode()
    {
        Collider[] robotsHit = Physics.OverlapSphere(transform.position, blastEffect);
        foreach (Collider target in robotsHit)
        {
            if (target.tag == "Robot")
            {
                Damage(target.transform);
            }
        }
    }
    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, blastEffect);
    }
}
