using System.Linq;
using ExorAIO.Utilities;
using LeagueSharp;
using LeagueSharp.SDK.UI;
using LeagueSharp.SDK.Utils;

#pragma warning disable 1587

namespace ExorAIO.Champions.Quinn
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
            if (!(args.Target is Obj_AI_Hero) || Invulnerable.Check((Obj_AI_Hero)args.Target))
            {
                return;
            }

            /// <summary>
            ///     The Q Weaving Logic.
            /// </summary>
            if (Vars.Q.IsReady() && Vars.Menu["spells"]["q"]["combo"].GetValue<MenuBool>()
                                                                     .Value)
            {
                if (!Vars.Q.GetPrediction((Obj_AI_Hero)args.Target)
                         .CollisionObjects.Any())
                {
                    Vars.Q.Cast(Vars.Q.GetPrediction((Obj_AI_Hero)args.Target)
                                    .UnitPosition);
                    return;
                }
            }

            /// <summary>
            ///     The E Weaving Logic.
            /// </summary>
            if (Vars.E.IsReady() && Vars.Menu["spells"]["e"]["combo"].GetValue<MenuBool>()
                                                                     .Value)
            {
                Vars.E.CastOnUnit((Obj_AI_Hero)args.Target);
            }
        }
    }
}
