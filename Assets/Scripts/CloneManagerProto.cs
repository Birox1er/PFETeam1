using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;


public class CloneManagerProto : MonoBehaviour
{
    // poura être utiliser pour appliquer un état à tout les personnages en même temps ou d'autres choses dans le futur.
    [SerializeField] List<CloneProto> _characters=new List<CloneProto>();
    [SerializeField] int _currentPlayer = 0;
    
    public List<CloneProto> Characters { get => _characters; set => _characters = value; }

    public static CloneManagerProto instance;
    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else Destroy(this);
    }

    public void Switch(int charID)
    {
        if (_characters.Count > 0)
        {
            _characters[charID].GetComponent<PlayerInput>().enabled = false;
            charID++;
            if (charID >= _characters.Count)
            {
                charID = 0;
            }
            _characters[charID].GetComponent<PlayerInput>().enabled = true;
            _currentPlayer = charID;
            foreach (CloneProto c in _characters)
            {
                if (c.CharID != charID)
                {
                    c.GetComponentInChildren<BoxCollider>().enabled = true;
                }
                else 
                {
                    c.GetComponentInChildren<BoxCollider>().enabled = false;

                }
            }
        }
    }
}
