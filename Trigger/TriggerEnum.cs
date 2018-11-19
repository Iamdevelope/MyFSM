using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace PJW.FramingExperience
{
    /// <summary>
    /// 条件枚举
    /// </summary>
    public enum TriggerEnum
    {
        /// <summary>
        /// 水打满的条件
        /// </summary>
        WaterFullTrigger,
        /// <summary>
        /// 喂食牲畜的条件
        /// </summary>
        FeedFoodTrigger,
        /// <summary>
        /// 收割水稻的条件
        /// </summary>
        HarvesRiceTrigger,
        /// <summary>
        /// 摘包菜的条件
        /// </summary>
        GripBunTrigger,
        /// <summary>
        /// 拔胡萝卜的条件
        /// </summary>
        DrawCarrotTrigger,
        /// <summary>
        /// 摘茄子的条件
        /// </summary>
        GripAubergineTrigger,
        /// <summary>
        /// 挖洋葱的条件
        /// </summary>
        DigOnionTrigger,
        /// <summary>
        /// 摘蔬菜的条件
        /// </summary>
        GripVegetableTrigger,
        /// <summary>
        /// 做饭的条件
        /// </summary>
        HaviedLunchTrigger,
        /// <summary>
        /// 摘向日葵的条件
        /// </summary>
        GripSunflowerTrigger,
        /// <summary>
        /// 摘玉米的条件
        /// </summary>
        GripCornTrigger
    }
}