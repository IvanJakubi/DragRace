using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using PathCreation;

public class EnemyPathFollower : MonoBehaviour
{
    #region Public variables
    public PathCreator pathCreator;
    public EndOfPathInstruction end;
    #endregion

    #region Private variables
    private float _dstTravelled;
    private bool _isDriving;
    private IEnumerator _followPath;
    EnemyCarController _carController;
    private EnemyMovementState _enemyMovementState;

    [SerializeField] private ScriptableEvent endReached;
    #endregion

    #region Unity event functions
    private void Awake()
    {
        Initialization();
    }

    private void Update()
    {
        if (_enemyMovementState != EnemyMovementState.Racing)
            return;

        FollowPath();
        _carController.AccelerateCar();
    }
    #endregion

    #region Public functions
    public void OnGameStart(EventMessage eventMessage)
    {
        SetPlayerMovementState(EnemyMovementState.Racing);
    }

    private void Initialization()
    {
        _carController = GetComponent<EnemyCarController>();
        _carController.gear = 0;
        SetPlayerMovementState(EnemyMovementState.NotRacing);
    }
    private void FollowPath()
    {
        _dstTravelled += _carController.currentSpeed * Time.deltaTime;
        transform.position = pathCreator.path.GetPointAtDistance(_dstTravelled, end);
        transform.rotation = pathCreator.path.GetRotationAtDistance(_dstTravelled, end);

        if (transform.position == pathCreator.path.GetPoint(pathCreator.path.NumPoints - 1))
        {
            endReached.RaiseEvent(new EventMessage());
            SetPlayerMovementState(EnemyMovementState.NotRacing);
        }
    }
    #endregion

    #region Private functions

    private void SetPlayerMovementState(EnemyMovementState enemyMovementState)
    {
        _enemyMovementState = enemyMovementState;
    }
    #endregion
}
