using System;
using System.Linq;
using ExorAIO.Utilities;
using LeagueSharp;
using LeagueSharp.SDK;
using LeagueSharp.SDK.UI;
using LeagueSharp.SDK.Utils;

namespace ExorAIO.Champions.Ryze
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
            if (!Targets.Target.IsValidTarget() ||
                Invulnerable.Check(Targets.Target, DamageType.Magical))
            {
                return;
            }
            
            if (Bools.HasSheenBuff() &&
                Targets.Target.IsValidTarget(Vars.AARange))
            {
                return;
            }

            /// <summary>
            ///     Dynamic Combo Logic.
            /// </summary>
            switch (Vars.RyzeStacks)
            {
                case 0:
                case 1:
                    /// <summary>
                    ///     The Q Combo Logic.
                    /// </summary>
                    if (Vars.RyzeStacks != 1 ||
                        (GameObjects.Player.HealthPercent >
                            Vars.Menu["spells"]["q"]["shield"].GetValue<MenuSliderButton>().SValue ||
                        !Vars.Menu["spells"]["q"]["shield"].GetValue<MenuSliderButton>().BValue))
                    {
                        if (Vars.Q.IsReady() &&
                            Environment.TickCount - Vars.LastTick > 250 &&
                            Targets.Target.IsValidTarget(Vars.Q.Range-100f) &&
                            Vars.Menu["spells"]["q"]["combo"].GetValue<MenuBool>().Value)
                        {
                            Vars.Q.Cast(Vars.Q.GetPrediction(Targets.Target).UnitPosition);
                        }
                    }

                    /// <summary>
                    ///     The W Combo Logic.
                    /// </summary>
                    if (Vars.W.IsReady() &&
                        Targets.Target.IsValidTarget(Vars.W.Range) &&
                        Vars.Menu["spells"]["w"]["combo"].GetValue<MenuBool>().Value)
                    {
                        Vars.W.CastOnUnit(Targets.Target);
                    }

                    /// <summary>
                    ///     The E Combo Logic.
                    /// </summary>
                    if (Vars.E.IsReady() &&
                        Targets.Target.IsValidTarget(Vars.E.Range) &&
                        Vars.Menu["spells"]["e"]["combo"].GetValue<MenuBool>().Value)
                    {
                        Vars.E.CastOnUnit(Targets.Target);
                        Vars.LastTick = Environment.TickCount;
                        return;
                    }
                    break;

                default:
                    /// <summary>
                    ///     The Q Combo Logic.
                    /// </summary>
                    if (Vars.Q.IsReady() &&
                        Targets.Target.IsValidTarget(Vars.Q.Range-100f) &&
                        Vars.Menu["spells"]["q"]["combo"].GetValue<MenuBool>().Value)
                    { 
                        Vars.Q.Cast(Vars.Q.GetPrediction(Targets.Target).UnitPosition);
                    }
                    break;
            }
        }
    }
}