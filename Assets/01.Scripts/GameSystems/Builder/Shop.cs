using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shop : MonoBehaviour
{

    public TurretBlueprint gunTurret;
    public TurretBlueprint rokectTurret;
    public TurretBlueprint lazerTurret;
    public TurretBlueprint machingunTurret;

    buildManager buildManager;

    private void Start()
    {
        buildManager = buildManager.instance;
    }

    public void SelectGunTurret()
    {
        Debug.Log("selected Gun");
        buildManager.SelectTurretToBuild(gunTurret);
    }

    public void SelectLaserTurret()
    {
        Debug.Log("selected Laser");
        buildManager.SelectTurretToBuild(lazerTurret);
    }

    public void SelectRoketTurret()
    {
        Debug.Log("selected Roket");
        buildManager.SelectTurretToBuild(rokectTurret);
    }

    public void SelectMachinegunTurret()
    {
        Debug.Log("selected Roket");
        buildManager.SelectTurretToBuild(machingunTurret);
    }
}
