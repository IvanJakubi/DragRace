using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;
using DG.Tweening;

public class CrownController : MonoBehaviour
{
    [Header("Path Followers")]
    [SerializeField] EnemyPathFollower enemyPathFollower;
    [SerializeField] PathFollower carPathFollower;

    [Header("Game Objects")]
    [SerializeField] GameObject playerCrown;
    [SerializeField] GameObject enemyCrown;

    // Update is called once per frame
    void Update()
    {
        if(playerCrown.activeInHierarchy)
            playerCrown.transform.DOLocalRotate(new Vector3(0f,360f,0f), 2f, RotateMode.FastBeyond360).SetEase(Ease.Linear).SetLoops(-1, LoopType.Incremental).SetRelative();

        if (enemyCrown.activeInHierarchy)
            enemyCrown.transform.DOLocalRotate(new Vector3(0f, 360f, 0f), 2f, RotateMode.FastBeyond360).SetEase(Ease.Linear).SetLoops(-1, LoopType.Incremental).SetRelative();

        if (carPathFollower._dstTravelled == enemyPathFollower._dstTravelled)
        {
            playerCrown.SetActive(false);
            enemyCrown.SetActive(false);
        }

        if(carPathFollower._dstTravelled > enemyPathFollower._dstTravelled)
        {
            playerCrown.SetActive(true);
            enemyCrown.SetActive(false);
        }

        if(carPathFollower._dstTravelled < enemyPathFollower._dstTravelled)
        {
            playerCrown.SetActive(false);
            enemyCrown.SetActive(true);
        }
    }
}
