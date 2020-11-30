using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnlockSkinButton : MonoBehaviour
{
    public TabGroupEnum tabEnum;

    [SerializeField] GameObject groupTransform;

    [SerializeField] private List<CheckIfUnlocked> driverTypes;
    [SerializeField] private List<CheckIfUnlocked> carTypes;

    [Header("")]
    [SerializeField] private List<CheckIfUnlocked> carRandomUnlockList;
    [SerializeField] private List<CheckIfUnlocked> driverRandomUnlockList;

    [Header("")]
    [Range(0, 5)]
    [SerializeField] private int goThroughSkinsTimes = 5;
    [Range(0f, 1f)]
    [SerializeField] private float waitTransition = 0.3f;

    private void Awake()
    {
        driverTypes = new List<CheckIfUnlocked>();
        carTypes = new List<CheckIfUnlocked>();
    }

    public void PopulateList()
    {
        driverTypes.Clear();
        carTypes.Clear();

        carRandomUnlockList.Clear();
        driverRandomUnlockList.Clear();

        if (tabEnum == TabGroupEnum.Cars)
        {
            groupTransform = GameObject.FindGameObjectWithTag("CarTab");

            foreach (Transform child in groupTransform.transform)
            {
                carTypes.Add(child.GetComponent<CheckIfUnlocked>());
            }

            foreach (CheckIfUnlocked child in carTypes)
            {
                if (child.isUnlocked.isUnlocked == 0)
                { 
                    carRandomUnlockList.Add(child);
                }
            }

            if(carRandomUnlockList.Count>0)
                StartCoroutine(UnlockRandomCarSkin());
        }
        else
        {
            groupTransform = GameObject.FindGameObjectWithTag("DriverTab");

            foreach (Transform child in groupTransform.transform)
            {
                driverTypes.Add(child.GetComponent<CheckIfUnlocked>());
            }

            foreach (CheckIfUnlocked child in driverTypes)
            {
                if (child.isUnlocked.isUnlocked == 0)
                {
                    driverRandomUnlockList.Add(child);
                }
            }
            if (driverRandomUnlockList.Count > 0)
                StartCoroutine(UnlockRandomDriverSkin());
        }

    }

    private IEnumerator UnlockRandomCarSkin()
    {
            int lastIndex = 0;
            int currentIndex = 0;

        for (int i = 0; i <= goThroughSkinsTimes; i++)
        {

            currentIndex = Random.Range(0, carRandomUnlockList.Count);

            if(carRandomUnlockList.Count>1)
                while (currentIndex == lastIndex)
                    currentIndex = Random.Range(0, carRandomUnlockList.Count); ;

            lastIndex = currentIndex;

            CheckIfUnlocked skinToCheck = carRandomUnlockList[currentIndex];

            if (carRandomUnlockList.Contains(skinToCheck))
            {
                skinToCheck.skinButton.outline.SetActive(true);
            }

            yield return new WaitForSeconds(waitTransition);

            skinToCheck.skinButton.outline.SetActive(false);

            if (i == goThroughSkinsTimes)
            {
                skinToCheck.skinButton.outline.SetActive(false);
                skinToCheck.isUnlocked.isUnlocked = 1;
                skinToCheck.UnlockLockCarImage();
                skinToCheck.AddCarToList();
            }
        }

        yield return null;
    }

    private IEnumerator UnlockRandomDriverSkin()
    {
        int lastIndex = 0;
        int currentIndex = 0;

        for (int i = 0; i <= goThroughSkinsTimes; i++)
        {
            
            currentIndex = Random.Range(0, driverRandomUnlockList.Count);

            if (driverRandomUnlockList.Count > 1)
                while (currentIndex == lastIndex)
                    currentIndex = Random.Range(0, driverRandomUnlockList.Count); ;

            lastIndex = currentIndex;

            CheckIfUnlocked skinToCheck = driverRandomUnlockList[currentIndex];

            if (driverRandomUnlockList.Contains(skinToCheck))
            {
                skinToCheck.skinButton.outline.SetActive(true);
            }

            yield return new WaitForSeconds(waitTransition);

            skinToCheck.skinButton.outline.SetActive(false);

            if (i == goThroughSkinsTimes)
            {
                skinToCheck.skinButton.outline.SetActive(false);
                skinToCheck.isUnlocked.isUnlocked = 1;
                skinToCheck.UnlockLockDriverImage();
                skinToCheck.AddCarToList();
            }
        }

        yield return null;
    }
}
