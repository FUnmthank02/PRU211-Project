using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets.Scripts
{
    public static class Constants
    {
        // Player's name
        public const string player_name = "Player";

        // Enermies's names
        public const string goblin_name = "goblin";
        public const string boss_name = "boss";

        // animation's names of enermy: "BOSS"
        public const string animation_boss_walk = "IsWalking";
        public const string animation_boss_hurt = "Hurt";
        public const string animation_boss_death = "Death";
        public const string animation_boss_attack = "Attack";
        public const string animation_boss_cast = "Cast";

        // animation's names of enermy: "GOBLIN"
        public const string animation_goblin_move = "IsMoving";
        public const string animation_goblin_attack = "Attack";
        public const string animation_goblin_death = "Death";
        public const string animation_goblin_take_hit = "TakeHit";

        // animation's names of enermy: "SKELETON"
        public const string animation_skeleton_move = "IsWalking";
        public const string animation_skeleton_attack = "Attack";
        public const string animation_skeleton_death = "Death";
        public const string animation_skeleton_take_hit = "TakeHit";
        public const string animation_skeleton_shield = "Shield";
    }
}
