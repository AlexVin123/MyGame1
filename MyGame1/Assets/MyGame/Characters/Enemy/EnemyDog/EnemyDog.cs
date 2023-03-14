using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace EnemyDog
{
    [RequireComponent(typeof(MovementDirectionX))]
    [RequireComponent(typeof(StateMachineEnemy))]
    public class EnemyDog : Enemy
    {
        private StateMachineEnemy _stateMachine;
        private AttackCollaider _attackCollaider;
        private MovementDirectionX _movementDirectionX;

        public override void Attack()
        {
                _attackCollaider.Attack(float.Parse(Parameters.GetParameter(TypeParameter.Damage)));
        }

        public override void Init(GameObject target)
        {
            base.Init(target);
            _attackCollaider = GetComponentInChildren<AttackCollaider>();
            _stateMachine = GetComponent<StateMachineEnemy>();
            _stateMachine.Init(this, target);
            _stateMachine.ChaingeState.AddListener(Anim.OnChaingeState);
            _attackCollaider = GetComponentInChildren<AttackCollaider>();
            _movementDirectionX = GetComponent<MovementDirectionX>();
            _movementDirectionX.Init(Parameters);
        }

        public override void Move(Vector2 direction)
        {
            _movementDirectionX.Move(direction.x);
        }
    }
}
