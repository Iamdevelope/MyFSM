using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace PJW.FramingExperience
{
    /// <summary>
    /// 状态枚举
    /// </summary>
    public enum StateEnum
    {
        /// <summary>
        /// 打水状态
        /// </summary>
        WaveWater,
        /// <summary>
        /// 喂家畜状态
        /// </summary>
        FeedLivestock,
        /// <summary>
        /// 收割水稻状态
        /// </summary>
        HarvesRice,
        /// <summary>
        /// 摘包菜状态
        /// </summary>
        GripBun,
        /// <summary>
        /// 拔胡萝卜状态
        /// </summary>
        DrawCarrot,
        /// <summary>
        /// 摘茄子状态
        /// </summary>
        GripAubergine,
        /// <summary>
        /// 挖洋葱状态
        /// </summary>
        DigOnion,
        /// <summary>
        /// 摘蔬菜状态
        /// </summary>
        GripVegetable,
        /// <summary>
        /// 做饭状态
        /// </summary>
        MakeLunch,
        /// <summary>
        /// 摘向日葵状态
        /// </summary>
        GripSunflower,
        /// <summary>
        /// 摘玉米状态
        /// </summary>
        GripCorn
    }
}
