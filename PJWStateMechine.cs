using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace PJW.FSM
{
    /// <summary>
    /// 状态机类
    /// </summary>
    public class PJWStateMechine : PJWState, IStateMechine
    {
        private IState currentState;
        private IState defaultState;
        private List<IState> stateList;
        private bool isTransition;  //是否可以开始过度
        private ITransition tempTransition;
        
        public IState CurrentState
        {
            get
            {
                return currentState;
            }
        }

        public IState DefaultState {
            get
            {
                return defaultState;
            }
            set
            {
                //检测设置默认状态时，是否存在当前状态机中
                AddState(value);
                defaultState = value;
            }
        }

        public PJWStateMechine(string name,IState defaultState) : base(name)
        {
            stateList = new List<IState>();
            this.defaultState = defaultState;
        }
        /// <summary>
        /// 移除状态
        /// </summary>
        /// <param name="state">需要移除的状态</param>
        public void RemoveState(IState state)
        {
            //不能删除当前状态
            if (currentState == state) return;
            if (state != null && stateList.Contains(state))
            {
                stateList.Remove(state);
                //将移除的状态的状态机设置为空
                state.StateOfStateMechine = null;
                //在移除状态时，如果移除的状态时默认状态，则需要重新指定默认状态
                if (defaultState == state)
                    defaultState = (stateList.Count > 1) ? stateList[0] : null;
            }
        }
        /// <summary>
        /// 添加状态
        /// </summary>
        /// <param name="state">需要添加的状态</param>
        public void AddState(IState state)
        {
            if (state != null && !stateList.Contains(state))
            {
                stateList.Add(state);
                //将新加入的状态的状态机设置为当前状态机
                state.StateOfStateMechine = this;
                //如果当前状态中没有默认状态，则将第一个加入的状态设置为默认状态
                if (defaultState == null)
                    defaultState = state;
            }
        }
        /// <summary>
        /// 通过名字获取状态
        /// </summary>
        /// <param name="name">需要查找的状态的名字</param>
        /// <returns>查找到的状态</returns>
        public IState GetStateByName(string name)
        {
            IState temp = null;
            for (int i = 0; i < stateList.Count; i++)
            {
                if (stateList[i].Name == name)
                    temp = stateList[i];
            }
            return temp;
        }
        public override void UpdateCallBack(float deltaTime)
        {
            if (isTransition)
            {
                //判断当前过度是否结束
                if (tempTransition.TransitionCallBack())
                {
                    DoTransition(tempTransition);
                    isTransition = false;
                }
                return;
            }
            base.UpdateCallBack(deltaTime);
            //如果当前状态为空了，则将当前状态设为默认状态
            if (currentState == null)
                currentState = defaultState;
            List<ITransition> temp = currentState.Transitions;
            int count = temp.Count;
            for (int i = 0; i < count; i++)
            {
                ITransition it = temp[i];
                //满足条件可以开始过度
                if (it.IsBeginTransition())
                {
                    isTransition = true;
                    tempTransition = it;
                    return;
                }
            }
            currentState.UpdateCallBack(deltaTime);
        }
        public override void LateUpdateCallBack(float deltaTime)
        {
            base.LateUpdateCallBack(deltaTime);
            currentState.LateUpdateCallBack(deltaTime);
        }
        public override void FixedUpdateCallBack()
        {
            base.FixedUpdateCallBack();
            currentState.FixedUpdateCallBack();
        }
        /// <summary>
        /// 开始过度
        /// </summary>
        /// <param name="t"></param>
        private void DoTransition(ITransition t)
        {
            //退出当前状态
            currentState.ExitStateCallBack(t.To);
            //切换当前状态
            currentState = t.To;
            //进入到下一个状态
            currentState.EnterStateCallBack(t.From);
        }
    }
}
