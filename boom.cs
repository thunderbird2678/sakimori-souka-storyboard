// pretty much just slight modifications on the original HitobjectHighlighting script
// edits by thunderbird2678
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
    public class boom : StoryboardObjectGenerator
    {
        [Configurable]
        // An integer containing the timestamp at which the effect should trigger
        public int Time = 0;

        [Configurable]
        // An integer containing the duration (in ms) after which the sprite fades out
        public int FadeDuration = 200;

        [Configurable]
        // A string containing the path to the image to be used as the sprite
        public string SpritePath = "sb/glow.png";

        [Configurable]
        // A double containing the scale of the sprite to be generated
        public double SpriteScale = 1;

        public override void Generate()
        {
            var hitobjectLayer = GetLayer("");

            // iterate through all hitobjects
            foreach (var hitobject in Beatmap.HitObjects)
            {
                // if the object's a slider
                if (hitobject is OsuSlider)
                {
                    // generate the effect if the slider's bounds surround the timestamp
                    if (hitobject.StartTime <= Time + 5 && hitobject.EndTime >= Time - 5)
                    {
                        // generate the sprite based on where the sliderball is at that point in time
                        var hSprite = hitobjectLayer.CreateSprite(SpritePath, OsbOrigin.Centre, hitobject.PositionAtTime(Time));
                        hSprite.Scale(OsbEasing.In, Time, Time + FadeDuration, SpriteScale, SpriteScale * 0.2);
                        hSprite.Fade(OsbEasing.In, Time, Time + FadeDuration, 1, 0);
                        hSprite.Additive(Time, Time + FadeDuration);
                        hSprite.Color(Time, new Color4(253, 234, 255, 255));
                    }

                }
                else
                {
                    // generate the effect if the hitcircle lands right on the timestamp
                    if (hitobject.StartTime == Time)
                    {
                        // generate the sprite based on hitcircle position
                        var hSprite = hitobjectLayer.CreateSprite(SpritePath, OsbOrigin.Centre, hitobject.Position);
                        hSprite.Scale(OsbEasing.In, Time, Time + FadeDuration, SpriteScale, SpriteScale * 0.2);
                        hSprite.Fade(OsbEasing.In, Time, Time + FadeDuration, 1, 0);
                        hSprite.Additive(Time, Time + FadeDuration);
                        hSprite.Color(Time, new Color4(253, 234, 255, 255));
                    }
                }
            }
        }
    }
}