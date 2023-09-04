using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.InputSystem;

public class PlayerMovementController : MonoBehaviour
{
    [SerializeField]
    private GameObject player;
    private NavMeshAgent agent;
    private Camera mainCamera;
    private Animator animator;
    private Vector3 mousePos;

    private void Start()
    {
        mainCamera = Camera.main;
        agent = GetComponent<NavMeshAgent>();
        animator = GetComponent<Animator>();
    }

    void Update()
    {
        if (Mouse.current.leftButton.isPressed)
        {
            animator.SetBool("canWalk", true);
            MovePlayer();
        }
        else
        {
            animator.SetBool("canWalk", false);
        }
    }

    private void MovePlayer()
    {
        RaycastHit hit;
        Ray ray = mainCamera.ScreenPointToRay(mousePos);

        if (Physics.Raycast(ray, out hit))
        {
            if (hit.collider.CompareTag("Player"))
                return;
            else
            {
                agent.SetDestination(hit.point);
                if(agent.velocity.sqrMagnitude > Mathf.Epsilon)
                {
                    transform.rotation = Quaternion.LookRotation(agent.velocity.normalized);
                }
            }
        }
    }

    public void OnMousePosition(InputAction.CallbackContext ctx)
    {
        mousePos = ctx.action.ReadValue<Vector2>();
    }
}
