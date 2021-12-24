using System;
using UnityEngine;
using StateV2;

namespace StateV2Example
{
    public class ExampleUnit : MonoBehaviour
    {
        //state machine variable
        private StateMachine _stateMachine;

        private bool _active;

        Func<bool> HasTarget => () => TargetInRange() != null;

        private Vector3 _destination;
        Func<bool> CanMove => () => CanMoveToDestination();

        private void Awake()
        {
            //create a new statemachine
            _stateMachine = new StateMachine();
            //construct the states used by this machine
            ConstructStates();
        }

        private void ConstructStates()
        {
            //create the states you want for this unit
            var _idleState = new ExampleUnitIdling(this);
            var _attackState = new ExampleUnitAttack(this);
            var _moveState = new ExampleUnitMove(this);

            //AddAnyTransition() is used to interupt ANY state when the condition is met
            _stateMachine.AddAnyTransition(_attackState, HasTarget);

            //create the path between the states
            At(_idleState, _moveState, CanMove);
            At(_moveState, _idleState, () => _active == false);

            //set the starting state
            _stateMachine.SetState(_idleState);
        }

        private void Update() => _stateMachine.Tick();

        private ExampleUnit TargetInRange()
        {
            //find if a target is in range
            ExampleUnit targetInRange = new ExampleUnit();
            return targetInRange;
        }

        private bool CanMoveToDestination()
        {
            if (TargetInRange() != null)
            {
                return false;
            }

            else if (_destination != null)
                return true;
            else return false;
        }

        //short hand for adding transitions from created states
        private void At(IState to, IState from, Func<bool> condition) => _stateMachine.AddTransition(to, from, condition);
    }
}