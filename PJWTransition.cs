using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace PJW.FSM
{
    public delegate bool TransitionDelegate();
    /// <summary>
    /// 状态过度
    /// </summary>
    public class PJWTransition : ITransition
    {
        private IState fromState;
        private IState toState;
        private string transitionName;

        /// <summary>
        /// 在状态过度过程中的事件
        /// </summary>
        public event TransitionDelegate OnTransitionHandle;
        /// <summary>
        /// 检测是否满足状态过度的事件
        /// </summary>
        public event TransitionDelegate TransitionCheckHandle;

        public PJWTransition(string name,IState from,IState to)
        {
            transitionName = name;
            fromState = from;
            toState = to;
        }
        /// <summary>
        /// 过度名
        /// </summary>
        public string Name {
            get
            {
                return transitionName;
            }
        }
        /// <summary>
        /// 从哪个状态来的
        /// </summary>
        public IState From
        {
            get
            {
                return fromState;
            }
            set
            {
                fromState = value;
            }
        }
        /// <summary>
        /// 需要过度到哪个状态
        /// </summary>
        public IState To {
            get
            {
                return toState;
            }
            set
            {
                toState = value;
            }
         }
        /// <summary>
        /// 是否可以过度到一个状态的回调函数
        /// </summary>
        /// <returns>true:过度结束；false:继续过度</returns>
        public bool TransitionCallBack()
        {
            if (OnTransitionHandle != null)
                return OnTransitionHandle();
            return true;
        }
        /// <summary>
        /// 能否开始过度
        /// </summary>
        /// <returns>true：可以开始过度，false：不能开始过度</returns>
        public bool IsBeginTransition()
        {
            if (TransitionCheckHandle != null)
                return TransitionCheckHandle();
            return false;
        }
    }
}
