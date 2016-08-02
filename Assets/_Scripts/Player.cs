/*===============================================================
Product:    TDS
Developer:  Brian H - deepsprawl@gmail.com
Company:    DefaultCompany
Date:       29/07/2016 18:00
================================================================*/

using UnityEngine;
using System.Collections;

[RequireComponent(typeof(PlayerController))]
[RequireComponent(typeof(GunController))]
public class Player : MonoBehaviour
{
    // Variable Declarations
    PlayerController controller;
    Camera viewCamera;

    // Static Variables

    // Private Variables

    // Public Variables
    public float moveSpeed = 5;

    // Function Definitions
    GunController gunController;

    // Unity Functions

    void Awake()
    {

    }

    void Start()
    {
        controller = GetComponent<PlayerController>();
        gunController = GetComponent<GunController>();
        viewCamera = Camera.main;
    }

    void OnDestroy()
    {

    }

    void Update()
    {
        // Movement Input
        Vector3 moveInput = new Vector3(Input.GetAxisRaw("Horizontal"), 0, Input.GetAxisRaw("Vertical"));
        Vector3 moveVelocity = moveInput.normalized * moveSpeed;
        controller.Move(moveVelocity);

        // Look Input
        Ray ray = viewCamera.ScreenPointToRay(Input.mousePosition);
        Plane groundPlane = new Plane(Vector3.up, Vector3.zero);
        float rayDist;

        if (groundPlane.Raycast(ray, out rayDist))
        {
            Vector3 point = ray.GetPoint(rayDist);
            //Debug.DrawLine(ray.origin, point, Color.red);
            controller.LookAt(point);
        }

        // Weapon Input
        if (Input.GetMouseButton(0))
        {
            gunController.Shoot();
        }
    }
}