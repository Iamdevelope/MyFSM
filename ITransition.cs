using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace PJW.FSM
{
    /// <summary>
    /// 状态过度
    /// </summary>
    public interface ITransition
    {
        /// <summary>
        /// 状态过度名
        /// </summary>
        string Name { get; }
        /// <summary>
        /// 从哪个状态来的
        /// </summary>
        IState From { get; set; }
        /// <summary>
        /// 需要过度到哪个状态
        /// </summary>
        IState To { get; set; }
        /// <summary>
        /// 是否可以进行状态过度
        /// </summary>
        /// <returns></returns>
        bool TransitionCallBack();
        /// <summary>
        /// 能否开始过度
        /// </summary>
        /// <returns>true：可以开始过度，false：不能开始过度</returns>
        bool IsBeginTransition();
    }
}
