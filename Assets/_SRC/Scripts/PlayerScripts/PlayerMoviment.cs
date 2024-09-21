using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class PlayerMoviment : MonoBehaviour
{
    [Header("Layers")]
    public LayerMask groundLayer;

    private NavMeshAgent nav;

    private void Start()
    {
        nav = GetComponent<NavMeshAgent>();
    }

    private void Update()
    {
        PlayerInput();
    }

    private void PlayerInput()
    {
        if (Input.GetMouseButtonDown(0) || Input.GetMouseButton(0))
        {
            ManageMovement();
        }
    }

    private void ManageMovement()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

        Debug.DrawRay(ray.origin, ray.direction* 100, Color.red);

        RaycastHit hit;
        if (Physics.Raycast(ray, out hit, Mathf.Infinity, groundLayer))
        {
            if (hit.collider.CompareTag("Ground"))
            {
                Debug.Log("Hitando Chao");

                nav.SetDestination(hit.point);
            }
        }
    }
}
