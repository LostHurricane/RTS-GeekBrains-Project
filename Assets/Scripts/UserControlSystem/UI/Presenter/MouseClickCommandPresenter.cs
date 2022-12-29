using Abstractions;
using Commands;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UserControlSystem;
using Zenject;

public class MouseClickCommandPresenter : MonoBehaviour
{

    [SerializeField] private SelectableValue _selectedObject;

    [Inject] private CommandButtonsModel _model;


    private void Start()
    {
        _selectedObject.OnNewValue += CheckType;
    }

    private void CheckType(ISelectable obj)
    {
        if (obj == null)
        {
            return;
        }
        if ((obj as Component).TryGetComponent<CommandExecutorBase<IMoveCommand>>(out var b))
        {
            //_model.OnCommandButtonClicked(b, null);
        }
    }

    private void OnDestroy()
    {
        _selectedObject.OnNewValue -= CheckType;

    }

}
