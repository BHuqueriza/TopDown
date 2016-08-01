/*===============================================================
Product:    TDS
Developer:  Brian H - deepsprawl@gmail.com
Company:    DefaultCompany
Date:       29/07/2016 18:00
================================================================*/

using UnityEngine;
using System.Collections;

[RequireComponent (typeof (Rigidbody))]
public class PlayerController : MonoBehaviour
{
    // Variable Declarations
    Rigidbody myRigidBody;

    // Static Variables

    // Private Variables
    Vector3 velocity;
	
	// Public Variables
	
	// Function Definitions
	
	// Unity Functions
	
	void Awake()
    {

    }

    void Start()
    {
        myRigidBody = GetComponent<Rigidbody>();
    }

    void OnDestroy()
    {

    }

    public void LookAt (Vector3 lookPoint)
    {
        Vector3 heightCorrection = new Vector3(lookPoint.x, transform.position.y, lookPoint.z);
        transform.LookAt(heightCorrection);
    }

    public void FixedUpdate()
    {
        myRigidBody.MovePosition(myRigidBody.position + velocity * Time.fixedDeltaTime);
    }

    public void Move(Vector3 _velocity)
    {
        velocity = _velocity;
    }
}