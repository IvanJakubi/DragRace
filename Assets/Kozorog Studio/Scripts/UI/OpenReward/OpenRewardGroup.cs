using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenRewardGroup : MonoBehaviour
{
    [Header("")]
    public List<OpenRewardButton> buttonList;
    public List<int> goldReward;

    [Header("")]
    public DriverList driverListReward;
    public CarList carListReward;

    [Header("")]
    [SerializeField] CarsData chosenCarReward;
    [SerializeField] DriverData chosenDriverReward;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
