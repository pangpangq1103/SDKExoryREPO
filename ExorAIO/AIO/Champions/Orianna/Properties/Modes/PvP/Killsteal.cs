using System;
using System.Linq;
using ExorAIO.Utilities;
using LeagueSharp;
using LeagueSharp.SDK;
using LeagueSharp.SDK.UI;
using LeagueSharp.SDK.Utils;

#pragma warning disable 1587

namespace ExorAIO.Champions.Orianna
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
        public static void Killsteal(EventArgs args)
        {
            /// <summary>
            ///     The KillSteal Q Logic.
            /// </summary>
            if (Vars.Q.IsReady() &&
                Vars.Menu["spells"]["q"]["killsteal"].GetValue<MenuBool>().Value)
            {
                foreach (
                    var target in
                        GameObjects.EnemyHeroes.Where(
                            t =>
                                !Invulnerable.Check(t) && t.IsValidTarget(Vars.Q.Range) &&
                                Vars.GetRealHealth(t) < (float) GameObjects.Player.GetSpellDamage(t, SpellSlot.Q)))
                {
                    Vars.Q.Cast(Vars.Q.GetPrediction(target).CastPosition);
                }
            }

            /// <summary>
            ///     The KillSteal W Logic.
            /// </summary>
            if (Vars.W.IsReady() &&
                Vars.Menu["spells"]["w"]["killsteal"].GetValue<MenuBool>().Value)
            {
                if (GameObjects.EnemyHeroes.Any(
                    t =>
                        t.IsValidTarget() && !Invulnerable.Check(t) &&
                        t.Distance(Orianna.BallPosition) < Vars.W.Range &&
                        Vars.GetRealHealth(t) < (float) GameObjects.Player.GetSpellDamage(t, SpellSlot.W)))
                {
                    Vars.W.Cast();
                }
            }

            /// <summary>
            ///     The KillSteal R Logic.
            /// </summary>
            if (Vars.R.IsReady() &&
                Vars.Menu["spells"]["r"]["killsteal"].GetValue<MenuBool>().Value)
            {
                if (
                    GameObjects.EnemyHeroes.Any(
                        t =>
                            t.IsValidTarget() && !Invulnerable.Check(t) &&
                            t.Distance(Orianna.BallPosition) < Vars.R.Range &&
                            Vars.GetRealHealth(t) > (float) GameObjects.Player.GetSpellDamage(t, SpellSlot.W) &&
                            Vars.GetRealHealth(t) < (float) GameObjects.Player.GetSpellDamage(t, SpellSlot.R)))
                {
                    Vars.R.Cast();
                }
            }
        }
    }
}
