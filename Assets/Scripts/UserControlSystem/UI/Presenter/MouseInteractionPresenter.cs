using System.Linq;
using Abstractions;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UIElements;
using UserControlSystem;

public sealed class MouseInteractionPresenter : MonoBehaviour
{
    [SerializeField] private Camera _camera;
    [SerializeField] private SelectableValue _selectedObject;
    [SerializeField] private EventSystem _event;

    [SerializeField] private Vector3Value _groundClicksRMB;
    [SerializeField] private Transform _groundTransform;

    private Plane _groundPlane;

    private void Start()
    {
        _groundPlane = new Plane(_groundTransform.up, 0);
    }

    private void Update()
    {
        if (_event.IsPointerOverGameObject())
        {
            return;
        }
        if (!Input.GetMouseButtonUp(0) && !Input.GetMouseButton(1))
        {
            return;
        }
        var ray = _camera.ScreenPointToRay(Input.mousePosition);
        if (Input.GetMouseButtonUp(0))
        {
            var hits = Physics.RaycastAll(ray);
            if (hits.Length == 0)
            {
                return;
            }
            var selectable = hits
            .Select(hit =>
            hit.collider.GetComponentInParent<ISelectable>())
            .Where(c => c != null)
            .FirstOrDefault();
            _selectedObject.SetValue(selectable);
        }
        else
        {
            if (_groundPlane.Raycast(ray, out var enter))
            {
                _groundClicksRMB.SetValue(ray.origin + ray.direction * enter);
            }
        }

    }
}