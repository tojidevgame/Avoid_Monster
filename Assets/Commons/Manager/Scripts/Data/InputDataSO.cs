using System;
using UnityEngine;


[CreateAssetMenu(fileName = "InputDataSO", menuName = "Avoid_Monster/Runtime Data/InputDataSO")]
public class InputDataSO : ScriptableObject
{
    private float horizontalInput;
    private Action jumpInput;

    public float HorizontalInput
    {
        get { return horizontalInput; }
        set 
        {
            horizontalInput = value;
            if (value < 0)
                horizontalInput = -1;
            else if (value > 1)
                horizontalInput = 1;
        }
    }


    public Action JumpInput
    {
        get => jumpInput;
        set { jumpInput = value; }
    }
}
