using OpenTK;
using OpenTK.Graphics;
using StorybrewCommon.Mapset;
using StorybrewCommon.Scripting;
using StorybrewCommon.Storyboarding;
using StorybrewCommon.Storyboarding.Util;
using StorybrewCommon.Subtitles;
using StorybrewCommon.Util;
using System;
using System.Collections.Generic;
using System.Linq;

namespace StorybrewScripts
{
    public class Main : StoryboardObjectGenerator
    {
        public override void Generate()
        {

            var layer = GetLayer("Main");

            // initialize sprites
            var snowDark = layer.CreateSprite("sb/snowDark.jpg", OsbOrigin.Centre);
            var snowLight = layer.CreateSprite("sb/snowLight.jpg", OsbOrigin.Centre);

            // set up scaling properly
            snowLight.Scale(-10000, 0.45);
            snowDark.Scale(-10000, 0.45);

            // ensure dark bg is visible for entire duration of song
            snowDark.Fade(-10000,150000, 1,1);

            // light bg initialization
            snowLight.Fade(-10000,51625, 0,0);

            // first kiai
            snowLight.Fade(51625,51714,0,0.33);
            snowLight.Fade(51714,51982,0.33,0.33);
            snowLight.Fade(51982,52071,0.33,0.66);
            snowLight.Fade(52071,52339,0.66,0.66);
            snowLight.Fade(52339,52428,0.66,1);
            snowLight.Fade(52428,74928,1,1);
            snowLight.Fade(74928,75285,1,0);

            // second kiai
            snowLight.Fade(75285,95196,0,0);
            snowLight.Fade(95196,95285,0,0.25);
            snowLight.Fade(95285,95553,0.25,0.25);
            snowLight.Fade(95553,95642,0.25,0.5);
            snowLight.Fade(95642,95910,0.5,0.5);
            snowLight.Fade(95910,96000,0.5,0.75);
            snowLight.Fade(96000,96267,0.75,0.75);
            snowLight.Fade(96267,96357,0.75,0.85);
            snowLight.Fade(96357,96625,0.85,0.85);
            snowLight.Fade(96625,96714,0.85,1);
            snowLight.Fade(96714,118767,1,1);
            snowLight.Fade(118767,118857,1,0);

            var snowLightBounce = layer.CreateSprite("sb/snowLight.jpg", OsbOrigin.Centre);
            snowLightBounce.Scale(OsbEasing.Out, 105285, 105642, 0.45, 0.48);
            snowLightBounce.Fade(OsbEasing.In, 105285, 105642, 1, 0);

            snowLightBounce.Fade(106000-1, 106000, 0.48, 0.45)
            snowLightBounce.Scale(OsbEasing.Out, 106000, 106357, 0.45, 0.48);
            snowLightBounce.Fade(OsbEasing.In, 106000, 106357, 1, 0);

        }
    }
}
