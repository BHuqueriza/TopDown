/*===============================================================
Product:    TDS
Developer:  Brian H - deepsprawl@gmail.com
Company:    DefaultCompany
Date:       01/08/2016 16:59
================================================================*/

using UnityEngine;
using System.Collections;

public class Bullet : MonoBehaviour
{
    // Variable Declarations
    public LayerMask collisionMask;

    // Static Variables

    // Private Variables
    float damage = 1f;

    // Public Variables
    public float speed = 10f;

    // Function Definitions

    // Unity Functions

    void Awake()
    {

    }

    void Start()
    {

    }

    void OnDestroy()
    {

    }

    public void SetSpeed(float newSpeed)
    {
        speed = newSpeed;
    }

    void Update()
    {
        float moveDist = speed * Time.deltaTime;
        CheckCollisions(moveDist);
        transform.Translate(Vector3.forward * moveDist);
    }

    void CheckCollisions(float moveDist)
    {
        Ray ray = new Ray(transform.position, transform.forward);
        RaycastHit hit;

        if (Physics.Raycast(ray, out hit, moveDist, collisionMask, QueryTriggerInteraction.Collide))
        {
            OnHitObject(hit);
        }
    }

    void OnHitObject(RaycastHit hit)
    {
        IDamageable damageableObject = hit.collider.GetComponent<IDamageable>();
        if (damageableObject != null)
        {
            damageableObject.TakeHit(damage, hit);
        }

        print(hit.collider.gameObject.name);
        GameObject.Destroy(gameObject);
    }
}