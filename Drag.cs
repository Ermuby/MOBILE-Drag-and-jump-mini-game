using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Drag : MonoBehaviour
{
    private Camera mainCamera;

    private Vector3 startPosition, clampedPosition;

    public Vector3 throwVector { get; private set; }

    private PlayerMovement _playerMovement;
    private GroundDetection _groundDetection;
    private LineTrajectory _lineTrajectory;

    private void Start()
    {
        mainCamera = Camera.main;
        _playerMovement = FindObjectOfType<PlayerMovement>();
        _groundDetection = FindObjectOfType<GroundDetection>();
        _lineTrajectory = FindObjectOfType<LineTrajectory>();

        _lineTrajectory._lineRenderer.enabled = false;
    }

    private void Update()
    {
        if (Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);
            switch (touch.phase)
            {
                case TouchPhase.Began:
                    StartThrow();
                    break;

                case TouchPhase.Moved:
                    ThrowPosition();
                    break;

                case TouchPhase.Ended:
                    Throw();
                    break;
            }
        }
    }

    private void StartThrow()
    {
        startPosition = mainCamera.ScreenToWorldPoint(Input.mousePosition);
        startPosition.z = 0f;

    }

    private void ThrowPosition()
    {
        if (_groundDetection.onGround)
        {
            Vector3 posOne, posTwo, posThree, posFour, posFive, posSix, posSeven, posEight, posNine, posTen;
            Vector3 dragPosition = mainCamera.ScreenToWorldPoint(Input.mousePosition);
            dragPosition.z = 0f;
            clampedPosition = dragPosition;

            float dragDistance = Vector2.Distance(startPosition, dragPosition);

            if (dragDistance > _playerMovement.radioDrag)
            {
                clampedPosition = startPosition + (dragPosition - startPosition).normalized * _playerMovement.radioDrag;
            }

            if (dragPosition.y > startPosition.y)
            {
                clampedPosition.y = startPosition.y;
            }

            throwVector = startPosition - clampedPosition;

            //-------------------------------------------------------------------------------------------------------------------------

            _lineTrajectory._lineRenderer.enabled = true;

            posOne = throwVector / 95 * 3;
            posTwo = throwVector / 90 * 3;
            posThree = throwVector / 80 * 3;
            posFour = throwVector / 70 * 3;
            posFive = throwVector / 60 * 3;
            posSix = throwVector / 50 * 3;
            posSeven = throwVector / 40 * 3;
            posEight = throwVector / 30 * 3;
            posNine = throwVector / 20 * 3;
            posTen = throwVector / 5 * 3;

            _lineTrajectory.Trajectory(posOne, posTwo, posThree, posFour, posFive, posSix, posSeven, posEight, posNine, posTen);

            _lineTrajectory.gameObject.transform.position = _playerMovement.transform.position;
        }
    }

    private void Throw()
    {
        _lineTrajectory._lineRenderer.enabled = false;

        if (_groundDetection.onGround)
        {
            throwVector = startPosition - clampedPosition;
            _playerMovement._rigidBody.AddForce(throwVector * _playerMovement.force, ForceMode.Impulse);
        }
    }
}
