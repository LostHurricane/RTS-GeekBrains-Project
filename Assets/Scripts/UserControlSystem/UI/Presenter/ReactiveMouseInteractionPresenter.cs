using System.Linq;
using Abstractions;
using UniRx;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UIElements;
using UserControlSystem;

public sealed class ReactiveMouseInteractionPresenter : MonoBehaviour
{
    [SerializeField] private Camera _camera;
    [SerializeField] private SelectableValue _selectedObject;
    [SerializeField] private EventSystem _event;

    [SerializeField] private Vector3Value _groundClicksRMB;
    [SerializeField] private AttackableValue _attackablesRMB;
    [SerializeField] private Transform _groundTransform;

    private Plane _groundPlane;

    private void Start()
    {
        _groundPlane = new Plane(_groundTransform.up, 0);

        var leftClickObserver = Observable.EveryUpdate().Where(_ => Input.GetMouseButtonUp(0));
        var rightClickObserver = Observable.EveryUpdate().Where(_ => Input.GetMouseButton(1) && !Input.GetMouseButton(0));

        leftClickObserver.Subscribe(_ => LeftMouseClickProccessing());
        rightClickObserver.Subscribe(_ => RightMouseClickProccessing());
    }

    private void LeftMouseClickProccessing()
    {
        if (_event.IsPointerOverGameObject())
        {
            return;
        }

        var ray = _camera.ScreenPointToRay(Input.mousePosition);
        var hits = Physics.RaycastAll(ray);

        if (WeHit<ISelectable>(hits, out var selectable))
        {
            _selectedObject.SetValue(selectable);
        }
    }

    private void RightMouseClickProccessing()
    {
        if (_event.IsPointerOverGameObject())
        {
            return;
        }

        var ray = _camera.ScreenPointToRay(Input.mousePosition);
        var hits = Physics.RaycastAll(ray);

        if (WeHit<IAttackable>(hits, out var attackable))
        {
            _attackablesRMB.SetValue(attackable);
        }
        else if (_groundPlane.Raycast(ray, out var enter))
        {
            _groundClicksRMB.SetValue(ray.origin + ray.direction * enter);
        }
    }

    private bool WeHit<T>(RaycastHit[] hits, out T result) where T : class
    {
        result = default;
        if (hits.Length == 0)
        {
            return false;
        }
        result = hits
        .Select(hit => hit.collider.GetComponentInParent<T>())
        .Where(c => c != null)
        .FirstOrDefault();
        return result != default;
    }

}