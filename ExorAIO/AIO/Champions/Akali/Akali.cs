
#pragma warning disable 1587

namespace ExorAIO.Champions.Akali
{
    using System;

    using ExorAIO.Utilities;

    using LeagueSharp;
    using LeagueSharp.SDK;
    using LeagueSharp.SDK.Enumerations;
    using LeagueSharp.SDK.UI;
    using LeagueSharp.SDK.Utils;

    /// <summary>
    ///     The champion class.
    /// </summary>
    internal class Akali
    {
        #region Public Methods and Operators

        /// <summary>
        ///     Called on do-cast.
        /// </summary>
        /// <param name="sender">The sender.</param>
        /// <param name="args">The args.</param>
        public static void OnDoCast(Obj_AI_Base sender, GameObjectProcessSpellCastEventArgs args)
        {
            if (sender.IsMe)
            {
                /// <summary>
                ///     Initializes the orbwalkingmodes.
                /// </summary>
                switch (Variables.Orbwalker.ActiveMode)
                {
                    case OrbwalkingMode.Combo:
                        if (AutoAttack.IsAutoAttack(args.SData.Name))
                        {
                            Logics.Weaving(sender, args);
                            break;
                        }

                        switch (args.SData.Name)
                        {
                            case "AkaliMota":
                                if (Vars.R.IsReady() && Targets.Target.IsValidTarget(Vars.R.Range)
                                    && !Targets.Target.IsValidTarget(Vars.AaRange)
                                    && Vars.Menu["spells"]["r"]["combo"].GetValue<MenuBool>().Value
                                    && Vars.Menu["spells"]["r"]["whitelist"][Targets.Target.ChampionName.ToLower()]
                                           .GetValue<MenuBool>().Value)
                                {
                                    if (!Targets.Target.IsUnderEnemyTurret()
                                        || !Vars.Menu["miscellaneous"]["safe"].GetValue<MenuBool>().Value)
                                    {
                                        Vars.R.CastOnUnit(Targets.Target);
                                    }
                                }
                                break;
                        }

                        break;
                    case OrbwalkingMode.LaneClear:
                        Logics.JungleClear(sender, args);
                        break;
                }
            }
        }

        /// <summary>
        ///     Fired when the game is updated.
        /// </summary>
        /// <param name="args">The <see cref="EventArgs" /> instance containing the event data.</param>
        public static void OnUpdate(EventArgs args)
        {
            if (GameObjects.Player.IsDead)
            {
                return;
            }

            /// <summary>
            ///     Initializes the Automatic actions.
            /// </summary>
            Logics.Automatic(args);

            /// <summary>
            ///     Initializes the Killsteal events.
            /// </summary>
            Logics.Killsteal(args);
            if (GameObjects.Player.IsWindingUp)
            {
                return;
            }

            /// <summary>
            ///     Initializes the orbwalkingmodes.
            /// </summary>
            switch (Variables.Orbwalker.ActiveMode)
            {
                case OrbwalkingMode.Combo:
                    Logics.Combo(args);
                    break;
                case OrbwalkingMode.Hybrid:
                    Logics.Harass(args);
                    break;
                case OrbwalkingMode.LaneClear:
                    Logics.Clear(args);
                    break;
            }
        }

        /// <summary>
        ///     Loads Akali.
        /// </summary>
        public void OnLoad()
        {
            /// <summary>
            ///     Initializes the menus.
            /// </summary>
            Menus.Initialize();

            /// <summary>
            ///     Initializes the spells.
            /// </summary>
            Spells.Initialize();

            /// <summary>
            ///     Initializes the methods.
            /// </summary>
            Methods.Initialize();

            /// <summary>
            ///     Initializes the drawings.
            /// </summary>
            Drawings.Initialize();
        }

        #endregion
    }
}