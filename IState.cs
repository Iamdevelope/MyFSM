using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace PJW.FSM
{
    /// <summary>
    /// 状态接口
    /// </summary>
    public interface IState
    {
        /// <summary>
        /// 当前状态的名字
        /// </summary>
        string Name { get; }
        /// <summary>
        /// 当前状态的状态机
        /// </summary>
        IStateMechine StateOfStateMechine { get; set; }
        /// <summary>
        /// 在当前状态内所耗费的时长
        /// </summary>
        float Timer { get; }
        /// <summary>
        /// 状态过度
        /// </summary>
        List<ITransition> Transitions { get; }
        /// <summary>
        /// 进入状态时的回调
        /// </summary>
        /// <param name="lastState">上一个状态</param>
        void EnterStateCallBack(IState lastState);
        /// <summary>
        /// 退出状态时回调
        /// </summary>
        /// <param name="nextState">下一个状态</param>
        void ExitStateCallBack(IState nextState);
        /// <summary>
        /// update回调
        /// </summary>
        /// <param name="deltaTime">Time.deltaTime</param>
        void UpdateCallBack(float deltaTime);
        /// <summary>
        /// LateUpdate的回调
        /// </summary>
        /// <param name="deltaTime">Time.deltaTime</param>
        void LateUpdateCallBack(float deltaTime);
        /// <summary>
        /// FixedUpdat的回调
        /// </summary>
        void FixedUpdateCallBack();

        /// <summary>
        /// 添加状态过度
        /// </summary>
        /// <param name="transition"></param>
        void AddTransitions(ITransition transition);
    }
}
