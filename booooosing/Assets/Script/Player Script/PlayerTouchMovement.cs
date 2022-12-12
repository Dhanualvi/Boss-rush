using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem.EnhancedTouch;
using ETouch = UnityEngine.InputSystem.EnhancedTouch;

public class PlayerTouchMovement : MonoBehaviour
{
    [SerializeField] Vector2 joystickSize = new Vector2(300, 300);
    [SerializeField] FloatingJoystick joystick;

    Finger movementFinger;
    Vector2 movementAmount;

    private void OnEnable()
    {
        EnhancedTouchSupport.Enable();
        ETouch.Touch.onFingerDown += HandleFingerDown;
        ETouch.Touch.onFingerUp += Touch_onFingerUp;
        ETouch.Touch.onFingerMove += HandleFingerMove;
    }
    private void OnDisable()
    {
        ETouch.Touch.onFingerDown -= HandleFingerDown;
        ETouch.Touch.onFingerUp -= Touch_onFingerUp;
        ETouch.Touch.onFingerMove -= HandleFingerMove;
        EnhancedTouchSupport.Disable();
    }
    private void HandleFingerMove(Finger movedFinger)
    {
        if(movedFinger == movementFinger)
        {
            Vector2 knobPosition;
            float maxMovement = joystickSize.x / 2f;
            ETouch.Touch currentTouch = movedFinger.currentTouch;

            if (Vector2.Distance(currentTouch.screenPosition, joystick.RectTransform.anchoredPosition) > maxMovement )
            {
                knobPosition = (currentTouch.screenPosition - joystick.RectTransform.anchoredPosition).normalized * maxMovement;
            }
            else
            {
                knobPosition = currentTouch.screenPosition - joystick.RectTransform.anchoredPosition;
            }

            
        }
    }

    private void Touch_onFingerUp(Finger obj)
    {
        throw new NotImplementedException();
    }

    

    private void HandleFingerDown(Finger touchedFinger)
    {
        if(movementFinger == null && touchedFinger.screenPosition.x <= Screen.width / 2f)
        {
            movementFinger = touchedFinger;
            movementAmount = Vector2.zero;
            joystick.gameObject.SetActive(true);
            joystick.RectTransform.sizeDelta = joystickSize;
            joystick.RectTransform.anchoredPosition = ClampStartPosition(touchedFinger.screenPosition);
        }
    }
    private Vector2 ClampStartPosition(Vector2 StartPosition)
    {
        if (StartPosition.x < joystickSize.x / 2)
        {
            StartPosition.x = joystickSize.x / 2;
        }

        if (StartPosition.y < joystickSize.y / 2)
        {
            StartPosition.y = joystickSize.y / 2;
        }
        else if (StartPosition.y > Screen.height - joystickSize.y / 2)
        {
            StartPosition.y = Screen.height - joystickSize.y / 2;
        }

        return StartPosition;
    }
}
