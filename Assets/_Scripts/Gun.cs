/*===============================================================
Product:    TDS
Developer:  Brian H - deepsprawl@gmail.com
Company:    DefaultCompany
Date:       01/08/2016 16:11
================================================================*/

using UnityEngine;
using System.Collections;

public class Gun : MonoBehaviour
{
    // Variable Declarations
    public Transform muzzle;
    public Bullet bullet;

    // Static Variables

    // Private Variables
    float nextShotTime;

    // Public Variables
    public float msBetweenShots = 100f;
    public float muzzleVelocity = 35f;
	
	// Function Definitions
	
	// Unity Functions
	
	void Awake ()
    {
		
	}
	
    void Start ()
    {
		
	}
	
	void OnDestroy ()
    {
		
	}

    void Update ()
    {
		
    }

    public void Shoot()
    {
        if (Time.time > nextShotTime)
        {
            nextShotTime = Time.time + msBetweenShots / 1000;
            Bullet newBullet = Instantiate(bullet, muzzle.position, muzzle.rotation) as Bullet;
            newBullet.SetSpeed(muzzleVelocity);
        }
    }
}