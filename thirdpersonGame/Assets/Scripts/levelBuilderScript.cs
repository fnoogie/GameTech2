using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEditor;

public class levelBuilderScript : MonoBehaviour
{
    [HideInInspector]
    public GameObject levelBox, player, cube, button, door;
    
    [ContextMenu("LevelBuildingTools/Create Level Box")]
    public void createBox()
    {
        Instantiate(levelBox, new Vector3(0,0,0), Quaternion.identity);
    }

    [ContextMenu("LevelBuildingTools/Create Player Object")]
    public void createPlayer()
    {
        Instantiate(player, new Vector3(15f, 2.5f, -5.6f), Quaternion.identity);
    }

    [ContextMenu("LevelBuildingTools/Create Cube")]
    public void createCube()
    {
        Instantiate(cube, new Vector3(15, 2.5f, -15f), Quaternion.identity);
    }

    [ContextMenu("LevelBuildingTools/Create Button")]
    public void createButton()
    {
        Instantiate(button, new Vector3(15, .2f, -22f), Quaternion.identity);
    }
    [ContextMenu("LevelBuildingTools/Create Door")]
    public void createDoor()
    {
        Instantiate(door, new Vector3(10, 0, -29.9f), Quaternion.Euler(90, 180, 0));
    }

    [ContextMenu("LevelBuildingTools/Create Basic Level")]
    public void createBasicLevel()
    {
        createBox();
        createPlayer();
        createCube();
        createButton();
        createDoor();
    }


    [MenuItem("LevelBuildingTools/Create Level Box")]
    public static void createBoxAgain()
    {
        Instantiate(Resources.Load("levelBox"), new Vector3(0, 0, 0), Quaternion.identity);
    }

    [MenuItem("LevelBuildingTools/Create Player Object")]
    public static void createPlayerAgain()
    {
        Instantiate(Resources.Load("Player"), new Vector3(15f, 2.5f, -5.6f), Quaternion.identity);
    }

    [MenuItem("LevelBuildingTools/Create Cube")]
    public static void createCubeAgain()
    {
        Instantiate(Resources.Load("Box") as GameObject, new Vector3(15, 2.5f, -15f), Quaternion.identity);
    }

    [MenuItem("LevelBuildingTools/Create Button")]
    public static void createButtonAgain()
    {
        Instantiate(Resources.Load("BoxActivatedButton"), new Vector3(15, .2f, -22f), Quaternion.identity);
    }

    [MenuItem("LevelBuildingTools/Create Door")]
    public static void createDoorAgain()
    {
        Instantiate(Resources.Load("DoorFrame"), new Vector3(10, 0, -29.9f), Quaternion.Euler(90, 180, 0));
    }

    [MenuItem("LevelBuildingTools/Create Basic Level")]
    public static void createBasicLevelAgain()
    {
        createBoxAgain();
        createPlayerAgain();
        createCubeAgain();
        createButtonAgain();
        createDoorAgain();
    }
}

