using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//池子类：存储不同种类的物体，方便后期使用
public class Pool : MonoBehaviour
{
    [HideInInspector]
    public Transform ThisGameObjectPosition;
    //池子可以存储很多种类的预设体，也可以单独设置成一类
    public List<PoolOption> poolsArray = new List<PoolOption>();

    private void Awake()
    {
        this.ThisGameObjectPosition = transform;
        PreLoadObject();
        PoolManager.Instance.Add(this);
    }

    void PreLoadObject()
    {

        for (int i = 0; i < poolsArray.Count; i++) {

            PoolOption option = poolsArray[i];
            for (int j = 0; j < option.IniPreLoadNumber; j++) {

                GameObject obj = option.PreLoad(option.Prefab, Vector3.zero, Quaternion.identity);
                obj.transform.parent = this.ThisGameObjectPosition;
            }
        }
    }

    public GameObject BirthGameObject(PoolTypes poolType, Vector3 pos, Quaternion rot) {

        GameObject obj = null;
        for (int i = 0; i < poolsArray.Count; i++) {

            PoolOption option = this.poolsArray[i];
            if (option.poolType == poolType) {

                obj = option.Active(pos, rot);
                if (obj == null) {

                    return null;
                }
                if (obj.transform.parent != ThisGameObjectPosition) {

                    obj.transform.parent = ThisGameObjectPosition;
                }
            }
        }
        return obj;
    }

    public void RecoverGameObject(GameObject instance) {

        for (int i = 0; i < poolsArray.Count; i++) {

            PoolOption option = poolsArray[i];
            if (option.ActiveGameObjectArray.Contains(instance)) {

                if (instance.transform.parent != this.ThisGameObjectPosition)
                    instance.transform.parent = ThisGameObjectPosition;
                option.Deactive(instance);
            }
        }
    }


    public void DestoryUnused() {

        for (int i = 0; i < this.poolsArray.Count; i++) {

            PoolOption option = poolsArray[i];
            option.ClearUpUnused();
        }
    }

    private void OnDestroy()
    {
        for (int i = 0; i < poolsArray.Count; i++) {

            PoolOption option = this.poolsArray[i];
            option.ClearAllArray();
        }
    }
}
