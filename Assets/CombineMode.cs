using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.InputSystem;

public class CombineMode : MonoBehaviour
{
    [SerializeField] private InputReader inputReader;
    [SerializeField] private CombineItems combineItems;

    public event UnityAction<CombineCloud> onFinishCombine;
    public event UnityAction onExitCombineMode;

    private Vector2 mousePos;
    private Camera cam;

    private void OnEnable()
    {
        inputReader.exitCombineModeEvent += ExitCombineMode;
        inputReader.cloudClickEvent += Clicked;
        inputReader.mouseMoveEvent += MousePosition;
        combineItems.onFinishCombine += ExitCombineMode;
    }
    private void OnDisable()
    {
        inputReader.exitCombineModeEvent -= ExitCombineMode;
        inputReader.cloudClickEvent -= Clicked;
        inputReader.mouseMoveEvent -= MousePosition;
        combineItems.onFinishCombine -= ExitCombineMode;
    }
    private void Start()
    {
        cam = Camera.main;
    }

    private CombineCloud CheckMouseItemClick()
    {
        Ray ray = cam.ScreenPointToRay(mousePos);
        if (!Physics.Raycast(ray, out RaycastHit hit)) return null;
        return hit.transform.GetComponent<CombineCloud>();
    }

    //Event methods
    private void ExitCombineMode()
    {
        inputReader.EnableGameplay();
        onExitCombineMode?.Invoke();
    }
    private void Clicked()
    {
        CombineCloud cloud = CheckMouseItemClick();
        if (cloud != null) { onFinishCombine?.Invoke(cloud); }
    }
    private void MousePosition(Vector2 value)
    {
        mousePos = value;
    }
}
