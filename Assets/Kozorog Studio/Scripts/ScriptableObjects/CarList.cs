using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "CarData", menuName = "KozorogStudio/Cars/CarList", order = 2)]
public class CarList : ScriptableObject
{
    public ScriptableObject[] carList;
}
