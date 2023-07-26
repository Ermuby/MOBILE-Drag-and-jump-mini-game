using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundDetection : MonoBehaviour
{
    public bool onGround;

    private Vector3 down;

    private Rigidbody _rigidbody;
    private PlayerMovement _playerMovement;

    private const int zero = 0;
    private const float rayLenght = 0.25f;

    private void Start()
    {
        down = transform.GetChild(zero).TransformDirection(Vector3.down);
        _rigidbody = GetComponent<Rigidbody>();
        _playerMovement = GetComponent<PlayerMovement>();
    }

    private IEnumerator FixVelocity()
    {
        yield return new WaitForSecondsRealtime(_playerMovement.fixVelocity);
        _rigidbody.velocity = new Vector3(0, 0, 0);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            onGround = true;
            StartCoroutine(FixVelocity());
        }
    }

    private void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            onGround = false;
            StopAllCoroutines();
        }
    }
}
