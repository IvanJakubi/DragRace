using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using PathCreation;

public class PathFollower : MonoBehaviour
{
    #region Public variables
    public PathCreator pathCreator;
    public EndOfPathInstruction end;
    #endregion

    #region Private variables
    private float _dstTravelled;
    private bool _isDriving;
    private IEnumerator _followPath;
    private CarController _carController;
    private PlayerMovementState _playerMovementState;

    private enum PlayerMovementState
    {
        NotRacing,
        Racing
    }

    #endregion

    #region Unity event functions
    private void Awake()
    {
        Initialization();
    }

    private void Update()
    {
        if (_playerMovementState != PlayerMovementState.Racing)
            return;

        FollowPath();
        _carController.AccelerateCar();
        _carController.FillNitroMeter();
    }
    #endregion

    #region Public functions
    public void OnGameStart(EventMessage eventMessage)
    {
        SetPlayerMovementState(PlayerMovementState.Racing);
    }

    private void Initialization()
    {
        _carController = GetComponent<CarController>();
        _carController.gear = 0;
        SetPlayerMovementState(PlayerMovementState.NotRacing);
    }
    private void FollowPath()
    {
        _dstTravelled += _carController.currentSpeed * Time.deltaTime;
        transform.position = pathCreator.path.GetPointAtDistance(_dstTravelled, end);
        transform.rotation = pathCreator.path.GetRotationAtDistance(_dstTravelled, end);
    }
    #endregion

    #region Private functions

    private void SetPlayerMovementState(PlayerMovementState playerMovementState)
    {
        _playerMovementState = playerMovementState;
    }

    #endregion
}
