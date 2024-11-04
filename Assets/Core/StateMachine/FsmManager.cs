

namespace Scipts.StateMachine
{
    public class FsmManager
    {
        private IFsm m_CurrentState;

        public void ChangeToState(IFsm toState)
        {
            m_CurrentState?.ExitState();
            m_CurrentState = toState;
            m_CurrentState.EnterState();
        }

        public void ExitCurrentState()
        {
            m_CurrentState?.ExitState();
            m_CurrentState = null;
        }

        public void UpdateState()
        {
            m_CurrentState?.Update();
        }
    }
}