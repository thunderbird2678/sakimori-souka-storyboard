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
    public class Bounce : StoryboardObjectGenerator
    {
        public override void Generate()
        {

            var layer = GetLayer("Main");

            int[] times = new int[]{105285, 106000, 108142, 108857, 116714, 118857};

            foreach (var time in times)
            {
                var snowLightBounce = layer.CreateSprite("sb/snowLight.jpg", OsbOrigin.Centre);
                snowLightBounce.Scale(OsbEasing.Out, time, time+357, 0.45, 0.48);
                snowLightBounce.Fade(OsbEasing.In, time, time+357, 1, 0);
            }
        }
    }
}
