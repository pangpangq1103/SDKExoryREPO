﻿using System.Collections.Generic;
using LeagueSharp;
using LeagueSharp.SDK;
using LeagueSharp.SDK.UI;
using LeagueSharp.SDK.Utils;
using SharpDX;

namespace ExorAIO.Utilities
{
    /// <summary>
    ///     The Vars class.
    /// </summary>
    internal class Vars
    {
        /// <summary>
        ///     The default enemy HP bar offset.
        /// </summary>
        public static int XOffset = 10;
        public static int YOffset = 20;
        public static int Width = 103;
        public static int Height = 8;

        /// <summary>
        ///     Gets all the important jungle locations.
        /// </summary>
        internal static readonly List<Vector3> Locations = new List<Vector3>
        {
            new Vector3(9827.56f, 4426.136f, -71.2406f),
            new Vector3(4951.126f, 10394.05f, -71.2406f),
            new Vector3(10998.14f, 6954.169f, 51.72351f),
            new Vector3(7082.083f, 10838.25f, 56.2041f),
            new Vector3(3804.958f, 7875.456f, 52.11121f),
            new Vector3(7811.249f, 4034.486f, 53.81299f)
        };

        /// <summary>
        ///     The jungle HP bar offset list.
        /// </summary>
        internal static readonly List<JungleHpBarOffset> JungleHpBarOffsetList = new List<JungleHpBarOffset>
        {
            new JungleHpBarOffset { BaseSkinName = "SRU_Dragon", Width = 140, Height = 4, XOffset = 12, YOffset = 24 },
            new JungleHpBarOffset { BaseSkinName = "SRU_Baron", Width = 190, Height = 10, XOffset = 16, YOffset = 24 },
            new JungleHpBarOffset { BaseSkinName = "SRU_RiftHerald", Width = 139, Height = 6, XOffset = 12, YOffset = 22 },
            new JungleHpBarOffset { BaseSkinName = "SRU_Red", Width = 139, Height = 4, XOffset = 12, YOffset = 24 },
            new JungleHpBarOffset { BaseSkinName = "SRU_Blue", Width = 139, Height = 4, XOffset = 12, YOffset = 24 },
            new JungleHpBarOffset { BaseSkinName = "SRU_Gromp", Width = 86, Height = 2, XOffset = 1, YOffset = 7 },
            new JungleHpBarOffset { BaseSkinName = "Sru_Crab", Width = 61, Height = 2, XOffset = 1, YOffset = 5 },
            new JungleHpBarOffset { BaseSkinName = "SRU_Krug", Width = 79, Height = 2, XOffset = 1, YOffset = 7 },
            new JungleHpBarOffset { BaseSkinName = "SRU_Razorbeak", Width = 74, Height = 2, XOffset = 1, YOffset = 7 },
            new JungleHpBarOffset { BaseSkinName = "SRU_Murkwolf", Width = 74, Height = 2, XOffset = 1, YOffset = 7 }
        };

        /// <summary>
        ///     A list of the names of the champions who cast Invalid Snares.
        /// </summary>
        public static readonly List<string> InvalidSnareCasters = new List<string>
        {
            "Leona",
            "Zyra"
        };

        /// <summary>
        ///     A list of the names of the champions who cast Invalid Stuns.
        /// </summary>
        public static readonly List<string> InvalidStunCasters = new List<string>
        {
            "Amumu",
            "LeeSin",
            "Alistar",
            "Hecarim",
            "Blitzcrank"
        };

        /// <summary>
        ///     Gets or sets the Q Spell.
        /// </summary>
        public static Spell Q { get; internal set; }

        /// <summary>
        ///     Gets or sets the 2nd stage of the Q Spell.
        /// </summary>
        public static Spell Q2 { get; internal set; }

        /// <summary>
        ///     Gets or sets the PowPow Range.
        /// </summary>
        public static Spell PowPow { get; internal set; }

        /// <summary>
        ///     Gets or sets the W Spell.
        /// </summary>
        public static Spell W { get; internal set; }

        /// <summary>
        ///     Gets or sets the E Spell.
        /// </summary>
        public static Spell E { get; internal set; }

        /// <summary>
        ///     Gets or sets the R Spell.
        /// </summary>
        public static Spell R { get; internal set; }

        /// <summary>
        ///     Gets or sets the assembly menu.
        /// </summary>
        public static Menu Menu { get; internal set; } = new Menu("aio", $"[ExorAIO]: {GameObjects.Player.ChampionName}", true);

        /// <summary>
        ///     Gets or sets the settings menu.
        /// </summary>
        public static Menu SpellsMenu { get; internal set; }

        /// <summary>
        ///     Gets or sets the Q Spell menu.
        /// </summary>
        public static Menu QMenu { get; internal set; }

        /// <summary>
        ///     Gets or sets the W Spell menu.
        /// </summary>
        public static Menu WMenu { get; internal set; }

        /// <summary>
        ///     Gets or sets the E Spell menu.
        /// </summary>
        public static Menu EMenu { get; internal set; }

        /// <summary>
        ///     Gets or sets the R Spell menu.
        /// </summary>
        public static Menu RMenu { get; internal set; }

        /// <summary>
        ///     Gets or sets the Miscellaneous menu.
        /// </summary>
        public static Menu MiscMenu { get; internal set; }

        /// <summary>
        ///     Gets or sets the Whitelist menu.
        /// </summary>
        public static Menu WhiteListMenu { get; internal set; }

        /// <summary>
        ///     Gets or sets the Drawings menu.
        /// </summary>
        public static Menu DrawingsMenu { get; internal set; }

        /// <summary>
        ///     Gets or sets the loaded champion.
        /// </summary>
        public static bool IsLoaded { get; internal set; } = true;

        /// <summary>
        ///     Gets or sets the Soulbound.
        /// </summary>
        public static Obj_AI_Hero SoulBound { get; internal set; }

        /// <summary>
        ///     Gets the Player's real AutoAttack-Range.
        /// </summary>
        public static float AARange
            =>
                GameObjects.Player.GetRealAutoAttackRange() +
                (Items.HasItem(3094) && GameObjects.Player.GetBuffCount("itemstatikshankcharge") == 100
                    ? GameObjects.Player.GetRealAutoAttackRange() / 100 * 30
                    : 0f);

        /// <summary>
        ///     The jungle HP bar offset.
        /// </summary>
        internal class JungleHpBarOffset
        {
            internal string BaseSkinName;
            internal int Height;
            internal int Width;
            internal int XOffset;
            internal int YOffset;
        }
    }
}