using ExorAIO.Utilities;
using LeagueSharp;
using LeagueSharp.SDK;

namespace ExorAIO.Champions.Kalista
{
    /// <summary>
    ///     The methods class.
    /// </summary>
    internal class Methods
    {
        /// <summary>
        ///     The methods.
        /// </summary>
        public static void Initialize()
        {
            Game.OnUpdate += Kalista.OnUpdate;
            Obj_AI_Base.OnDoCast += Kalista.OnDoCast;
            Variables.Orbwalker.OnAction += Kalista.OnOrbwalkerAction;
        }
    }
}