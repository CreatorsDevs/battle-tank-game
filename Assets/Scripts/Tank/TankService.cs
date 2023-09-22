using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TankService : MonoBehaviour
{
    [SerializeField] private TankScriptableObjectList tankScriptableObjectList;

    private void Start()
    {
        StartGame();
    }

    public void StartGame()
    {
        CreateNewTank();
    }
    private TankController CreateNewTank()
    {
        int randomNumber = (int)Random.Range(0, tankScriptableObjectList.tanks.Length);
        TankScriptableObject tankObject = tankScriptableObjectList.tanks[randomNumber];
        Debug.Log(randomNumber);
        Debug.Log("Created tank of type: " + tankObject.name);
        TankModel model = new TankModel(tankObject);
        TankController tank = new TankController(model, tankObject.tankView);
        return tank;
    }
}
