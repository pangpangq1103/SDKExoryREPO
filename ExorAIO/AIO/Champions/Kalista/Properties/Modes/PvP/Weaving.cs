using System.Linq;
using ExorAIO.Utilities;
using LeagueSharp;
using LeagueSharp.SDK.UI;
using LeagueSharp.SDK.Utils;

namespace ExorAIO.Champions.Kalista
{
    /// <summary>
    ///     The logics class.
    /// </summary>
    internal partial class Logics
    {
        /// <summary>
        ///     Called on do-cast.
        /// </summary>
        /// <param name="sender">The sender.</param>
        /// <param name="args">The args.</param>
        public static void Weaving(Obj_AI_Base sender, GameObjectProcessSpellCastEventArgs args)
        {
            if (!(args.Target is Obj_AI_Hero) ||
                Invulnerable.Check(args.Target as Obj_AI_Hero))
            {
                return;
            }

            /// <summary>
            ///     The Q Weaving Logic.
            /// </summary>
            if (Vars.Q.IsReady() &&
                Vars.Menu["spells"]["q"]["combo"].GetValue<MenuBool>().Value)
            {
                if (!Vars.Q.GetPrediction(args.Target as Obj_AI_Hero).CollisionObjects.Any())
                {
                    Vars.Q.Cast(Vars.Q.GetPrediction(args.Target as Obj_AI_Hero).UnitPosition);
                }
                else if (Vars.Q.GetPrediction(args.Target as Obj_AI_Hero).CollisionObjects.Count(
                    c =>
                        c is Obj_AI_Minion &&
                        c.Health < KillSteal.GetPerfectRendDamage(c)) == Vars.Q.GetPrediction(args.Target as Obj_AI_Hero).CollisionObjects.Count())
                {
                    Vars.Q.Cast(Vars.Q.GetPrediction(args.Target as Obj_AI_Hero).UnitPosition);
                }
            }
        }
    }
}