/*===============================================================
Product:    TDS
Developer:  Brian H - deepsprawl@gmail.com
Company:    DefaultCompany
Date:       01/08/2016 16:11
================================================================*/

using UnityEngine;
using System.Collections;

public class GunController : MonoBehaviour
{
    // Variable Declarations
    public Transform weaponHold;
    public Gun startingGun;

    // Static Variables

    // Private Variables

    // Public Variables

    // Function Definitions
    Gun equippedGun;

    // Unity Functions

    void Awake ()
    {
		
	}
	
    void Start ()
    {
        if (startingGun != null)
        {
            EquipGun(startingGun);
        }
	}
	
	void OnDestroy ()
    {
		
	}

    void Update ()
    {
		
    }

    public void EquipGun(Gun gunToEquip)
    {
        if (equippedGun != null)
        {
            Destroy(equippedGun.gameObject);
        }
        equippedGun = Instantiate (gunToEquip, weaponHold.position, weaponHold.rotation) as Gun;
        equippedGun.transform.parent = weaponHold;
    }

    public void Shoot()
    {
        if (equippedGun != null)
        {
            equippedGun.Shoot();
        }
    }
}