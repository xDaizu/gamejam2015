using UnityEngine;
using System;
using System.Collections.Generic;       //Allows us to use Lists.
using Random = UnityEngine.Random;      //Tells Random to use the Unity Engine random number generator.


public class RoomManager : MonoBehaviour
{
    public GameObject exit;                         //Prefab to spawn for exit.
    public GameObject[] floorTiles;                 //Array of floor prefabs.
    public GameObject[] outerWallUpTiles;           //Array of outer tile prefabs.
    public GameObject[] outerWallUpLeftTiles;       //Array of outer tile prefabs.
    public GameObject[] outerWallUpRightTiles;      //Array of outer tile prefabs.
    public GameObject[] outerWallDownLeftTiles;     //Array of outer tile prefabs.
    public GameObject[] outerWallDownRightTiles;    //Array of outer tile prefabs.
    public GameObject[] outerWallDownTiles;         //Array of outer tile prefabs.
    public GameObject[] outerWallLeftTiles;         //Array of outer tile prefabs.
    public GameObject[] outerWallRightTiles;        //Array of outer tile prefabs.
    public GameObject[] outerWallDoorTiles;

    private Transform roomHolder;                               //A variable to store a reference to the transform of our Board object.
    private List<Vector3> gridPositions = new List<Vector3>();  //A list of possible locations to place tiles.

    public GameObject[] Rooms;

    public GameObject[] RoomSetup(Room[] roomList, Vector3[] roomPositions, RoomLink[] roomLinks)
    {
        Rooms = new GameObject[roomList.Length];
        //List<DoorRef>[] doorRefs = new List<DoorRef>[roomList.Length];
        foreach (RoomLink l in roomLinks)
        {
            roomList[l.roomSrc].doorsPosList.Add(l.roomSrcExit);
            roomList[l.roomDst].doorsPosList.Add(l.roomDstExit);
        }

        for (int i = 0; i < roomList.Length; i++)
        {
            Rooms[i] = new GameObject("Room" + i);
            this.SingleRoomSetup(Rooms[i], roomList[i]);
            Rooms[i].transform.Translate(roomPositions[i]);
        }
        
        foreach (RoomLink l in roomLinks)
        {
            this.SingleLinkSetup(l, Rooms);
        }
        
        return Rooms;
    }

    public void SingleLinkSetup(RoomLink roomLink, GameObject[] roomList)
    {
        int src = roomLink.roomSrc;
        int src_x = (int)roomLink.roomSrcExit.x;
        int src_y = (int)roomLink.roomSrcExit.y;
        int dst = roomLink.roomDst;
        int dst_x = (int)roomLink.roomDstExit.x;
        int dst_y = (int)roomLink.roomDstExit.y;

        GameObject door = outerWallDoorTiles[Random.Range(0, outerWallDoorTiles.Length)];

        GameObject src_door = Instantiate(door, new Vector3(src_x, src_y, 0f), Quaternion.identity) as GameObject;
        src_door.transform.SetParent(Rooms[src].transform, false);

        GameObject dst_door = Instantiate(door, new Vector3(dst_x, dst_y, 0f), Quaternion.identity) as GameObject;
        dst_door.transform.SetParent(Rooms[dst].transform, false);

        setDoorLink(src_door, dst_door);
        setDoorLink(dst_door, src_door);
    }

    private void setDoorLink(GameObject doorObject, GameObject destiny)
    {
        BoxCollider2D src_bc2d = doorObject.AddComponent<BoxCollider2D>();
        src_bc2d.isTrigger = true;
        src_bc2d.size = new Vector2(1f, 1f);
        DoorTrigger src_dtscript = doorObject.AddComponent<DoorTrigger>();
        src_dtscript.exitDoor = destiny;
    }

    //Sets up the outer walls and floor (background) of the game room.
    public void SingleRoomSetup(GameObject roomObject, Room room)
    {
        //Loop along x axis, starting from -1 (to fill corner) with floor or outerwall edge tiles.
        for (int x = -1; x < room.columns + 1; x++)
        {
            //Loop along y axis, starting from -1 to place floor or outerwall tiles.
            for (int y = -1; y < room.rows + 1; y++)
            {
                GameObject toInstantiate;
                Vector2 pos = new Vector2(x, y);

                if (!room.doorsPosList.Contains(pos)) {
                    //Choose a random tile from our array of floor tile prefabs and prepare to instantiate it.
                    toInstantiate = floorTiles[Random.Range(0, floorTiles.Length)];

                    //Check if we current position is at board edge, if so choose a random outer wall prefab from our array of outer wall tiles.
                    if (x == -1 || x == room.columns || y == -1 || y == room.rows)
                    {
                        if (y == -1)
                        {
                            if (x == -1)
                            {
                                toInstantiate = outerWallDownLeftTiles[Random.Range(0, outerWallDownLeftTiles.Length)];
                            }
                            else if (x == room.columns)
                            {
                                toInstantiate = outerWallDownRightTiles[Random.Range(0, outerWallDownRightTiles.Length)];
                            }
                            else
                            {
                                toInstantiate = outerWallDownTiles[Random.Range(0, outerWallDownTiles.Length)];
                            }

                        }
                        else if (y == room.rows)
                        {
                            if (x == -1)
                            {
                                toInstantiate = outerWallUpLeftTiles[Random.Range(0, outerWallUpLeftTiles.Length)];
                            }
                            else if (x == room.columns)
                            {
                                toInstantiate = outerWallUpRightTiles[Random.Range(0, outerWallUpRightTiles.Length)];
                            }
                            else
                            {
                                toInstantiate = outerWallUpTiles[Random.Range(0, outerWallUpTiles.Length)];
                            }
                        }
                        else
                        {
                            if (x == -1)
                            {
                                toInstantiate = outerWallLeftTiles[Random.Range(0, outerWallUpLeftTiles.Length)];
                            }
                            else if (x == room.columns)
                            {
                                toInstantiate = outerWallRightTiles[Random.Range(0, outerWallUpLeftTiles.Length)];

                            }
                        }

                    }
                    //Instantiate the GameObject instance using the prefab chosen for toInstantiate at the Vector3 corresponding to current grid position in loop, cast it to GameObject.
                    GameObject instance =
                        Instantiate(toInstantiate, new Vector3(x, y, 0f), toInstantiate.transform.rotation) as GameObject;

                    //Set the parent of our newly instantiated object instance to boardHolder, this is just organizational to avoid cluttering hierarchy.
                    instance.transform.SetParent(roomObject.transform);
                }
            }
        }
    }
}
