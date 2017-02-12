﻿// Copyright (c) 2007-2017 ppy Pty Ltd <contact@ppy.sh>.
// Licensed under the MIT Licence - https://raw.githubusercontent.com/ppy/osu/master/LICENCE

using osu.Framework.Allocation;
using osu.Framework.Graphics;
using osu.Framework.Graphics.Colour;
using osu.Framework.Graphics.Sprites;
using osu.Game.Graphics;

namespace osu.Game.Overlays.Notifications
{
    public class SimpleNotification : Notification
    {
        private string text;
        public string Text
        {
            get { return text; }
            set
            {
                text = value;
                if (IsLoaded)
                    textDrawable.Text = text;
            }
        }

        private FontAwesome icon = FontAwesome.fa_info_circle;
        public FontAwesome Icon
        {
            get { return icon; }
            set
            {
                icon = value;
                if (IsLoaded)
                    iconDrawable.Icon = icon;
            }
        }


        private SpriteText textDrawable;
        private TextAwesome iconDrawable;

        [BackgroundDependencyLoader]
        private void load(OsuColour colours)
        {
            IconContent.Add(new Drawable[]
            {
                new Box
                {
                    RelativeSizeAxes = Axes.Both,
                    ColourInfo = ColourInfo.GradientVertical(OsuColour.Gray(0.2f), OsuColour.Gray(0.5f))
                },
                iconDrawable = new TextAwesome
                {
                    Anchor = Anchor.Centre,
                    Icon = icon ,
                }
            });

            Content.Add(textDrawable = new SpriteText
            {
                TextSize = 16,
                Colour = OsuColour.Gray(128),
                AutoSizeAxes = Axes.Y,
                RelativeSizeAxes = Axes.X,
                Text = text
            });

            Light.Colour = colours.Green;
        }

        public override bool Read
        {
            get
            {
                return base.Read;
            }

            set
            {
                if (base.Read = value)
                    Light.FadeOut(100);
                else
                    Light.FadeIn(100);
            }
        }
    }
}