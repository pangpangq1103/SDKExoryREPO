using System.Collections.Generic;
using System.Linq;
using ExorAIO.Utilities;
using LeagueSharp;
using LeagueSharp.SDK;
using LeagueSharp.SDK.Utils;

namespace ExorAIO.Champions.Anivia
{
    /// <summary>
    ///     The targets class.
    /// </summary>
    internal class Targets
    {
        /// <summary>
        ///     The main hero target.
        /// </summary>
        public static Obj_AI_Hero Target => Variables.TargetSelector.GetTarget(Vars.Q.Range, DamageType.Magical);

        /// <summary>
        ///     The minions target.
        /// </summary>
        public static List<Obj_AI_Minion> Minions
            =>
                GameObjects.EnemyMinions.Where(
                    m =>
                        m.IsMinion() &&
                        m.IsValidTarget(Vars.E.Range)).ToList();

        /// <summary>
        ///     The jungle minion targets.
        /// </summary>
        public static List<Obj_AI_Minion> JungleMinions
            =>
                GameObjects.Jungle.Where(
                    m =>
                        m.IsValidTarget(Vars.Q.Range) &&
                        !GameObjects.JungleSmall.Contains(m)).ToList();

        /// <summary>
        ///     The minions hit by the Q missile.
        /// </summary>
        public static List<Obj_AI_Minion> QMinions
            =>
                GameObjects.EnemyMinions.Concat(GameObjects.Jungle)
                    .Where(m => m.Distance(Anivia.QMissile.Position) < Vars.Q.Width)
                    .ToList();

        /// <summary>
        ///     The minions hit by the R missile.
        /// </summary>
        public static List<Obj_AI_Minion> RMinions
            =>
                GameObjects.EnemyMinions.Concat(GameObjects.Jungle)
                    .Where(m => m.Distance(Anivia.RMissile.Position) < Vars.R.Width)
                    .ToList();
    }
}