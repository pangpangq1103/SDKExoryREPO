
#pragma warning disable 1587

namespace ExorAIO.Champions.Vayne
{
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
            if (Vars.Q.IsReady() && Vars.Menu["spells"]["q"]["combo"].GetValue<MenuBool>().Value)
            {
                if (Vars.Menu["miscellaneous"]["wstacks"].GetValue<MenuBool>().Value
                    && ((Obj_AI_Hero)args.Target).GetBuffCount("vaynesilvereddebuff") != 1)
                {
                    return;
                }

                if (!Vars.Menu["miscellaneous"]["alwaysq"].GetValue<MenuBool>().Value)
                {
                    var posAfterQ = GameObjects.Player.ServerPosition.Extend(Game.CursorPos, 300f);
                    if (GameObjects.Player.Distance(Game.CursorPos) > Vars.AaRange
                        && posAfterQ.CountEnemyHeroesInRange(1000f) < 3
                        && ((Obj_AI_Hero)args.Target).Distance(posAfterQ) < Vars.AaRange)
                    {
                        Vars.Q.Cast(Game.CursorPos);
                    }
                    return;
                }

                Vars.Q.Cast(Game.CursorPos);
            }
        }

        #endregion
    }
}