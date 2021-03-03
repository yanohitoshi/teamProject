using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

//CameraのProjectionはOrthographicに。

public class DragEvent : MonoBehaviour, IDragHandler
{
    [SerializeField]
    private GameObject gameObject;

    private Parts parts;
    private Animator animator;
    public void OnDrag(PointerEventData data)
	{
        parts = gameObject.GetComponent<Parts>();
        animator = gameObject.GetComponent<Animator>();
        if (parts.GetMove())
        {
            Vector3 TargetPos = Camera.main.ScreenToWorldPoint(data.position);
            TargetPos.z = 0;
            transform.position = TargetPos;
            animator.SetBool("Select", true);
        }

        //if (Input.GetMouseButtonUp(0))
        //{
        //    moveFlag = false;
        //}

        //Debug.Log(TargetPos);

        //Vector3 TargetPos = Camera.main.ScreenToWorldPoint(data.position);

    }
}

