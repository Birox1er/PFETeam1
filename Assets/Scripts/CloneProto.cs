using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class CloneProto : MonoBehaviour
{
    [SerializeField] private List<GameObject> _clones;
    [SerializeField] private int _currentClone = 0;
    [SerializeField] private int _charID;
    [SerializeField] private GameObject _spawnPoint;//temp
    private PlayerInput _inputs;

    public int CharID { get => _charID;}

    private void Start()
    {
        _charID = CloneManagerProto.instance.Characters.Count;
        CloneManagerProto.instance.Characters.Add(this);
        print(CloneManagerProto.instance.name);
    }
    public void Cloned(InputAction.CallbackContext context)
    {
        if (context.performed)
        {
            if (_currentClone < _clones.Count)//condition à changer.
            {
                GameObject instantiatedClone = Instantiate(_clones[_currentClone], _spawnPoint.transform.position, _spawnPoint.transform.rotation);
                instantiatedClone.name = "feur";
                _currentClone++;
            }
        }
    }
    public void Switch(InputAction.CallbackContext context)
    {
        if (context.performed)
        {
            CloneManagerProto.instance.Switch(_charID);

        }
    }

}
