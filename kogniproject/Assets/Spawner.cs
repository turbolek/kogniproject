using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour {

    public Player owner;
    StringDecoder decoder;

	// Use this for initialization
	void Start () {
        decoder = FindObjectOfType<StringDecoder>();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void spawnUnits (string _string)
    {
        List<Unit> units = decoder.GetUnitsToSpawn(_string);
        foreach (Unit unit in units)
        {
            StartCoroutine("spawnUnit", unit);
        }
    }

    public IEnumerator spawnUnit(Unit unit)
    {
        Unit _unit = Instantiate(unit, gameObject.transform.position, Quaternion.identity);
        _unit.transform.parent = gameObject.transform;
        _unit.owner = owner;
        _unit.transform.localScale = new Vector3(owner.direction, 1f, 1f);
        _unit.transform.GetChild(0).transform.localScale = new Vector3(owner.direction, 1f, 1f); ;
        yield return new WaitForSeconds(2f);
    }
}
