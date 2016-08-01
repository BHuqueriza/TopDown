/*===============================================================
Product:    TDS
Developer:  Brian H - deepsprawl@gmail.com
Company:    DefaultCompany
Date:       29/07/2016 18:00
================================================================*/

using UnityEngine;
using System.Collections;

[RequireComponent(typeof(PlayerController))]
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

    // Unity Functions

    void Awake()
    {

    }

    void Start()
    {
        controller = GetComponent<PlayerController>();
        viewCamera = Camera.main;
    }

    void OnDestroy()
    {

    }

    void Update()
    {
        Vector3 moveInput = new Vector3(Input.GetAxisRaw("Horizontal"), 0, Input.GetAxisRaw("Vertical"));
        Vector3 moveVelocity = moveInput.normalized * moveSpeed;
        controller.Move(moveVelocity);

        Ray ray = viewCamera.ScreenPointToRay(Input.mousePosition);
        Plane groundPlane = new Plane(Vector3.up, Vector3.zero);
        float rayDist;

        if (groundPlane.Raycast(ray, out rayDist))
        {
            Vector3 point = ray.GetPoint(rayDist);
            //Debug.DrawLine(ray.origin, point, Color.red);
            controller.LookAt(point);
        }
    }
}