using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShatterEffect : MonoBehaviour
{
    /// <summary>
    /// This script is attached to the original whole object that is to be fractured.
    /// </summary>

    // Drag "shattered" prefab into here.
    
    public GameObject _shatteredObject;
    public float _breakForce;

    // Tells game Object IS NOT starting on ground.
    [SerializeField]
    private bool _isOnGround = false;


    // Triggers collider when object hits anything tagged "Ground".
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            _isOnGround = true;
            BreakTheThing();
        }
        else if (collision.gameObject.CompareTag("Glove"))
        {
            BreakTheThing();
        }
    }
    private void BreakTheThing()
    {
        GameObject shattered = Instantiate(_shatteredObject, transform.position, transform.rotation);
        Destroy(gameObject);

        foreach (Rigidbody rb in shattered.GetComponentsInChildren<Rigidbody>())
        {
            Vector3 force = (rb.transform.position - transform.position).normalized * _breakForce;
            rb.AddForce(force);
        }
        
    }
}

