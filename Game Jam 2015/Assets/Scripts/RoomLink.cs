using UnityEngine;
using System.Collections;


public class RoomLink {
    public enum Facing
    {
        LEFT, RIGHT, TOP, BOTTOM
    };
    public int roomSrc;
    public Vector2 roomSrcExit;
    public Facing roomSrcFacing;

    public int roomDst;
    public Vector2 roomDstExit;
    public Facing roomDstFacing;

    public RoomLink(int src, Vector2 srcExit, int dst, Vector2 dstExit)
    {
        this.roomSrc = src;
        this.roomSrcExit = srcExit;

        this.roomDst = dst;
        this.roomDstExit = dstExit;
    }

    static public Facing CalculateFacing(Vector2 doorPos, Room room){
        Facing facing;
        if (doorPos.x == -1)
        {
            facing = Facing.LEFT;
        }
        else if (doorPos.y == -1)
        {
            facing = Facing.BOTTOM;
        }
        else if (doorPos.x == room.columns)
        {
            facing = Facing.RIGHT;
        }
        else
        {
            facing = Facing.TOP;
        }

        return facing;
    }
    
    static public Quaternion GetFacingRotation(Facing facing)
    {
        float z_angle = 0;
        switch (facing)
        {
            case Facing.TOP:
                z_angle = 0;
                break;
            case Facing.LEFT:
                z_angle = 90;
                break;
            case Facing.BOTTOM:
                z_angle = 180;
                break;
            case Facing.RIGHT:
                z_angle = 270;
                break;
            default:
                z_angle = 0;
                break;
        }
        return Quaternion.Euler(0, 0, z_angle);
    }
}
