using System;
using System.Linq;
using ExorAIO.Utilities;
using LeagueSharp;
using LeagueSharp.SDK;
using LeagueSharp.SDK.UI;
using LeagueSharp.SDK.Utils;

namespace ExorAIO.Champions.Cassiopeia
{
    /// <summary>
    ///     The logics class.
    /// </summary>
    internal partial class Logics
    {
        /// <summary>
        ///     Called when the game updates itself.
        /// </summary>
        /// <param name="args">The <see cref="EventArgs" /> instance containing the event data.</param>
        public static void Combo(EventArgs args)
        {
            if (Bools.HasSheenBuff())
            {
                return;
            }

            /// <summary>
            ///     The E Combo Logic.
            /// </summary>
            if (Vars.E.IsReady() && Vars.Menu["spells"]["e"]["combo"].GetValue<MenuBool>().Value)
            {
                foreach (var target in
                    GameObjects.EnemyHeroes.Where(
                        t =>
                            t.IsValidTarget(Vars.E.Range) && t.HasBuffOfType(BuffType.Poison) &&
                            !Invulnerable.Check(t, DamageType.Magical)))
                {
                    DelayAction.Add(
                        Vars.Menu["spells"]["e"]["delay"].GetValue<MenuSlider>().Value,
                        () => { Vars.E.CastOnUnit(Targets.Target); });
                }
            }

            if (!Targets.Target.IsValidTarget() || Invulnerable.Check(Targets.Target, DamageType.Magical))
            {
                return;
            }

            /// <summary>
            ///     The R Combo Logic.
            /// </summary>
            if (Vars.R.IsReady() && Vars.Menu["spells"]["r"]["combo"].GetValue<MenuSliderButton>().BValue &&
                Vars.Menu["spells"]["r"]["combo"].GetValue<MenuSliderButton>().SValue <= Targets.RTargets.Count())
            {
                Vars.R.Cast(Targets.RTargets[0].ServerPosition);
            }

            if (Targets.Target.HasBuffOfType(BuffType.Poison))
            {
                return;
            }

            /// <summary>
            ///     The Q Combo Logic.
            /// </summary>
            if (Vars.Q.IsReady() && Targets.Target.IsValidTarget(Vars.Q.Range) &&
                Vars.Menu["spells"]["q"]["combo"].GetValue<MenuBool>().Value)
            {
                Vars.Q.Cast(Vars.Q.GetPrediction(Targets.Target).CastPosition);
                return;
            }

            DelayAction.Add(
                1000, () =>
                {
                    /// <summary>
                    ///     The W Combo Logic.
                    /// </summary>
                    if (Vars.W.IsReady() && Targets.Target.IsValidTarget(Vars.W.Range) &&
                        !Targets.Target.IsValidTarget(Vars.AARange) &&
                        Vars.Menu["spells"]["w"]["combo"].GetValue<MenuBool>().Value)
                    {
                        Vars.W.Cast(Vars.W.GetPrediction(Targets.Target).CastPosition);
                    }
                });
        }
    }
}