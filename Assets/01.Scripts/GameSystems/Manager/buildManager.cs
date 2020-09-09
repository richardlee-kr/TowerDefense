using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class buildManager : MonoBehaviour
{
    public static buildManager instance;

    private void Awake()
    {
        if(instance != null)
        {
            Debug.LogError("More than one buildManager in scene");
            return;
        }
        instance = this;
    }

    public GameObject gunTurretPrefab;
    public GameObject lazerTurretPrefab;
    public GameObject roketTurretPrefab;
    public GameObject machingunTurretPrefab;

    public GameObject buildEffect;
    public GameObject sellEffect;

    private TurretBlueprint turretToBuild;
    private Node selectedNode;

    public nodeUI nodeUI;

    public bool CanBuild { get { return turretToBuild != null; } }
    public bool HasMoney{ get { return PlayerStats.Money >= turretToBuild.cost; } }

    public void SelectNode(Node node)
    {
        if(selectedNode == node)
        {
            DeselectNode();
            return;
        }

        selectedNode = node;
        turretToBuild = null;

        nodeUI.SetTarget(node);
    }

    public void DeselectNode()
    {
        selectedNode = null;
        nodeUI.Hide();
    }

    public  void SelectTurretToBuild(TurretBlueprint turret)
    {
        turretToBuild = turret;
        DeselectNode();
    }

    public TurretBlueprint GetTurretToBuild()
    {
        return turretToBuild;
    }

}
