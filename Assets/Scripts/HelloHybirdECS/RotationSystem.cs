using System.Collections;
using System.Collections.Generic;
using Unity.Entities;
using Unity.Mathematics;
using UnityEngine;
using Unity.Transforms;

public class RotationSystem : ComponentSystem
{
    protected override void OnUpdate()
    {
        //凡是挂载了RotationComponent的Entity都会被这个函数所改变旋转角度
        Entities.ForEach((ref RotationComponent rotationComponent,
        ref Rotation rotation)=>
        {
            //在每帧计算旋转角度
            rotation.Value=math.mul(math.normalize(rotation.Value), //将原旋转角度标准化后，再乘以通过轴旋转后得到的旋转角度，得到在一帧时间后物体的旋转角度
            quaternion.AxisAngle(math.up(),rotationComponent.rotationSpeed*Time.DeltaTime));
        });
    }
}
