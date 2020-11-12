using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using PathCreation;

public class PathFollower : MonoBehaviour
{
    #region Public variables
    public PathCreator pathCreator;
    public EndOfPathInstruction end;
    public float _dstTravelled;
    #endregion

    #region Private variables
    private bool _isDriving;
    private IEnumerator _followPath;
    private CarController _carController;
    private PlayerMovementState _playerMovementState;

    [SerializeField] private ScriptableEvent endReached;
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

        if (transform.position == pathCreator.path.GetPoint(pathCreator.path.NumPoints -1))
        {
            endReached.RaiseEvent(new EventMessage());
            SetPlayerMovementState(PlayerMovementState.NotRacing);
        }
    }
    #endregion

    #region Private functions

    private void SetPlayerMovementState(PlayerMovementState playerMovementState)
    {
        _playerMovementState = playerMovementState;
    }
    #endregion
}
