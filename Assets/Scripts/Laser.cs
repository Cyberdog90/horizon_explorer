using UnityEngine;

public class Laser : MonoBehaviour
{
    public void ToFront()
    {
        MoveCamera.MoveFront = true;
    }

    public void ToBack()
    {
        MoveCamera.MoveBack = true;
    }

    public void ToRight()
    {
        MoveCamera.MoveRight = true;
    }

    public void ToLeft()
    {
        MoveCamera.MoveLeft = true;
    }
}