using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

[System.Serializable]
public class PoolOption
{
    public PoolTypes poolType;
    //预设体的名字
    public string PrefabName;
    //需要加载的预设体
    public GameObject Prefab;
    //需要加载的数量
    public int IniPreLoadNumber;

    [HideInInspector]
    public List<GameObject> ActiveGameObjectArray = new List<GameObject>();

    [HideInInspector]
    public List<GameObject> InActiveGameObjectArray = new List<GameObject>();

    internal GameObject PreLoad(GameObject prefab, Vector3 position, Quaternion rotation) {

        GameObject obj = null;
        if (prefab) {

            obj = Object.Instantiate(prefab, position, rotation) as GameObject;
            obj.SetActive(false);
            InActiveGameObjectArray.Add(obj);
        }
        return obj;
    }

    internal GameObject Active(Vector3 pos, Quaternion rot) {

        GameObject obj;
        if (InActiveGameObjectArray.Count != 0)
        {

            obj = InActiveGameObjectArray[0];
            InActiveGameObjectArray.RemoveAt(0);
        }
        else {

            obj = Object.Instantiate(Prefab, pos, rot) as GameObject;
        }

        obj.transform.position = pos;
        obj.transform.rotation = rot;
        ActiveGameObjectArray.Add(obj);
        obj.SetActive(true);
        return obj;
    }

    internal void Deactive(GameObject obj) {

        InActiveGameObjectArray.Add(obj);
        ActiveGameObjectArray.Remove(obj);
        obj.SetActive(false);
    }

    internal int TotalCount{

        get{

            int count = 0;
            count += this.ActiveGameObjectArray.Count;
            count += this.InActiveGameObjectArray.Count;
            return count;
        }
    }

    internal void ClearAllArray() {

        ActiveGameObjectArray.Clear();
        InActiveGameObjectArray.Clear();
    }

    internal void ClearUpUnused() {

        foreach (GameObject item in InActiveGameObjectArray)
        {
            Object.Destroy(item);
        }
        InActiveGameObjectArray.Clear();
    }
}
