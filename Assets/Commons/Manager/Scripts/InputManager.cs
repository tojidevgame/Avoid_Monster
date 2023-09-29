using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InputManager : MonoBehaviour
{
    [SerializeField] private Image blockInput;

    public void BlockInput(bool block)
    {
        blockInput.gameObject.SetActive(block);
    }
}
