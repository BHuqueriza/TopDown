/*===============================================================
Product:    TDS
Developer:  Brian H - deepsprawl@gmail.com
Company:    DefaultCompany
Date:       01/08/2016 19:13
================================================================*/

using UnityEngine;
using System.Collections;

[RequireComponent (typeof (NavMeshAgent))]
public class Enemy : MonoBehaviour
{
    // Variable Declarations
    NavMeshAgent pathfinder;

    // Static Variables
    Transform target;
	
	// Private Variables
	
	// Public Variables
	
	// Function Definitions
	
	// Unity Functions
	
	void Awake ()
    {
		
	}
	
    void Start ()
    {
        pathfinder = GetComponent<NavMeshAgent>();
        target = GameObject.FindGameObjectWithTag("Player").transform;

        StartCoroutine(UpdatePath());
	}
	
	void OnDestroy ()
    {
		
	}

    void Update ()
    {

    }

    IEnumerator UpdatePath()
    {
        float refreshRate = 0.25f;

        while (target != null)
        {
            Vector3 targetPosition = new Vector3(target.position.x, 0, target.position.z);
            pathfinder.SetDestination(targetPosition);
            yield return new WaitForSeconds(refreshRate);
        }
    }
}