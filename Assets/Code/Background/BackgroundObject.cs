using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public sealed class BackgroundObject 
{
    private GameObject _backgroundObjectPrefab;
    private int _backgroundObjecrZOrder;
    public BackgroundObject(GameObject bgObjPrefab, int bgObjZOrder)
    {
        _backgroundObjectPrefab = GameObject.Instantiate(bgObjPrefab);
        _backgroundObjecrZOrder = bgObjZOrder;
    }

    public GameObject BackgroundObjectPrefafab => _backgroundObjectPrefab;
    public int BackGroundObjectZOrder
    {
        get
        {
            return _backgroundObjecrZOrder;
        }
        set
        {
            _backgroundObjecrZOrder = value;
        }
    }
}
