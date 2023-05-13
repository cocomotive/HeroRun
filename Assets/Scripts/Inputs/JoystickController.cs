using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class JoystickController : Controller, IDragHandler, IEndDragHandler
{
    
    Vector3 dir;
    Vector3 initPosition;
    [SerializeField] float maxMagnitude;
    [SerializeField] Animator _animator;
    [SerializeField] AnimatorController _animatorController;
    [SerializeField] Movement _movements;

    
    private void Start()
    {
        initPosition = transform.position;
        _animatorController = new AnimatorController(_animator);
        
    }

    public JoystickController(AnimatorController animatorController)
    {
        _animatorController = animatorController;
    }


    public override Vector3 MoveDir()
    {
        return dir / maxMagnitude;
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
        dir = Vector3.zero;
        
    }

    
}
