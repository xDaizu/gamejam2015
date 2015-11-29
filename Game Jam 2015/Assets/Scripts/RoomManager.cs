using UnityEngine;
using System;
using System.Collections.Generic;       //Allows us to use Lists.
using Random = UnityEngine.Random;      //Tells Random to use the Unity Engine random number generator.


public class RoomManager : MonoBehaviour
{
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

    private GameObject[] Rooms;

    public GameObject[] RoomSetup(Level level, Transform roomsParent)
    {
        int num_rooms = level.rooms.Length;
        Rooms = new GameObject[num_rooms];
        foreach (RoomLink l in level.links)
        {
            level.rooms[l.roomSrc].doorsPosList.Add(l.roomSrcExit);
            l.roomSrcFacing = RoomLink.CalculateFacing(l.roomSrcExit, level.rooms[l.roomSrc]);
            level.rooms[l.roomDst].doorsPosList.Add(l.roomDstExit);
            l.roomDstFacing = RoomLink.CalculateFacing(l.roomDstExit, level.rooms[l.roomDst]);
        }

        for (int i = 0; i < num_rooms; i++)
        {
            Rooms[i] = new GameObject("Room" + i);
            Rooms[i].transform.SetParent(roomsParent);
            this.SingleRoomSetup(Rooms[i], level.rooms[i]);
            Rooms[i].transform.Translate(level.positions[i]);
        }

        foreach (RoomLink l in level.links)
        {
            this.SingleLinkSetup(l, Rooms);
        }

        return Rooms;
    }

    public void SingleLinkSetup(RoomLink roomLink, GameObject[] roomList)
    {
        int src = roomLink.roomSrc;
        Vector3 src_pos = new Vector3(roomLink.roomSrcExit.x, roomLink.roomSrcExit.y, 0f);
        Quaternion src_rot = RoomLink.GetFacingRotation(roomLink.roomSrcFacing);
        int dst = roomLink.roomDst;
        Vector3 dst_pos = new Vector3(roomLink.roomDstExit.x, roomLink.roomDstExit.y, 0f);
        Quaternion dst_rot = RoomLink.GetFacingRotation(roomLink.roomDstFacing);

        GameObject door = outerWallDoorTiles[Random.Range(0, outerWallDoorTiles.Length)];

        GameObject src_door = Instantiate(door, src_pos, src_rot) as GameObject;
        src_door.transform.SetParent(Rooms[src].transform, false);

        GameObject dst_door = Instantiate(door, dst_pos, dst_rot) as GameObject;
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

                if (!room.doorsPosList.Contains(pos))
                {
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
