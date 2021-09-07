// written by thunderbird2678
// you can contact me on twitter @thunderbird2678 or on discord (thunderbird#2678)
// feel free to use any or all parts of this storyboard code however you wish

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
    public class bounce : StoryboardObjectGenerator
    {
        [Configurable]
        // a string containing a path to the background image used for the effect
        public string bg = "sb/snowLight.jpg";

        [Configurable]
        // an integer containing the beat subdivisor that will be used to control fade and scale in/out duration
        public int beatDivisor = 4;

        [Configurable]
        // an integer containing the number of subdivisions after which the scaling effect ends
        public int scaleDuration = 8;

        [Configurable]
        // an integer containing the number of subdivisions after which the fading effect ends
        public int fadeDuration = 32;

        [Configurable]
        // a double containing the scaling factor of the image at the beginning of the effect
        public double scaleStart = 0.45;

        [Configurable]
        // a double containing the scaling factor of the image at the end of the effect
        public double scaleEnd = 0.48;

        public override void Generate()
        {
            var layer = GetLayer("Main");

            // an integer list containing timestamps to when the effect should fire
            int[] times = new int[] { 105285, 106000, 108142, 108857, 116714, 118857 };

            // loop through each timestamp
            foreach (var time in times)
            {

                // initialize the background
                var background = layer.CreateSprite(bg, OsbOrigin.Centre);

                // calculate the duration of one subdivision
                var timeStep = Beatmap.GetTimingPointAt((int)time).BeatDuration / beatDivisor;

                // apply the scaling and fading with the parameters from above
                background.Scale(OsbEasing.Out, time, time + (timeStep * scaleDuration), scaleStart, scaleEnd);
                background.Fade(OsbEasing.In, time, time + (timeStep * fadeDuration), 1, 0);
            }
        }
    }
}
