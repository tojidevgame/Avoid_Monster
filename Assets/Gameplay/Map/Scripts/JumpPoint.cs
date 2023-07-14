using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum DirectJumpPoint
{
    NONE,
    JUMP_LEFT,
    JUMP_RIGHT
}
public class JumpPoint : MonoBehaviour
{
    [SerializeField] private DirectJumpPoint directJump;
    public DirectJumpPoint DirectJump { get { return directJump; } }
}
