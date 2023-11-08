using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerInteractor : MonoBehaviour
{
    [SerializeField] bool debug;

    [SerializeField] Transform point;
    [SerializeField] float interactRange;


    public void Interact()
    {
        Collider[] colliders = Physics.OverlapSphere(point.position, interactRange);
        foreach(Collider collider in colliders)
        {
            IInteractable interactable = collider.GetComponent<IInteractable>();
            interactable?.Interact();
        }
    }
    private void OnInteract(InputValue value)
    {
        Interact();
    }
    private void OnDrawGizmos()
    {
        if (!debug) return;

        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(point.position, interactRange);
    }
}
