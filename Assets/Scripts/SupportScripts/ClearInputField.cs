using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClearInputField : MonoBehaviour
{
    [SerializeField] private UIInput input;

    private void OnClick()
    {
        input.value = "";
    }
}
