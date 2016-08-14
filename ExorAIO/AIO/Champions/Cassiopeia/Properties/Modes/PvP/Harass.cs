
#pragma warning disable 1587

namespace ExorAIO.Champions.Cassiopeia
{
    using System;
    using System.Linq;

    using ExorAIO.Utilities;

    using LeagueSharp;
    using LeagueSharp.SDK;
    using LeagueSharp.SDK.UI;
    using LeagueSharp.SDK.Utils;

    /// <summary>
    ///     The logics class.
    /// </summary>
    internal partial class Logics
    {
        #region Public Methods and Operators

        /// <summary>
        ///     Called when the game updates itself.
        /// </summary>
        /// <param name="args">The <see cref="EventArgs" /> instance containing the event data.</param>
        public static void Harass(EventArgs args)
        {
            if (!Targets.Target.IsValidTarget() || Invulnerable.Check(Targets.Target, DamageType.Magical, false))
            {
                return;
            }

            /// <summary>
            ///     The E Combo Logic.
            /// </summary>
            if (Vars.E.IsReady() && Vars.Menu["spells"]["e"]["harass"].GetValue<MenuSliderButton>().BValue
                && GameObjects.Player.ManaPercent
                > ManaManager.GetNeededMana(Vars.E.Slot, Vars.Menu["spells"]["e"]["harass"]))
            {
                foreach (var target in
                    GameObjects.EnemyHeroes.Where(
                        t =>
                        t.IsValidTarget(Vars.E.Range)
                        && (t.HasBuffOfType(BuffType.Poison)
                            || !Vars.Menu["spells"]["e"]["harasspoison"].GetValue<MenuBool>().Value)
                        && !Invulnerable.Check(t, DamageType.Magical)))
                {
                    DelayAction.Add(
                        Vars.Menu["spells"]["e"]["delay"].GetValue<MenuSlider>().Value,
                        () => { Vars.E.CastOnUnit(target); });
                }
            }

            if (!Targets.Target.IsValidTarget() || Invulnerable.Check(Targets.Target, DamageType.Magical, false))
            {
                return;
            }

            /// <summary>
            ///     The Q Combo Logic.
            /// </summary>
            if (Vars.Q.IsReady() && Targets.Target.IsValidTarget(Vars.Q.Range)
                && GameObjects.Player.ManaPercent
                > ManaManager.GetNeededMana(Vars.Q.Slot, Vars.Menu["spells"]["q"]["harass"])
                && Vars.Menu["spells"]["q"]["harass"].GetValue<MenuSliderButton>().BValue)
            {
                Vars.Q.Cast(Vars.Q.GetPrediction(Targets.Target).CastPosition);
                return;
            }

            /// <summary>
            ///     The W Combo Logic.
            /// </summary>
            DelayAction.Add(
                1000,
                () =>
                    {
                        if (Vars.W.IsReady() && Targets.Target.IsValidTarget(Vars.W.Range)
                            && GameObjects.Player.ManaPercent
                            > ManaManager.GetNeededMana(Vars.W.Slot, Vars.Menu["spells"]["w"]["harass"])
                            && Vars.Menu["spells"]["w"]["harass"].GetValue<MenuSliderButton>().BValue)
                        {
                            Vars.W.Cast(Vars.W.GetPrediction(Targets.Target).CastPosition);
                        }
                    });
        }

        #endregion
    }
}