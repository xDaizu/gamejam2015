using UnityEngine;
using System.Collections;


public class RoomLink {
    public int roomSrc;
    public Vector2 roomSrcExit;
    public GameObject srcDoorRef;

    public int roomDst;
    public Vector2 roomDstExit;
    public GameObject dstDoorRef;



    public RoomLink(int src, Vector2 srcExit, int dst, Vector2 dstExit)
    {
        this.roomSrc = src;
        this.roomSrcExit = srcExit;

        this.roomDst = dst;
        this.roomDstExit = dstExit;
    }
}
