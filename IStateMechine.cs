using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace PJW.FSM
{
    /// <summary>
    /// 状态机
    /// </summary>
    public interface IStateMechine
    {
        /// <summary>
        /// 状态机的当前状态
        /// </summary>
        IState CurrentState { get; }
        /// <summary>
        /// 状态机的默认状态
        /// </summary>
        IState DefaultState { get; set; }
        /// <summary>
        /// 添加状态
        /// </summary>
        /// <param name="state">需要添加的状态</param>
        void AddState(IState state);
        /// <summary>
        /// 移除状态
        /// </summary>
        /// <param name="state">需要移除的状态</param>
        void RemoveState(IState state);
        /// <summary>
        /// 通过名字获取状态
        /// </summary>
        /// <param name="name">需要查找的状态的名字</param>
        /// <returns>查找到的状态</returns>
        IState GetStateByName(string name);
    }
}
