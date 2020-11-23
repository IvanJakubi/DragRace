using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "DriverList", menuName = "KozorogStudio/Drivers/DriverList")]
public class DriverList : ScriptableObject
{
    public List<DriverData> driverList;
}
