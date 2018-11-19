using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace PJW.FSM
{
    public delegate void PJWDelegate();
    public delegate void PJWDelegateState(IState state);
    public delegate void PJWDelegateFloat(float f);
    /// <summary>
    /// 状态
    /// </summary>
    public class PJWState : IState
    {
        private string name;
        private IStateMechine currentStateMechine;
        private float time;
        private List<ITransition> transitions;
        
        public PJWState(string StateName)
        {
            name = StateName;
            transitions = new List<ITransition>();
        }
        /// <summary>
        /// 当前状态的名字
        /// </summary>
        public string Name
        {
            get
            {
                return name;
            }
        }
        /// <summary>
        /// 当前状态的状态机
        /// </summary>
        public IStateMechine StateOfStateMechine {
            get
            {
                return currentStateMechine;
            }
            set
            {
                currentStateMechine = value;
            }
        }
        /// <summary>
        /// 在当前状态内所耗费的时长
        /// </summary>
        public float Timer {
            get
            {
                return time;
            }
        }
        /// <summary>
        /// 状态过度
        /// </summary>
        public List<ITransition> Transitions
        {
            get
            {
                return transitions;
            }
        }
        /// <summary>
        /// 进入状态时的事件
        /// </summary>
        public event PJWDelegateState OnEnterStateHandle;
        /// <summary>
        /// 离开装填时的事件
        /// </summary>
        public event PJWDelegateState ExitStateHandle;
        /// <summary>
        /// update的事件
        /// </summary>
        public event PJWDelegateFloat UpdateHandle;
        /// <summary>
        /// Late Update的事件
        /// </summary>
        public event PJWDelegateFloat LateUpdateHandle;
        /// <summary>
        /// Fixed Update的事件
        /// </summary>
        public event PJWDelegate FixedUpdateHandle;

        /// <summary>
        /// 进入状态的回调
        /// </summary>
        /// <param name="lastState"></param>
        public virtual void EnterStateCallBack(IState lastState)
        {
            //重置累加时长
            time = 0;
            if (OnEnterStateHandle != null)
                OnEnterStateHandle(lastState);
        }
        /// <summary>
        /// 离开状态的回调
        /// </summary>
        /// <param name="nextState"></param>
        public virtual void ExitStateCallBack(IState nextState)
        {
            if (ExitStateHandle != null)
                ExitStateHandle(nextState);
        }
        /// <summary>
        /// Fixed Update的回调
        /// </summary>
        public virtual void FixedUpdateCallBack()
        {
            if (FixedUpdateHandle != null)
                FixedUpdateHandle();
        }
        /// <summary>
        /// Late Update的回调
        /// </summary>
        /// <param name="deltaTime"></param>
        public virtual void LateUpdateCallBack(float deltaTime)
        {
            if (LateUpdateHandle != null)
                LateUpdateHandle(deltaTime);
        }
        /// <summary>
        /// Update的回调
        /// </summary>
        /// <param name="deltaTime"></param>
        public virtual void UpdateCallBack(float deltaTime)
        {
            //计算当前状态所用时长
            time += deltaTime;
            if (UpdateHandle != null)
                UpdateHandle(deltaTime);
        }

        /// <summary>
        /// 向当前状态中添加过度
        /// </summary>
        /// <param name="transition"></param>
        public void AddTransitions(ITransition transition)
        {
            if (transition != null && !transitions.Contains(transition))
                transitions.Add(transition);
        }
    }
}
