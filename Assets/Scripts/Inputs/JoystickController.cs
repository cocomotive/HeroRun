using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class JoystickController : Controller, IDragHandler, IEndDragHandler, IPointerDownHandler
{
    [SerializeField]
    ButtonsController controllerEnum;

    Vector3 dir;
    Vector3 initPosition;
    [SerializeField] float maxMagnitude;

    
    private void Start()
    {
        initPosition = transform.position;

        
    }

    /*
    public override Vector3 MoveDir()
    {
        return dir / maxMagnitude;
    }
    */
    public void OnPointerDown(PointerEventData eventData)
    {
        EventManager.events.SearchOrCreate<Enum, _Event, _EventButton>(controllerEnum).Trigger();
    }

    public void OnDrag(PointerEventData eventData)
    {
        Vector3 direction = Vector3.ClampMagnitude((Vector3)eventData.position - initPosition, maxMagnitude);
        transform.position = initPosition + direction;
        dir.x = direction.x;
        dir.z = direction.y;
        
        Quaternion rotation = Quaternion.Euler(dir.x, 0, 0);

        //_animatorController.PlayRun(true); 
        //_animatorController.PlayIdle(false);
        //_animatorController.PlayAttack(false);
    }       

    public void OnEndDrag(PointerEventData eventData)
    {
        //_animatorController.PlayIdle(true);
        //_animatorController.PlayRun(false);
        //_animatorController.PlayAttack(false);
        transform.position = initPosition;

        EventManager.events.SearchOrCreate<Enum, _Event, _EventButton>(controllerEnum).TriggerUp(dir / maxMagnitude);

        dir = Vector3.zero;
    }

    private void Update()
    {
        if(dir != Vector3.zero)
            EventManager.events.SearchOrCreate<Enum, _Event, _EventButton>(controllerEnum).TriggerPress(dir / maxMagnitude);
    }

    
}

public enum ButtonsController
{
    movement,
    attack,
    jump
}