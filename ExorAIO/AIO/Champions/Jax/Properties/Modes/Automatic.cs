using System;
using System.Linq;
using ExorAIO.Utilities;
using LeagueSharp.SDK;
using LeagueSharp.SDK.UI;
using LeagueSharp.SDK.Utils;

namespace ExorAIO.Champions.Jax
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
        public static void Automatic(EventArgs args)
        {
            if (GameObjects.Player.IsRecalling())
            {
                return;
            }

            /// <summary>
            ///     The Automatic R Logic.
            /// </summary>
            if (Vars.R.IsReady() && Vars.Menu["spells"]["r"]["logical"].GetValue<MenuBool>().Value)
            {
                if (GameObjects.Player.HealthPercent < 20 && GameObjects.Player.CountEnemyHeroesInRange(750f) > 0)
                {
                    Vars.R.Cast();
                }
                else if (GameObjects.Player.CountEnemyHeroesInRange(750f) >= 2)
                {
                    Vars.R.Cast();
                }
            }

            /// <summary>
            ///     The Automatic E Logic.
            /// </summary>
            if (Vars.E.IsReady() && !GameObjects.Player.IsUnderEnemyTurret() &&
                Vars.Menu["spells"]["e"]["logical"].GetValue<MenuBool>().Value)
            {
                foreach (var target in
                    GameObjects.EnemyHeroes.Where(t => !Invulnerable.Check(t) && t.IsValidTarget(Vars.E.Range)))
                {
                    Vars.E.Cast();
                }
            }
        }
    }
}