using Abstractions;
using UnityEngine;
using UserControlSystem;

public sealed class SelectableOutlinerPresenter : MonoBehaviour
{
    [SerializeField] private SelectableValue _selectedObject;
    private Outline _currentOutline;

    private void Start()
    {
        _selectedObject.OnSelected += ChangeSelection;
    }

    private void ChangeSelection(ISelectable selected)
    {
        if (selected is not MonoBehaviour selectable)
        {
            CleanCurrentOutline();
            return;
        }
        if (selectable.TryGetComponent<Outline>(out _))
        {
            return;
        }
        CleanCurrentOutline();
        var outline = selectable.gameObject.AddComponent<Outline>();
        SetOutlineParameters(outline);

        _currentOutline = outline;
    }

    private void CleanCurrentOutline()
    {
        if (_currentOutline != null)
        {
            Destroy(_currentOutline);
        }
    }

    private void SetOutlineParameters(Outline outline)
    {
        outline.OutlineColor = Color.red;
        outline.OutlineMode = Outline.Mode.OutlineVisible;
        outline.OutlineWidth = 4f;
    }

    private void OnDestroy()
    {
        _selectedObject.OnSelected -= ChangeSelection;
    }
}