using System.Collections;
using System.Collections.Generic;
using Unity.Entities;
using UnityEngine;

public class EntitiesManager : MonoBehaviour, IConvertGameObjectToEntity
{
    public float RotationSpeed=10f;
     //将gameObject转换为实体所必须的接口
    //在gameObject上还需要挂载自带的GameObject Convert to Entity脚本
    void IConvertGameObjectToEntity.Convert(Entity entity, EntityManager dstManager, GameObjectConversionSystem conversionSystem)
    {
        //创建一个RotationComponent
        RotationComponent rotationComponent = new RotationComponent{rotationSpeed=this.RotationSpeed};
        //将这个RotationComponent到当前脚本挂载的gameObject所转换类型的实体上，然后由EntityManager统一管理
        dstManager.AddComponentData(entity, rotationComponent);
    }
}
