using System.Collections;
using UnityEngine;

public class UnitCommannd : MonoBehaviour
{
    public LayerMask layerMask;
    private UnitSelect unitSelect;

    private Camera cam;

    private void Awake()
    {
        unitSelect =GetComponent<UnitSelect>();
    }

    private void Start()
    {
        cam = Camera.main;

        layerMask = LayerMask.GetMask("Unit", "Building", "Resource", "Ground");
    }

    private void Update()
    {
        if (Input.GetMouseButtonUp(1))
        {
            TryCommand(Input.mousePosition);
        }
    }

    private void UnitMoveToPosition(Vector3 _dest, Unit _unit)
    {
        if(_unit != null)
            _unit.MoveToPosition(_dest);
    }   

    private void CommandToGround(RaycastHit _hit, Unit _unit)
    {
        UnitMoveToPosition(_hit.point, _unit);
        CreateVFXMarker(_hit.point, MainUI.instance.SelectionMarker);
    }

    private void TryCommand(Vector2 _screenPos)
    {
        Ray ray = cam.ScreenPointToRay(_screenPos);
        RaycastHit hit;

        if(Physics.Raycast(ray, out hit, 1000, layerMask))
        {
            switch (hit.collider.tag)
            {
                case "Ground":
                    CommandToGround(hit, unitSelect.CurUnit);
                    break;
                       
            }
        }
    }

    private void CreateVFXMarker(Vector3 _pos, GameObject _vfxPrefab)
    {
        if (_vfxPrefab == null)
            return;

        Instantiate(_vfxPrefab, new Vector3(_pos.x, 0.1f, _pos.z), Quaternion.identity);
    }
}
