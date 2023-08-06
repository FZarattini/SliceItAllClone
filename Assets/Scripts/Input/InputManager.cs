using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Sirenix.OdinInspector;
using UnityEngine.InputSystem;
using System;

public class InputManager : MonoBehaviour
{
    public static InputManager Instance;

    [Title("Data and References")]
    [SerializeField] SliceInputs _inputs;

    public static Action<bool> OnTouchActionPerformed = null;
    public static Action<bool> OnClickActionPerformed = null;


    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
        }
        else
        {
            Instance = this;
        }

        DontDestroyOnLoad(gameObject);
    }

    private void OnEnable()
    {
        _inputs = new SliceInputs();

        _inputs.Touch.Touch.performed += OnTouchPerformed;
        _inputs.Touch.Click.performed += OnClickPerformed;

        _inputs.Enable();
    }

    private void OnDisable()
    {
        _inputs.Touch.Touch.performed -= OnTouchPerformed;
        _inputs.Touch.Click.performed -= OnClickPerformed;

        _inputs.Disable();
    }

    void OnTouchPerformed(InputAction.CallbackContext context)
    {
        OnTouchActionPerformed?.Invoke(true);
    }

    void OnClickPerformed(InputAction.CallbackContext context)
    {
        OnClickActionPerformed?.Invoke(true);
    }
}
